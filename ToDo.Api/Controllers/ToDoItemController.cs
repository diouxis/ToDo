using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    using Models;
    using System.Diagnostics.CodeAnalysis;

    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly ILogger<ToDoItemController> _logger;

        public ToDoItemController(ILogger<ToDoItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Fetch/{id}")]
        public IEnumerable<ToDoItem> List([FromRoute] int id)
        {
            return new ToDoItem[]
            {
                new ToDoItem
                {
                    Id = id,
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

        [HttpGet("hName/{type}")]
        public string? GetName([FromRoute] string type)
        {
            TODoIndex result = new TODoIndex()
            {
                NameA = "a",
                NameB = "b",
                NameC = "c"
            };

            var property = typeof(TODoIndex).GetProperty(type);
            if (property != null)
            {
                return property.GetValue(result) as string;
            }
            return "Name not found";
        }
    }
}