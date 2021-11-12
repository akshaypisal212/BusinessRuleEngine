using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using PaymentMS;

namespace PaymentMSTest
{
    public class Tests
    {
        private WebApplicationFactory<Startup> AppFactory { get; set; }
        private HttpClient _client;
        private readonly string serviceBaseUrl = "https://localhost:5001/Payment";

        [SetUp]
        public void Setup()
        {
            AppFactory = new WebApplicationFactory<Startup>();
            _client = AppFactory.CreateClient();
        }

        [Test]
        public async Task Given_BusinessRules_Are_Active_When_PaymentFor_Product_With_Available_Rules_Is_Made_Then_Returns_Expected_ResponseAsync()
        {
            string json = JsonConvert.SerializeObject(new { productType = "book", productSegment = "physical", modeOfPayment = "online", amount = "£10" });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(serviceBaseUrl, httpContent);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}