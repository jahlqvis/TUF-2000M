using System.Collections.Generic;

namespace TUF_2000M
{
    public interface IVariableStorage
    {
        public bool FillData(ref Dictionary<int, int> dict);
        public void PrintData();

    }
}
