using System;
using System.Collections.Generic;

// Interfaz Observer que define el método UpdateData
public interface IObserver
{
    void UpdateData(string message);
}

// Clase Subject que gestiona la lista de Observers y notifica los cambios
public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    // Método para agregar un observador
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    // Método para eliminar un observador
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    // Método para notificar a todos los observadores
    public void NotifyObservers(string message)
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateData(message);
        }
    }

    // Simula un cambio de estado
    public void ChangeState(string newState)
    {
        Console.WriteLine($"[Subject]: Cambié mi estado a: {newState}");
        NotifyObservers(newState); // Notifica a los observadores
    }
}

// Clase Observer concreta que implementa la interfaz IObserver
public class ConcreteObserver : IObserver
{
    private string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    // Implementación del método UpdateData de la interfaz
    public void UpdateData(string message)
    {
        Console.WriteLine($"[Observer {name}]: Recibí una actualización: {message}");
    }
}

// Programa principal
public class Program
{
    public static void Main(string[] args)
    {
        // Crear el objeto sujeto (Subject)
        Subject subject = new Subject();

        // Crear observadores
        ConcreteObserver observer1 = new ConcreteObserver("Observador 1");
        ConcreteObserver observer2 = new ConcreteObserver("Observador 2");
        ConcreteObserver observer3 = new ConcreteObserver("Observador 3");

        // Agregar observadores al sujeto
        subject.AddObserver(observer1);
        subject.AddObserver(observer2);
        subject.AddObserver(observer3);

        // Cambiar el estado del sujeto y notificar a los observadores
        subject.ChangeState("Estado 1");

        // Eliminar un observador
        subject.RemoveObserver(observer2);

        // Cambiar el estado del sujeto nuevamente y notificar a los observadores
        subject.ChangeState("Estado 2");

        Console.ReadKey();
    }
}
