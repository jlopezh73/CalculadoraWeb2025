

  function realizarOperacion() {
    let xop1 = $("#op1").val(); 
    let xop2 = $("#op2").val(); 
    var xresultado=0;
    if ($("#opSumar").prop("checked"))
       xoperacion = 1;
    else if ($("#opRestar").prop("checked"))
       xoperacion = 2;
    else if ($("#opMultiplicar").prop("checked"))
       xoperacion = 3;
    else if ($("#opDividir").prop("checked"))
       xoperacion = 4;

    
    $.ajax({
        url: "http://localhost:5030/operacion",
        type: 'GET',
        data: {
            op1: xop1,
            op2: xop2,
            operacion: xoperacion
        },
        success: function (datos) {
            console.log('Respuesta del servicio web:', datos);
            xresultado = datos.resultado;
            $("#resultado").html(xresultado)
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
    
  }