﻿using System;
using System.Runtime.Remoting.Channels;
using Microsoft.Owin.Hosting;

namespace BoerCom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            const string url = "http://127.0.0.1:8080";

            using (WebApp.Start(url))
            {
                Console.WriteLine($"Server running on {url}");
                Console.ReadLine();
            }
        }
    }
}
