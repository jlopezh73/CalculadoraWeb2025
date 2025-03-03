public class Operaciones : IOperaciones{
    public double? ejecutar(double op1, double op2, int operacion) {
        switch(operacion) {
            case 1: 
                return op1 + op2;
            case 2:
                return op1 - op2;
            case 3:
                return op1 * op2;
            case 4:
                return op1 / op2;
            default:
                return null; 
        }
    }
}