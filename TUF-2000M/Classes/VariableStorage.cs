using System;
using System.Collections;
using System.Collections.Generic;

namespace TUF_2000M
{
    public interface IVariableStorage
    {
        public bool FillData(ref Dictionary<int, int> dict);
        public void PrintData();

    }


    public class VariableStorage : IVariableStorage
    {
        public ArrayList list;

        public VariableStorage()
        {
            list = new ArrayList();

            Hashtable hash = new Hashtable();

            list.Add(new RealHandler("Flow Rate", "m^3/h", 1, 2));
            list.Add(new RealHandler("Energy Flow Rate", "GJ/j", 3, 4));
            list.Add(new RealHandler("Velocity", "m/s", 5, 6));
            list.Add(new RealHandler("Fluid sound speed", "m/s", 7, 8));
            list.Add(new LongHandler("Positive accumulator", "Unit selected by M31", 9, 10));

            // test concept first ... add rest later

        }

        public void PrintData()
        {
            foreach(BaseHandler bh in list)
            {
                var data = bh.GetData();

                if ((data.GetType() == typeof(float)) || (data.GetType() == typeof(int)))
                    Console.WriteLine($"{bh.Register1}\t{bh.Name}\t{bh.Unit}\t{data}\t");
                
            }

        }

        public bool FillData(ref Dictionary<int, int> dict)
        {
            foreach (BaseHandler variable in list)
            {
                if (variable.Register2 == 0)
                {
                    // only register1 used

                    foreach (KeyValuePair<int, int> element in dict)
                    {
                        if (element.Key == (int)variable.Register1)
                        {
                            variable.ParseRegisters((ushort)element.Value);
                            break;
                        }

                    }

                }
                else if ((variable.Register2 > 0) && (variable.Register3 == 0))
                {
                    // register1 and register2 used

                    int reg1value = 0;
                    int reg2value = 0;


                    foreach (KeyValuePair<int, int> element in dict)
                    {
                        if (element.Key == (int)variable.Register1)
                        {
                            reg1value = element.Value;
                        }
                        if (element.Key == (int)variable.Register2)
                        {
                            reg2value = element.Value;
                        }

                        if (reg1value > 0 && reg2value > 0)
                        {
                            variable.ParseRegisters((ushort)reg1value, (ushort)reg2value);
                            break;
                        }

                    }
                }
                else if ((variable.Register2 > 0) && (variable.Register3 > 0))
                {
                    // all 3 regisers used

                    int reg1value = 0;
                    int reg2value = 0;
                    int reg3value = 0;

                    foreach (KeyValuePair<int, int> element in dict)
                    {
                        if (element.Key == (int)variable.Register1)
                        {
                            reg1value = element.Value;
                        }
                        if (element.Key == (int)variable.Register2)
                        {
                            reg2value = element.Value;
                        }
                        if (element.Key == (int)variable.Register3)
                        {
                            reg3value = element.Value;
                        }
                        if (reg1value > 0 && reg2value > 0 && reg3value > 0)
                        {
                            variable.ParseRegisters((ushort)reg1value, (ushort)reg2value, (ushort)reg3value);
                            break;
                        }
                    }
                }
                else
                    throw new SystemException("Should never reach this point");
            }

            return true;
        }
        
    }
}
