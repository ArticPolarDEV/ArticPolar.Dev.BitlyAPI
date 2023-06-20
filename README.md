![Logo](logo/icon.png)
# ArticPolar.Dev.BitlyAPI
A C# implementation of the Bit.ly API

## Example of Use
````
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticPolar.Dev.BitlyShortener;
using System.Net;
using System.Net.Http;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string _accessToken = "6a8b4f18efc657800a0c82fff111a29da93a010f";
            string longUrl = args[0];
            BitlyShortener bitlyShortener = new BitlyShortener(_accessToken);
            Task<string> shortUrlTask = bitlyShortener.ShortenUrl(longUrl);
            shortUrlTask.Wait();
            string shortUrl = shortUrlTask.Result;
            Console.WriteLine("Short URL: " + shortUrl);
            Console.ReadLine();
        }
    }
}
````

*Command*: TestConsole.exe https://github.com/JoseLucas1303/ArticPolar.Dev.BitlyAPI

*Out*: Short URL: bit.ly/(identification)


### _Example_: 

*Command*: TestConsole.exe https://www.youtube.com

*Out*: Short URL: bit.ly/46aLj3u


