using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

[ApiController]
[Route("api/ops")]
public class OpsController : ControllerBase
{    
    private ILogger<OpsController> _logger;
    private IOperaciones _operaciones;

    public OpsController(ILogger<OpsController> logger, IOperaciones operaciones)
    {
        _logger = logger; 
        _operaciones = operaciones;
    }

    [HttpGet]
    public IActionResult Operacion(double op1, double op2, int operacion)
    {        
        double? resultado = _operaciones.ejecutar(op1, op2, operacion);
        return new JsonResult(new {resultado=resultado});
    }
}
