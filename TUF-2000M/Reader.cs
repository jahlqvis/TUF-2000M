using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TUF_2000M
{
    public static class Reader
    {
        static StreamReader URLStream(String fileurl)
        {
            return new StreamReader(new HttpClient().GetStreamAsync(fileurl).Result);
        }
    }
    
}
