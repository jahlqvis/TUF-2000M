namespace TUF_2000M
{
    public interface IRealHandler
    {
        public bool ParseRegisters(params ushort[] list);

        public string ConvertDataToString();

        public object GetData();

    }
}