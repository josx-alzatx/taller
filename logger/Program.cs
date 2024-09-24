using System;
using System.IO;

public class Logger
{
    private static Logger _instance;
    private string _filePath = "log.txt"; // Ruta del archivo de log

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger.Instance.Log("Me gusta el perro.");
        Logger.Instance.Log("No me gusta el pepino.");
    }
}
