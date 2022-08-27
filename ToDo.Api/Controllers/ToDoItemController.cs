using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    using Models;

    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ToDoItemController> _logger;
        private readonly ToDoName _todoName;

        public ToDoItemController(ILogger<ToDoItemController> logger, IConfiguration configuration, ToDoName todoName)
        {
            _logger = logger;
            _configuration = configuration;
            _todoName = todoName;
        }

        [HttpGet("Fetch/{id}")]
        public IEnumerable<ToDoItem> List([FromRoute] int id)
        {
            string itemName = _configuration.GetValue<string>("ItemName");
            return new ToDoItem[]
            {
                new ToDoItem
                {
                    Id = id,
                    Name = itemName,
                    StartDate = DateTime.Now.AddHours(-1),
                    FinishDate = DateTime.Now
                },
                new ToDoItem
                {
                    Id = 2,
                    Name = _todoName.DefaultName ?? "Default",
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