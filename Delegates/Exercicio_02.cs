namespace lohran_mendes_DR4_AT_S2.Delegates;

public delegate string ActionsDelegate();

public class Exercicio_02
{
    public static void LogToConsole(string message)
    {
        Console.WriteLine("Log to Console: " + message);
    }

    public static void LogToFile(string message)
    {
        Console.WriteLine("Log to File: " + message);
    }

    public static void LogToMemory(string message)
    {
        Console.WriteLine("Log to Memory: " + message);
    }


    public static void AplicarAction(string message)
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