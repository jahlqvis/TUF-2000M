namespace TUF_2000M
{
    public interface IErrorBitHandler
    {
        public bool ParseRegisters(params ushort[] list);

        public string ConvertDataToString();

        public object GetData();

    }
}