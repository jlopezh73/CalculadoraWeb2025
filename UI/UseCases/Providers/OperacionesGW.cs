using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

public class OperacionesGW : IOperaciones {
    HttpClient _cliente;
    public OperacionesGW(IHttpClientFactory httpClientFactory)
    {
        _cliente = httpClientFactory.CreateClient("OperacionesService");        
    }
    public double? ejecutar(double op1, double op2, int operacion) {
        //HttpClient _cliente = new HttpClient();
        //http://localhost:5030
        var url = $"/operacion?op1={op1}&op2={op2}&operacion={operacion}";                        
        var response =  _cliente.GetAsync(url).Result;        
        if (response.IsSuccessStatusCode)
        {            
            var jsonResponse = response.Content.ReadAsStringAsync().Result;            
            var resul = JsonSerializer.Deserialize<ResultadoOperacion>(jsonResponse);            
            return resul.resultado;
        }
        else
        {
            return null;
        }
    }
}