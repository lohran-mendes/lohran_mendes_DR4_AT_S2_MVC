namespace lohran_mendes_DR4_AT_S2.Delegates;

public delegate string ActionsDelegate();

public class Exercicio_02
{
    public static void Executar()
    {
        Exercicio_02.AplicarAction("Testando a aplicação...");
    }

    private static void LogToConsole(string message)
    {
        Console.WriteLine("Log to Console: " + message);
    }

    private static void LogToFile(string message)
    {
        Console.WriteLine("Log to File: " + message);
    }

    private static void LogToMemory(string message)
    {
        Console.WriteLine("Log to Memory: " + message);
    }


    private static void AplicarAction(string message)
    {
        Action<string> logAction;
        
        logAction = LogToConsole;
        logAction(message);
        
        logAction = LogToFile;
        logAction(message);
        
        logAction = LogToMemory;
        logAction(message);
    }
}