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
        private readonly string serviceBaseUrl = "https://localhost:5001/ProcessPayment";

        [SetUp]
        public void Setup()
        {
            AppFactory = new WebApplicationFactory<Startup>();
            _client = AppFactory.CreateClient();
        }

        [TestCase("Book", "Physical", "Online", "£15")]
        [TestCase("Mobile", "Physical", "CashOnDelivery", "£399")]
        [TestCase("video", "virtual", "Online", "£5")]
        [TestCase("NEWMEMBERSHIP", "MEMBERSHIP", "Online", "£25")]
        [TestCase("UPGRADEMEMBERSHIP", "MEMBERSHIP", "Online", "£10")]
        public async Task Given_BusinessRules_Are_Active_When_PaymentFor_Product_With_Available_Rules_Is_Made_Then_Returns_Expected_ResponseAsync(string prodType, string prodSegment, string modeOfPay, string amt)
        {
            string json = JsonConvert.SerializeObject(new { productType = prodType, productSegment = prodSegment, modeOfPayment = modeOfPay, amount = amt });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            
            var result = await _client.PostAsync(serviceBaseUrl, httpContent);
            var responseBody = await result.Content.ReadAsStringAsync();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);            
            Assert.IsFalse(responseBody.Contains("No Applicable Rules Found To Execute"));

        }

        [TestCase("Mobile", "virtual", "Online", "£399")]
        [TestCase("HEALTHCARE", "SERVICE", "Online", "£50")]
        public async Task Given_BusinessRules_Are_Active_When_PaymentFor_Product_With_No_Applicable_Rules_Is_Made_Then_Returns_Blank_Response(string prodType, string prodSegment, string modeOfPay, string amt)
        {
            string json = JsonConvert.SerializeObject(new { productType = prodType, productSegment = prodSegment, modeOfPayment = modeOfPay, amount = amt });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
           
            var result = await _client.PostAsync(serviceBaseUrl, httpContent);
            var res = await result.Content.ReadAsStringAsync();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(res.Contains("No Applicable Rules Found To Execute"));
        }

        [TestCase("CLOTHING", "Empty", "CASHONDELIVERY", "£20")]
        public async Task Given_BusinessRules_Are_Active_When_PaymentFor_Invalid_Product_Is_Made_Then_Returns_Exception(string prodType, string prodSegment, string modeOfPay, string amt)
        {
            string json = JsonConvert.SerializeObject(new { productType = prodType, productSegment = prodSegment, modeOfPayment = modeOfPay, amount = amt });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await _client.PostAsync(serviceBaseUrl, httpContent);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

    }
}