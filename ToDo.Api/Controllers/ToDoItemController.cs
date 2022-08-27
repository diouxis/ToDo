using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers
{
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using ViewModel;

    [ApiController]
    [Route("[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ToDoItemController> _logger;
        private readonly ToDoContext _context;
        private readonly ToDoName _todoName;

        public ToDoItemController(ILogger<ToDoItemController> logger, IConfiguration configuration, ToDoName todoName, ToDoContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _todoName = todoName;
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ToDoItem?> Get([FromRoute] int id)
        {
            var result = await _context.ToDoItems
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        [HttpGet("Fetch/{id}")]
        public IEnumerable<ToDoItemView> Fetch([FromRoute] int id)
        {
            string itemName = _configuration.GetValue<string>("ItemName");
            var results =  new ToDoItemView[]
            {
                new ToDoItemView
                {
                    Id = id,
                    Name = itemName,
                    StartDate = DateTime.Now.AddHours(-1),
                    FinishDate = DateTime.Now,
                    Order = 1
                },
                new ToDoItemView
                {
                    Id = 2,
                    Name = _todoName.DefaultName ?? "Default",
                    StartDate = DateTime.Now,
                    Order = 2
                }
            };

            return results;
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