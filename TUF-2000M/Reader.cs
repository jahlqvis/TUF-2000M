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

        public string GetLine(int lineNr)
        {
            string str = string.Empty;

            if (_sr == StreamReader.Null)
                return str;

            try
            {
                for(int i=0;i<lineNr;i++)
                    str = _sr.ReadLine();
            }
            catch (IOException e)
            {
                throw e;
            }
            catch(OutOfMemoryException e)
            {
                throw e;
            }

            return str;
        }

    }
    
}
