using CodeTest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private void SendMessage()
        {            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56851/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var message = new Message()
                {
                    Text = "Hello World!",
                    Owner = new Person()
                    {  
                      FirstName = "Andreas",
                      LastName = "Fransson",
                      Email = "andreas.fransson@gmail.com"
                    },
                    DateCreated = DateTime.Now
                };
            var parameter = JsonConvert.SerializeObject(message);
            HttpContent content = new StringContent(parameter, Encoding.UTF8, "application/json");
            
            var response = client.PostAsync("api/User", content).Result;

            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("Message sent! Please refresh your browser.");                
            }
            else
            {
                System.Console.WriteLine("An error ocurred. Status code: " + response.StatusCode + " - Message: " + response.ReasonPhrase);
            }
        }
    }
}
