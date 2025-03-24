

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

    var datos = {
        op1: xop1,
        op2: xop2,
        operacion: xoperacion
    };

    $.ajax({
        url: "/api/ops",
        type: 'GET',
        data: datos,
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