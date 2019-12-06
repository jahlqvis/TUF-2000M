using System;

namespace TUF_2000M
{
    public class BCDHandler : BaseHandler, IBaseHandler
    {
        private int[] data;

        public BCDHandler(string name, string unit, ushort register1, ushort register2 = 0, ushort register3=0) : base(name, unit, register1, register2, register3)
        {

        }

        public override object GetData()
        {
            return data;
        }

        public override string ConvertDataToString()
        {
            if (data == null)
                throw new SystemException($"data is null for object {name}");


            switch(data.Length)
            {
                case 6:
                    // calender case (time and date SMHDMY) 
                    return string.Concat(data[0].ToString(), ":", data[1].ToString(), ":", data[2].ToString(), " ", data[3].ToString(), ".", data[4].ToString(), "-", data[5].ToString());
                case 4:
                    return string.Concat(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
                case 2:
                    return string.Concat(data[0].ToString(), data[1].ToString());
                default:
                    throw new SystemException("data length not supported");

            }

            
        }

        public int[] Data { get => data; set => data = value; }

        public override bool ParseRegisters(params ushort[] list)
        {
            if (list.Length > 3 || list.Length < 1)
                throw new ArgumentException("BCDHandler::ParseRegisters accepts only 1 - 3 ushorts");

            int[] i0;
            int[] i1;
            int[] i2;

            switch (list.Length)
            {
                case 1:
                    i0 = ConvertFromUShortToBCD(list[0]);
                    data = new int[i0.Length];
                    Array.Copy(i0, data, i0.Length);
                    break;
                case 2:
                    i0 = ConvertFromUShortToBCD(list[0]);
                    i1 = ConvertFromUShortToBCD(list[1]);

                    data = new int[i0.Length + i1.Length];
                    Array.Copy(i0, data, i0.Length);
                    Array.Copy(i1, 0, data, i0.Length, i1.Length);
                    break;
                case 3:
                    i0 = ConvertFromUShortToBCD(list[0]);
                    i1 = ConvertFromUShortToBCD(list[1]);
                    i2 = ConvertFromUShortToBCD(list[2]);

                    data = new int[i0.Length + i1.Length + i2.Length];
                    Array.Copy(i0, data, i0.Length);
                    Array.Copy(i1, 0, data, i0.Length, i1.Length);
                    Array.Copy(i2, 0, data, i0.Length + i1.Length, i2.Length);

                    break;

            }

            return true;
        }

        private int[] ConvertFromUShortToBCD(ushort register)
        {

            byte[] bytes = BitConverter.GetBytes(register);

            if (bytes.Length != 2)
                throw new ArgumentException("ConvertFromUShortToBCD: register should have be 2 bytes");

            string hexStr;
            int[] decimals = new int[bytes.Length];

            hexStr = string.Format("{0:x}", bytes[0]);
            decimals[0] = Convert.ToInt16(hexStr, 10);

            hexStr = string.Format("{0:x}", bytes[1]);
            decimals[1] = Convert.ToInt16(hexStr, 10);

            return decimals;
        }

    }
}