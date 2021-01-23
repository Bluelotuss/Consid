using System;

namespace ConsidSite.Models
{
    public class AppSecrets
    {
        public string GoogleAPIkey { get; set; }

        public AppSecrets()
        {
            GoogleAPIkey = "YOUR_API_KEY_HERE";
        }
    }
}
