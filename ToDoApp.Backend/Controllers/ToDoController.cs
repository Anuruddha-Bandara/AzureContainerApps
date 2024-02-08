using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Backend.Controllers
{ 
       public class ToDo
       {
           public int Id { get; set; }
           public string Name { get; set; }
           public bool Done { get; set; }
       }

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
       
        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
        List<ToDo> toDoList = new List<ToDo>
        {
            new ToDo { Id = 1, Name = "Complete assignment", Done = false },
            new ToDo { Id = 2, Name = "Buy groceries", Done = true },
            new ToDo { Id = 3, Name = "Read a book", Done = false }
            // Add more ToDo items as needed
        };
        return Ok(toDoList);
    }
    }
}