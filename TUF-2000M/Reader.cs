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

        public Reader(string[] mockBuffer = null)
        {
            if (mockBuffer != null)
                _buffer = mockBuffer;

        }
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
            catch (AggregateException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw e;
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
                throw new IOException("text buffer read from server is empty");

            if (lineNr < 1 || lineNr > _buffer.Length)
                throw new IOException($"lineNr {lineNr} is out of buffer boundary");

            return _buffer[lineNr-1];
        }

        public float ConvertFromIntToReal4(ushort register1, ushort register2)
        {
            Int32 temp = register2;
            temp <<= 16;
            temp += register1;

            return BitConverter.Int32BitsToSingle(temp);
        }


    }
    
}
