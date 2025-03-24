using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages;

public class OperacionesModel : PageModel
{
    private readonly ILogger<OperacionesModel> _logger;

    [BindProperty]
    public DatosOperacion datosOperacion {get; set;}
    private IOperaciones operaciones;

    public OperacionesModel(ILogger<OperacionesModel> logger,
                            DatosOperacion datosOperacion, 
                            IOperaciones operaciones)
    {
        _logger = logger;
        this.datosOperacion = datosOperacion;
        this.operaciones = operaciones;
    }

    public void OnGet()
    {

    }

    public void OnPost() {        
        datosOperacion.resultado = 
             operaciones.ejecutar((double)datosOperacion.op1, 
                                  (double)datosOperacion.op2, 
                                  datosOperacion.operacion);        
    }
}
