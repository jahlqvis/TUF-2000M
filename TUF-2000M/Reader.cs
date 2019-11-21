using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TUF_2000M
{
    public class Reader
    {
        private StreamReader _sr;

        public bool ReadURL(string url)
        {
            try
            {
                _sr = URLStream(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        private StreamReader URLStream(String fileurl)
        {
            return new StreamReader(new HttpClient().GetStreamAsync(fileurl).Result);
        }


    }
    
}
