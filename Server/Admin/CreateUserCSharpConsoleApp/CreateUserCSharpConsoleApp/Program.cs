using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUserCSharpConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:8000");
            var request = new RestRequest("/api/consumers", Method.PUT);
            request.AddQueryParameter("name", "Test User 1");
            var response = client.Execute(request);
            var content = response.Content;
        }
    }
}
