using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        // class which will enable the API calling
        private readonly HttpClient httpClient;

        //controller which will initialize the base address every time the app runs
        public NumbersController() {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://numbersapi.com/")
            };
        }

        //it allows to enter a user input on the swagger while retrieving data
        [HttpGet("{n}")]
        
        //async function so as to wait until we have a response and move forward only when we have a response
        public async Task<string> Get(int n)
        {
            var url = String.Format($"{n}");
            //getting response i.e. Http Status code and the data
            var response = await httpClient.GetAsync(url);
            var stringResponse = "";

            //if status code == 200 then return the response data
            if (response.IsSuccessStatusCode)
            {
                stringResponse = await response.Content.ReadAsStringAsync();
            }
            //else show the status code
            else
            {
                stringResponse = response?.StatusCode.ToString();
            }
            return stringResponse;          
        }
    }
}
