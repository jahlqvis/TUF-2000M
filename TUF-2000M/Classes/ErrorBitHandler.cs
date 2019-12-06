using System;

namespace TUF_2000M
{
    public class ErrorBitHandler : BaseHandler, IBaseHandler
    {

        private ErrorBit data;

        public ErrorBitHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3 = 0) : base(name, unit, register1, register2, register3)
        {
            data = ErrorBit.None;   // default
        }

        public override object GetData()
        {
            return data;
        }

        public override string ConvertDataToString()
        {
            return data.ToString();
        }

        internal ErrorBit Data { get => data; set => data = value; }

        public override bool ParseRegisters(params ushort[] list)
        {
            if (list.Length > 1)
                throw new ArgumentException("Should be only 1 ushort");

            data = (ErrorBit)list[0];
            return true;
        }
    }
}