

function realizarOperacion() {
    let xop1 = $("#op1").val(); 
    let xop2 = $("#op2").val(); 
    var xresultado=0;
    if ($("#opSumar").prop("checked"))
       xresultado=new Number(xop1)+new Number(xop2)
    else if ($("#opRestar").prop("checked"))
       xresultado=new Number(xop1)-new Number(xop2)
    else if ($("#opMultiplicar").prop("checked"))
       xresultado=new Number(xop1)*new Number(xop2)
    else if ($("#opDividir").prop("checked"))
       xresultado=new Number(xop1)/new Number(xop2)

    $.ajax("http://localhost:5030/operacion?op1="+xop1+"&op2="+xop2+"&operacion="+xoperacion, success:function() {$("#resultado").html(xresultado);});

    
  }