using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TAEM.Domain;
using System.Net;
using System.IO;
using System.Web;
using System.Net;

namespace TAEM.Business
{
    public class TwitterComponent
    {
        private const string TwitterJsonUrl = "http://twitter.com/statuses/update.json";
        private const string TwitterUser = "ngcbassman";
        private const string TwitterPass = "Micasa26";

        public void SendMessage(Proyecto proyecto)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(TwitterJsonUrl);
                System.Net.ServicePointManager.Expect100Continue = false;
                string post = string.Empty;
                using (TextWriter writer = new StringWriter())
                {
                    var twitterMessage = proyecto.Nombre.Length > 140 ? proyecto.Nombre.Substring(0, 140) : proyecto.Nombre;
                    writer.Write("status={0}", WebUtility.HtmlEncode(twitterMessage));
                    post = writer.ToString();
                }
                SetRequestParams(request);
                request.Credentials = new NetworkCredential(TwitterUser, TwitterPass);
                using (Stream requestStream = request.GetRequestStream())
                {
                    using (StreamWriter writer = new StreamWriter(requestStream))
                    {
                        writer.Write(post);
                    }
                }
                WebResponse response = request.GetResponse();
                string content;
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetRequestParams(HttpWebRequest request)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            request.Timeout = 500000;
            request.Method = "POST";
            //request.Headers.Add("Authorization", "Basic " + TwitterUser);
            request.ContentType = "application/x-www-form-urlencoded";
        }
    }
}
