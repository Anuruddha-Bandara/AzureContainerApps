using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ToDoApp.Frontend.Models;

namespace ToDoApp.Frontend.Controllers
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Make a GET request to the API endpoint
                    HttpResponseMessage response = await client.GetAsync("https://todo-backend.internal.whitebay-49755c67.southeastasia.azurecontainerapps.io/ToDo");

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the response content
                        string content = await response.Content.ReadAsStringAsync();
                        List<ToDo> toDoList = JsonConvert.DeserializeObject<List<ToDo>>(content);
                        ViewBag.todo = toDoList;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}