using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

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
            list.Add(new RealHandler("Energy Flow Rate", "GJ/h", 3, 4));
            list.Add(new RealHandler("Velocity", "m/s", 5, 6));
            list.Add(new RealHandler("Fluid sound speed", "m/s", 7, 8));
            list.Add(new LongHandler("Positive accumulator", "Unit selected by M31", 9, 10));
            list.Add(new RealHandler("Positive decimal fraction", "", 11, 12));
            list.Add(new LongHandler("Negative accumulator", "", 13, 14));
            list.Add(new RealHandler("Negative decimal fraction", "", 15, 16));
            list.Add(new LongHandler("Positive energy accumulator", "", 17, 18));
            list.Add(new RealHandler("Positive energy decimal fraction", "", 19, 20));
            list.Add(new LongHandler("Negative energy accumulator", "", 21, 22));
            list.Add(new RealHandler("Negative energy decimal fraction", "", 23, 24));
            list.Add(new LongHandler("Net accumulator", "", 25, 26));
            list.Add(new RealHandler("Net decimal fraction", "", 27, 28));
            list.Add(new LongHandler("Net energy accumulator", "", 29, 30));
            list.Add(new RealHandler("Net energy decimal fraction", "", 31, 32));
            list.Add(new RealHandler("Temperature #1/inlet", "C", 33, 34));
            list.Add(new RealHandler("Temperature #2/outlet", "C", 35, 36));
            list.Add(new RealHandler("Analog input AI3", "", 37, 38));
            list.Add(new RealHandler("Analog input AI4", "", 39, 40));
            list.Add(new RealHandler("Analog input AI5", "", 41, 42));
            list.Add(new RealHandler("Current input at AI3", "mA", 43, 44));
            list.Add(new RealHandler("Current input at AI4", "mA", 45, 46));
            list.Add(new RealHandler("Current input at AI5", "mA", 47, 48));
            list.Add(new BCDHandler("System password", "", 49, 50));
            list.Add(new BCDHandler("Password for hardware", "", 51, 52));
            list.Add(new BCDHandler("Calendar(date and time)", "", 53, 54, 55));
            list.Add(new BCDHandler("Day + Hour for Auto - Save", "", 56));
            list.Add(new LongHandler("Key to input", "Writable", 59));
            list.Add(new LongHandler("Go to Window #", "Writable", 60));
            list.Add(new LongHandler("LCD Back - lit lights for number of seconds", "Second", 61));
            list.Add(new LongHandler("Times for the beeper", "", 62));
            list.Add(new LongHandler("Pulses left for OCT", "", 63));
            list.Add(new ErrorBitHandler("Error Code", "", 72));
            list.Add(new RealHandler("PT100 resistance of inlet", "Ohm", 77, 78));
            list.Add(new RealHandler("PT100 resistance of outlet", "Ohm", 79, 80));
            list.Add(new RealHandler("Total travel time", "Micro-second", 81, 82));
            list.Add(new RealHandler("Delta travel time", "Nano-second", 83, 84));
            list.Add(new RealHandler("Upstream travel time", "Micro-second", 85, 86));
            list.Add(new RealHandler("Downstream travel time", "Micro-second", 87, 88));
            list.Add(new RealHandler("Output current", "mA", 89, 90));
            list.Add(new LongHandler("Working step and Signal Quality", "", 92));
            list.Add(new LongHandler("Upstream strength", "Range 0 - 2047", 93));
            list.Add(new LongHandler("Downstream strength", "Range 0 - 2047", 94));
            list.Add(new LongHandler("Language used in user interface", "0 : English，1 : Chinese", 96));
            list.Add(new RealHandler("The rate of the measured travel time by the calculated travel time", "Normal 100+-3%", 97, 98));
            list.Add(new RealHandler("Reynolds number", "", 99, 100));

        }

        public void PrintData()
        {
            foreach(BaseHandler bh in list)
            {
                string data = bh.ConvertDataToString();

                //if ((data.GetType() == typeof(float)) || (data.GetType() == typeof(int)))
                Console.WriteLine($"{bh.Register1}\t{bh.Name}\t{data}\t{bh.Unit}");

                
            }

            Console.Read();

        }

        public bool FillData(ref Dictionary<int, int> dict)
        {
            int reg1value = 0;
            int reg2value = 0;
            int reg3value = 0;
            bool breg1value = false;
            bool breg2value = false;
            bool breg3value = false;

            foreach (BaseHandler variable in list)
            {
                if ((variable.Register1 > 0) && (variable.Register2 == 0) && (variable.Register3 == 0))
                {
                    // only register1 used

                    foreach (KeyValuePair<int, int> element in dict)
                    {
                        if (element.Key == (int)variable.Register1)
                        {
                            reg1value = element.Value;

                            variable.ParseRegisters((ushort)reg1value);

                            breg1value = false; // reset
                            break;
                        }

                    }

                }
                else if ((variable.Register1 > 0) && (variable.Register2 > 0) && (variable.Register3 == 0))
                {
                    // register1 and register2 used

                    foreach (KeyValuePair<int, int> element in dict)
                    {
                        if (element.Key == (int)variable.Register1)
                        {
                            reg1value = element.Value;
                            breg1value = true;
                        }
                        if (element.Key == (int)variable.Register2)
                        {
                            reg2value = element.Value;
                            breg2value = true;
                        }

                        if (breg1value && breg2value)
                        {

                            variable.ParseRegisters((ushort)reg1value, (ushort)reg2value);

                            breg1value = false;
                            breg2value = false;

                            break;
                        }

                    }
                }
                else if ((variable.Register1 > 0) && (variable.Register2 > 0) && (variable.Register3 > 0))
                {
                    // all 3 regisers used

                    foreach (KeyValuePair<int, int> element in dict)
                    {
                        if (element.Key == (int)variable.Register1)
                        {
                            reg1value = element.Value;
                            breg1value = true;
                        }
                        if (element.Key == (int)variable.Register2)
                        {
                            reg2value = element.Value;
                            breg2value = true;
                        }
                        if (element.Key == (int)variable.Register3)
                        {
                            reg3value = element.Value;
                            breg3value = true;
                        }
                        if (breg1value && breg2value && breg3value)
                        {
                            variable.ParseRegisters((ushort)reg1value, (ushort)reg2value, (ushort)reg3value);

                            breg1value = false;
                            breg2value = false;
                            breg3value = false;
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
