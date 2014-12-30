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
        private const string BASEADDRESS = "http://localhost:58554/";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Getting all messages...");
            Task t1 = new Task(GetMessages);
            t1.Start();
            t1.Wait(5000);

            System.Console.WriteLine("Posting a new message...");
            Task t2 = new Task(SendMessage);
            t2.Start();
            t2.Wait();

            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadLine();

        }

        private static async void GetMessages()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASEADDRESS);
                
                using (HttpResponseMessage response = await client.GetAsync("api/message"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        if (result != null)
                        {
                            System.Console.WriteLine(result);
                        }
                    }
                }
            }
        }

        private static async void SendMessage()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASEADDRESS);
                client.DefaultRequestHeaders.Accept.Clear();
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
                using (HttpResponseMessage response = await client.PostAsync("api/message", content))
                {
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
    }
}
