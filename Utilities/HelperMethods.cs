using Microsoft.VisualStudio.TestTools.UnitTesting;
using PunkAPITest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunkAPITest.Utilities
{
    public class HelperMethods
    {
        /// <summary>
        /// Method to verify whether Id, Name, Description and Abv are not null for all the beers in the response
        /// </summary>
        /// <param name="response"></param>
        public void Validate_IdNameDescriptionAbv_NotNull(IRestResponse<List<BeerModel>> response)
        {
            foreach (BeerModel beer in response.Data)
            {
                Assert.IsNotNull(beer.ID, "The Id of the beer should not be null");
                Assert.IsNotNull(beer.Name, "The Name of the beer should not be null");
                Assert.IsNotNull(beer.Description, "The Description of the beer should not be null");
                Assert.IsNotNull(beer.Abv, "The Abv of the beer should not be null");
            }
        }
    }
}
