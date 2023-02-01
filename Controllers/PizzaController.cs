using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : Controller
{
    private readonly ILogger<PizzaController> _logger;

    public PizzaController(ILogger<PizzaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaServices.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetById(int id){
        var pizza = PizzaServices.Get(id);
        if (pizza == null)
            return NotFound(); //Tratamento de exceção caso o id não seja encontrado
        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create (Pizza pizza){
       PizzaServices.Add(pizza);
       PizzaServices.Update(pizza);

       return (IActionResult)pizza;
    }

    // PUT action

    // DELETE action

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}