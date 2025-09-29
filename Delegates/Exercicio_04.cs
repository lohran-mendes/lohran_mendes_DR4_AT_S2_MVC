namespace lohran_mendes_DR4_AT_S2.Delegates;

public class Exercicio_04
{
    public static void Executar()
    {
        var a1 = new ClienteReservado("Lohran Mendes");
        var a2 = new ClienteReservado("Maria Eduarda");
        var a3 = new ClienteReservado("Anna Beatriz");

        var emissorDeAlerta = new ReservaDoClienteReservado();
        emissorDeAlerta.EventPublicarMensagem += a1.Notificacao;
        emissorDeAlerta.EventPublicarMensagem += a2.Notificacao;
        emissorDeAlerta.EventPublicarMensagem += a3.Notificacao;
        emissorDeAlerta.NotificarClientes("Limites de Reservas ultrapassadas!");
    }
}

public class ClienteReservado(string nome)
{
    private string Nome { get; } = nome;

    public void Notificacao(string mensagem)
    {
        Console.WriteLine($"{Nome} recebeu a mensagem: {mensagem}");
    }
}

public delegate void CapacityReached (string mensagem);

public class ReservaDoClienteReservado
{
    public event CapacityReached ? EventPublicarMensagem;

    public void NotificarClientes(string mensagem)
    {
        Console.WriteLine("Notificando clientes...");
        if (EventPublicarMensagem != null)
        {
            EventPublicarMensagem(mensagem);
        }
        else
        {
            Console.WriteLine("Nenhum assinante registrado.");
        }
    }
}