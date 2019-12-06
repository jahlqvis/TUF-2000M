using System;

namespace TUF_2000M
{
    public class IntHandler : BaseHandler, IBaseHandler
    {
        private Int16 data;

        public IntHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3 = 0) : base(name, unit, register1, register2, register3)
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

        public Int16 Data { get => data; set => data = value; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public override bool ParseRegisters(params ushort[] list)
        {
            if (list.Length != 1)
                throw new ArgumentException("IntHandler::ParseRegisters: function parameters accepts only one ushort");

            data = ConvertFromUShortToInt(list[0]);
            
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registers"></param>
        /// <returns></returns>
        private Int16 ConvertFromUShortToInt(params ushort[] registers)
        {

            return Convert.ToInt16(registers[0]);
            
        }
    }
}