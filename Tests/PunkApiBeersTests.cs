using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PunkAPITest.Models;
using PunkAPITest.Utilities;
using RestSharp;
using RestSharp.Serialization.Json;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace PunkAPITest
{
    [TestClass]
    public class PunkApiBeersTests
    {
        [TestMethod, TestCategory("Smoke Test")]
        public void Verify_GetAllBeers_Returns_Success()
        {
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers();
            
            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [TestMethod, TestCategory("Regression Test")]
        public void Verify_GetAllBeers_ResponseHasIdNameDescriptionAbv()
        {
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers();

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Verify Id, Name, Description and Abv is not null for all the beers in the response by calling the helper method
            HelperMethods helperMethods = new HelperMethods();
            helperMethods.Validate_IdNameDescriptionAbv_NotNull(response);
        }

        [TestMethod, TestCategory("Regression Test")]
        public void Verify_GetAllBeersBrewedBeforeDate_Returns_BeersBrewedBeforeGivenDate()
        {
            string queryString = "brewed_before=\"10/2007\"";
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            DateTime brewedBefore = DateTime.Parse("10/2007");
            //Verify that the First_brewed_date for all the beers are greater than the given Brewed_Before_Date
            foreach (BeerModel beer in response.Data)
            {
                Assert.IsTrue(0 > (DateTime.Compare(beer.FirstBrewed, brewedBefore)), "The First_brewed_date is greater than the given Brewed_Before_Date");
            }
        }
                
        [TestMethod, TestCategory("Regression Test")]
        public void Verify_GetAllBeersBrewedBeforeDate_ResponseHasIdNameDescriptionAbv()
        {
            string queryString = "brewed_before=\"10/2007\"";
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Verify Id, Name, Description and Abv is not null for all the beers in the response by calling the helper method
            HelperMethods helperMethods = new HelperMethods();
            helperMethods.Validate_IdNameDescriptionAbv_NotNull(response);
        }

        [TestMethod, TestCategory("Smoke Test")]
        public void Verify_GetAllBeersWithAbvGreaterThanSix_Returns_Success()
        {
            string queryString = "abv_gt=6";
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod, TestCategory("Regression Test")]
        public void Verify_GetAllBeersWithAbvGreaterThanSix_Returns_OnlyBeersWithAbvGreaterThanSix()
        {
            int abvCount = 6;
            string queryString = "abv_gt="+abvCount;
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Verify that the abv of all the beers in the response are greater than 6
            foreach (BeerModel beer in response.Data)
            {
                Assert.IsTrue(beer.Abv > abvCount, "The Abv of the beer should be greater than 6");
            }
        }
        
        [TestMethod, TestCategory("Regression Test")]
        public void Verify_GetAllBeersWithAbvGreaterThanSix_ResponseHasIdNameDescriptionAbv()
        {
            int abvCount = 6;
            string queryString = "abv_gt=" + abvCount;
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Verify Id, Name, Description and Abv is not null for all the beers in the response
            HelperMethods helperMethods = new HelperMethods();
            helperMethods.Validate_IdNameDescriptionAbv_NotNull(response);
        }
        
        [TestMethod, TestCategory("Regression Test")]
        public void Verify_Pagination_WorksAsExpected()
        {
            string queryString = "page=2&per_page=5";
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Verify whether it returns 5 items 
            Assert.AreEqual(5, response.Data.Count);
        }
        
        [TestMethod, TestCategory("Regression Test")]
        public void Verify_PaginationWorks_ResponseHasIdNameDescriptionAbv()
        {
            string queryString = "page=2&per_page=5";
            BeerRequestClass beerRequestClass = new BeerRequestClass();
            IRestResponse<List<BeerModel>> response = beerRequestClass.GetAllBeers(queryString);

            //Verify that the response is not null
            Assert.IsNotNull(response);

            //Verify the StatusCode is Success
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            //Verify Id, Name, Description and Abv is not null for all the beers in the response
            HelperMethods helperMethods = new HelperMethods();
            helperMethods.Validate_IdNameDescriptionAbv_NotNull(response);
        }
        
    }
}
