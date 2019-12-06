using System.Collections.Generic;

namespace TUF_2000M
{

    public abstract class BaseHandler : IBaseHandler
    {
        protected string name;
        protected string unit;
        protected ushort register1;  // the lowest register the variable is saved on 
        protected ushort register2;
        protected ushort register3;  // the highest register the variable is saved on


        public abstract object GetData();
        
        public BaseHandler(string name, string unit, ushort register1, ushort register2=0, ushort register3=0)
        {
            this.name = name;
            this.unit = unit;
            this.register1 = register1;
            this.register2 = register2;
            this.register3 = register3;

        }

        public abstract string ConvertDataToString();

        public abstract bool ParseRegisters(params ushort[] list);

        public string Name => name;

        public string Unit => unit;

        public ushort Register1 => register1;

        public ushort Register2 => register2;

        public ushort Register3 => register3;
    }
}