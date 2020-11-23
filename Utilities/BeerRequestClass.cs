using PunkAPITest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PunkAPITest.Utilities
{
    public class BeerRequestClass
    {
        string baseUrl;
        RestClient restClient; 

        public BeerRequestClass()
        {
            Configs configs = new Configs();
            baseUrl = configs.getBaseUrl();
            restClient = new RestClient(baseUrl);
        }

        /// <summary>
        /// Method to create the request and execute it
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public IRestResponse<List<BeerModel>> GetAllBeers(string queryString = null)
        {
            //Using RestRequest creates a new request to a specified URL
            RestRequest restRequest = new RestRequest("v2/beers", Method.GET);

            //Splitting the querystring with '&' and then with '=' and adding those parameters to the request 
            if (queryString != null)
            {
                string[] argList = queryString.Split('&');
                foreach (string arg in argList)
                {
                    string[] values = arg.Split('=');
                    restRequest.AddParameter(values[0], values[1]);   //AddParameter will add a new parameter to the request
                }
            }
            //The command Execute will execute the request
            return restClient.Execute<List<BeerModel>>(restRequest);
        }
    }
}
