using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
namespace TUF_2000M
{
    public class Reader
    {
        private StreamReader _sr;
        private string[] _buffer;

        public bool ReadURL(string url)
        {
            List<string> stringList = new List<string>();

            try
            {
                _sr = URLStream(url);

                while (_sr.EndOfStream == false)
                {
                    stringList.Add(_sr.ReadLine());
                }
                _sr.Close();

                _buffer = stringList.ToArray();
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
            if (_buffer.Length == 0)
                return string.Empty; // todo: needs to be better handled

            if (lineNr < 1 || lineNr > _buffer.Length)
                return string.Empty; // todo: needs to be better handled

            return _buffer[lineNr-1];
        }

    }
    
}
