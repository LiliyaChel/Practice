using System.IO;
using System.Net;

namespace kidstrUser
{
    public static class JsonFunc
    {
        private static string site = @"http://kidstrWebApi.somee.com/";

        public static string Request(string name, string method, string data)
        {
            HttpWebRequest request = WebRequest.Create(site + name) as HttpWebRequest;
            request.Method = method.ToUpper(); //POST, PUT
            request.ContentType = "application/json; charset=utf-8";
            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(data);
            }
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static string ReturnList(string name)
        {
            HttpWebRequest request = WebRequest.Create(site + name) as HttpWebRequest;
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static string Delete(string name, string data)
        {
            HttpWebRequest request = WebRequest.Create(site + name + "/" + data) as HttpWebRequest;
            request.Method = "DELETE";
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
