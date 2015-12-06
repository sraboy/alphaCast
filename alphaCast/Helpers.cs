using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace alphaCast
{
    public static class Helpers
    {
        public static string EscapeRSSFeed(string rssXML)
        {
            if (rssXML == null)
                throw new ArgumentNullException("xmlString");

            return rssXML.Replace("'", "&apos;").Replace("\"", "&quot;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("&", "&amp;");
        }
        public static async Task<iTunesResults> SearchiTunes(String SearchCriteria)
        {
            //todo: add filter by audio/video
            Podcast cast = new Podcast();

            using (var httpClient = new HttpClient())
            {
                var encoded = Uri.EscapeUriString(SearchCriteria);
                var json = await httpClient.GetStringAsync("https://itunes.apple.com/search?media=podcast&term=" + Uri.EscapeUriString(SearchCriteria)).ConfigureAwait(continueOnCapturedContext: false);

                return JsonConvert.DeserializeObject<iTunesResults>(json);
            }
        }

        public static async Task<bool> ScrapeDescription(Podcast pc)
        {
            String urlAddress = pc.CollectionViewUrl;//"https://itunes.apple.com/us/podcast/this-week-in-tech-mp3/id73329404?mt=2&ign-mpt=uo%3D4";
            String webresponse;
            HttpClient http = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = await http.GetAsync(urlAddress);
                webresponse = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Something happened.\nException: " + e.Message);
            }
            String sPattern = @"<h4\b[^>]*>[\\n\s]+?Description[\\n\s]*?</h4>[\\n\s]+<p\b[^>]*>[\\n\s]*?(?'desc'.+)";

            MatchCollection mc = Regex.Matches(webresponse, sPattern);
            if (mc.Count > 0)
            {
                Match m = mc[0];
                pc.Description = m.Groups["desc"].ToString();
                return true;
            }

            return false;
        }
        public static async Task<bool> GetRSSDescription(Podcast pc)
        {
            String urlAddress = pc.FeedUrl;//"https://itunes.apple.com/us/podcast/this-week-in-tech-mp3/id73329404?mt=2&ign-mpt=uo%3D4";
            XDocument xdoc = new XDocument();
            XElement channelElement;
            HttpClient http = new HttpClient();
            String webresponse = "";
            Uri url;

            if (urlAddress != null)
            {
                try
                {
                    if (Uri.TryCreate(urlAddress, UriKind.Absolute, out url))
                    {
                        HttpResponseMessage response = await http.GetAsync(url);
                        webresponse = await response.Content.ReadAsStringAsync();
                        webresponse.Trim();
                    }
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(HttpRequestException))
                        Helpers.ScrapeDescription(pc);

                    if (e.GetType() == typeof(TaskCanceledException))
                        return false;

                    throw new Exception("Something happened.\nException: " + e.Message);
                }

                try
                {
                    if (webresponse != "")
                    {
                        String res = null;
                        //some sites freak out since we're not giving a User Agent and spit out errors in front of the RSS
                        if (!(webresponse.StartsWith("<rss") || webresponse.StartsWith("<RSS")))
                        {
                            res = Regex.Match(webresponse, "<rss.*", RegexOptions.Singleline).ToString().Trim();
                        }
                        else
                            res = webresponse;

                        //search for "media" and see a malformed value at line 58 the crashes the parser
                        xdoc = XDocument.Parse(res);
                        channelElement = xdoc.Root.Element("channel");
                    }


                    XNamespace itunesNamespace = "http://www.itunes.com/dtds/podcast-1.0.dtd";

                    foreach (XElement xel in xdoc.Descendants())
                    {
                        if (xel.Name.Namespace == itunesNamespace)
                        {
                            switch (xel.Name.LocalName)
                            {
                                case "summary":
                                    pc.Description = xel.Value;
                                    break;
                                case "subtitle":
                                    break;
                            }
                        }
                    }

                    return true;
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(XmlException))
                        return await Helpers.ScrapeDescription(pc);
                }
            }

            return false;
        }
    }
}
