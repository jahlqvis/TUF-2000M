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

        public float ConvertFromUShortToReal4(ushort register1, ushort register2)
        {
            Int32 temp = register2;
            temp <<= 16;
            temp += register1;

            return BitConverter.Int32BitsToSingle(temp);
        }

        public Int32 ConvertFromUShortToInt32(ushort register1, ushort register2)
        {
            Int32 temp = register2; 
            temp <<= 16;
            temp += register1; // little endian order, least significant byte firsts

            return temp;
        }

        public int[] ConvertFromUShortTo6Decimals(ushort register1, ushort register2, ushort register3)
        {
            int[] result = new int[6];

            int[] decimals;

            decimals = ExtractDecimalsFromBCD(register1);
            result[0] = decimals[0];
            result[1] = decimals[1];

            decimals = ExtractDecimalsFromBCD(register2);
            result[2] = decimals[0];
            result[3] = decimals[1];

            decimals = ExtractDecimalsFromBCD(register3);
            result[4] = decimals[0];
            result[5] = decimals[1];

            return result;
        }

        private static int[] ExtractDecimalsFromBCD(ushort register)
        {
            byte[] bytes = BitConverter.GetBytes(register);

            if (bytes.Length != 2)
                throw new ArgumentException("register should be 2 bytes");

            string hexStr;
            int[] decimals = new int[2];

            hexStr = string.Format("{0:x}", bytes[0]);
            decimals[0] = Convert.ToInt16(hexStr, 10);

            hexStr = string.Format("{0:x}", bytes[1]);
            decimals[1] = Convert.ToInt16(hexStr, 10);

            return decimals;
        }
    }
    
}
