using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TUF_2000M
{
    public class Reader
    {
        private StreamReader _sr;
        private string[] _buffer;
        private IVariableStorage _vs;
        private Dictionary<int, int> _dict;
        private string dateText;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="vs"></param>
        /// <param name="mockBuffer"></param>
        public Reader(IVariableStorage vs, string[] mockBuffer = null)
        {
            if (vs == null)
                throw new ArgumentException("VariableStorage object must be passed in creator");

            _vs = vs;

            if (mockBuffer != null)
                _buffer = mockBuffer;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileurl"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Parses line from string read in feed to line number (int) and line value (int)
        /// </summary>
        /// <param name="line">The input string</param>
        /// <param name="Value">Passed as ref to integer. Returns the read value as a integer</param>
        /// <returns>The read line number as a integer</returns>
        public int ParseLine(string line, ref int Value)
        {

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(line);
            string s1;
            string s2;

            if (match.Success)
            {
                s1 = match.Value;

                if (match.NextMatch().Success)
                {
                    s2 = match.NextMatch().Value;
                }
                else
                    throw new ArgumentException("Reader::ParseLine: Parameter line only contained one number");
            }
            else
                throw new ArgumentException("Reader::ParseLine: Parameter line did not contain any numbers");
            

            Value = Convert.ToInt32(s2);
            return Convert.ToInt32(s1);
        }


        /// <summary>
        /// Put text in buffer in dictionary instead
        /// </summary>
        /// <returns></returns>
        private bool SerializeBuffer()
        {
            int bufferLength = _buffer.GetLength(0);
            if (bufferLength == 0)
                throw new SystemException("Reader::SerializeBuffer: No data has been read from server!");
            if (bufferLength < 101)
                throw new SystemException("Reader::SerializeBuffer: Incomplete data read from server!");

            _dict = new Dictionary<int, int>();

            dateText = GetLine(1);    
            for (int i = 2; i <= bufferLength; i++)
            {
                string lineText;
                int value=0;
                int lineNr;
                lineText = GetLine(i);
                lineNr = ParseLine(lineText, ref value);

                _dict.Add(lineNr, value);
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool InterpretDictionary()
        {
            _vs = new VariableStorage();

            return (_vs.FillData(ref _dict));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            SerializeBuffer();

            InterpretDictionary();

            _vs.PrintData();

            return true;
        }

    }
    
}
