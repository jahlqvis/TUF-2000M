using System;

namespace TUF_2000M
{
    public class RealHandler : BaseHandler , IBaseHandler
    {
        private float data;

        public RealHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3 = 0) : base(name, unit, register1, register2, register3)
        {
            data = 0f;
        }

        public override object GetData()
        {
            return data;
        }

        public float Data { get => data; set => data = value; }

        public override bool ParseRegisters(params ushort[] list)
        {

            if (list.Length > 1)
                data = ConvertFromUShortToReal4(list[0], list[1]);
            else
                data = ConvertFromUShortToReal4(list[0]);

            return true;
        }

        private float ConvertFromUShortToReal4(params ushort[] registers)
        {
            if (registers.Length > 2 || registers.Length < 1)
                throw new ArgumentException("ConvertFromUShortToReal4: function parameters accepts only one or two ushorts");

            if (registers.Length > 1)
            {
                Int32 temp = registers[1];
                temp <<= 16;
                temp += registers[0];
                return BitConverter.Int32BitsToSingle(temp);
            }
            else
                return BitConverter.Int32BitsToSingle(registers[0]);
        }
    }
}