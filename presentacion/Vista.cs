using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
class Vista
{
    const string CANCELINPUT = "fin";

    public void Display(Object msg) => WriteLine(msg.ToString());
    public void MuestraPrompt(String msg) => Write($"{msg.Trim()}: ");
    // c# Generics
    public T TryObtenerEntradaDeTipo<T>(string prompt)
    {
        while (true)
        {
            MuestraPrompt(prompt);
            var input = Console.ReadLine();
            // c# throw new Exception: Lanzamos una Excepción para indicar que el usuario ha cancelado la entrada
            if (input.ToLower().Trim() == CANCELINPUT) throw new Exception("Entrada cancelada por el usuario");
            try
            {
                // c# Reflexion
                // https://stackoverflow.com/questions/2961656/generic-tryparse?rq=1
                var valor = TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(input);
                return (T)valor;
            }
            catch (Exception e)
            {
                if (input != "") Display($"Error: '{input}' no reconocido como entrada permitida");
            }
        }
    }
    public void MostrarListaEnumerada<T>(string titulo, List<T> valores)
    {
        Display(titulo);
        for (int i = 0; i < valores.Count; i++)
        {
            WriteLine($"{i + 1:##}.- {valores[i].ToString()}");
        }
    }
    public T TrySeleccionarOpcionDeListaEnumerada<T>(string titulo, List<T> lista, string prompt)
    {
        MostrarListaEnumerada(titulo, lista);
        int input = 0;
        while (input < 1 || input > lista.Count)
            try
            {
                input = TryObtenerEntradaDeTipo<int>(prompt);
            }
            catch (Exception e)
            {
                throw e;
            };
        return lista.ElementAt(input - 1);
    }
}