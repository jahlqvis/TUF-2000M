using System;

namespace TUF_2000M
{
    public class LowerByteHandler : BaseHandler, IBaseHandler
    {
        private byte data;

        public LowerByteHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3 = 0) : base(name, unit, register1, register2, register3)
        {
            data = 0;
        }

        public override object GetData()
        {
            return data;
        }

        public override string ConvertDataToString()
        {
            return data.ToString();
        }

        public byte Data { get => data; set => data = value; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public override bool ParseRegisters(params ushort[] list)
        {
            if (list.Length != 1)
                throw new ArgumentException("LowerByteHandler::ParseRegisters: Takes only one ushort as parameter");

            data = ConvertFromUShortToByte(list[0]);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registers"></param>
        /// <returns></returns>
        private byte ConvertFromUShortToByte(params ushort[] registers)
        { 
            byte lower = (byte)(registers[0] & 0xff);
            return lower;
        }
    }

    public class UpperByteHandler : BaseHandler, IBaseHandler
    {
        private byte data;

        public UpperByteHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3 = 0) : base(name, unit, register1, register2, register3)
        {
            data = 0;
        }

        public override object GetData()
        {
            return data;
        }

        public override string ConvertDataToString()
        {
            return data.ToString();
        }

        public byte Data { get => data; set => data = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public override bool ParseRegisters(params ushort[] list)
        {
            if (list.Length != 1)
                throw new ArgumentException("UpperByteHandler::ParseRegisters: Takes only one ushort as parameter");

            data = ConvertFromUShortToByte(list[0]);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registers"></param>
        /// <returns></returns>
        private byte ConvertFromUShortToByte(params ushort[] registers)
        {
            byte upper = (byte)(registers[0] >> 8);
            return upper;
        }
    }

}