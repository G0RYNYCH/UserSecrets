using Microsoft.AspNetCore.Mvc;

namespace UserSecrets.Controllers;
[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> logger;
    private readonly IConfiguration configuration;

    public Controller(
        ILogger<Controller> logger,
        IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;
    }

    [HttpGet(Name = "GetCOnfiguration")]
    public IActionResult Get()
    {
        var connectionString = configuration.GetValue<string>("ConnectionString");
        var token = configuration.GetValue<string>("Token");
        var port = configuration.GetValue<string>("Port");

        var result = $"ConnectionString: {connectionString}\n" +
            $"Token: {token}\n" +
            $"Port: {port}";

        return Ok(result);
    }
}
