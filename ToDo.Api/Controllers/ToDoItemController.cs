using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    using Models;

    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly ILogger<ToDoItemController> _logger;

        public ToDoItemController(ILogger<ToDoItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetToDoItems")]
        public IEnumerable<ToDoItem> List()
        {
            return new ToDoItem[]
            {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Test 1",
                    StartDate = DateTime.Now.AddHours(-1),
                    FinishDate = DateTime.Now
                },
                new ToDoItem
                {
                    Id = 2,
                    Name = "Test 2",
                    StartDate = DateTime.Now
                }
            };
        }
    }
}