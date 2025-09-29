namespace lohran_mendes_DR4_AT_S2.Delegates;

public class Exercicio_03
{
    // Como mencionado no AT, não tem reserva no PacoteTuristico, então não tem como implementar o delegate aqui.

    private Func<int, int, decimal> CalcularDiariaTotal;
    
    public decimal CalcularTotalDiarias(int numeroDeDias, int quantidadeDePessoas)
    {
        CalcularDiariaTotal = (dias, pessoas) => dias * pessoas * 100m; // O custo por pessoa por dia seja 100
        return CalcularDiariaTotal(numeroDeDias, quantidadeDePessoas);
    }
}