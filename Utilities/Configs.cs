using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PunkAPITest.Utilities
{
    public class Configs
    {
        /// <summary>
        /// Dictionary with environment name and the corresponding url
        /// </summary>
        Dictionary<string, string> envUrlList = new Dictionary<string, string>()
        {
            { "prod", "https://punkapi.com/" },
            { "qa", "https://api.punkapi.com/" }
        };

        /// <summary>
        /// Function to get the Base URL
        /// It calls the getEnv(), get the environment variable and returns the corresponding Base URL from the dictionary
        /// </summary>
        /// <returns>
        /// Returns the Base URL
        /// </returns>
        public string getBaseUrl()
        {
            string env = getEnv();
            return envUrlList[env];
        }

        /// <summary>
        /// Function to get the Environment variable
        /// If the Environment variable is null, then it defaults to "qa"
        /// </summary>
        /// <returns>
        /// Returns the Environment variable
        /// </returns>
        public string getEnv()
        {
            string env = Environment.GetEnvironmentVariable("env");
            if(String.IsNullOrEmpty(env))
            {
                env = "qa";
                Console.WriteLine("Unable to find the environment variable. Defaulting the value to qa.");
            }
            return env;
        }
    }
}
