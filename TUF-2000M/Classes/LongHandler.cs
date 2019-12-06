using System;

namespace TUF_2000M
{
    public class LongHandler : BaseHandler, IBaseHandler
    {
        private Int32 data;

        public LongHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3 = 0) : base(name, unit, register1, register2, register3)
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

        public int Data { get => data; set => data = value; }

        public override bool ParseRegisters(params ushort[] list)
        {
            if (list.Length > 1)
                data = ConvertFromUShortToLong(list[0], list[1]);
            else
                data = ConvertFromUShortToLong(list[0]);

            return true;
        }

        private int ConvertFromUShortToLong(params ushort[] registers)
        {
            if (registers.Length > 2 || registers.Length < 1)
                throw new ArgumentException("ConvertFromUShortToLong: function parameters accepts only one or two ushorts");

            if (registers.Length > 1)
            {
                Int32 temp = registers[1];
                temp <<= 16;
                temp += registers[0]; // little endian order, least significant byte firsts
                return temp;
            }
            else
                return Convert.ToInt32(registers[0]);



        }
    }
}