using System;
namespace TUF_2000M
{
    public class ModbusValue<T>
    {
        private readonly string name;
        private readonly string unit;
        private T data;

        public ModbusValue(string name, string unit)
        {
            this.name = name;
            this.unit = unit;

        }

        
        public T Value
        {
            get
            {
                return this.data;

            }

            set
            {
                this.data = value;
            }
        }

        public string Name => name;

        public string Unit => unit;
    }
}