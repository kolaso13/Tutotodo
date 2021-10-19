using System;
using System.Collections.Generic;

using System.Linq;
class Controlador
{
    private Sistema _sistema;
    private Vista _vista;
    Dictionary<string, Action> _casosDeUso;

    public Controlador(Sistema sistema, Vista vista)
    {
        this._sistema = sistema;
        this._vista = vista;
        this._casosDeUso = new Dictionary<string, Action>(){
                // Action = Func sin valor de retorno
                { "Caso de Uso 1", CasoDeUso1 },
                { "Caso de Uso 2", CasoDeUso2 },
                {"PruebasDeObtenerEntradaDeTipo", PruebasDeObtenerEntradaDeTipo },
                // Lambda
                { "Obtener la luna",() => vista.Display($"Caso de uso no implementado") },
            };
    }

    public void Run()
    {
        try
        {
            while (true)
            {
                var key =
                _vista.TrySeleccionarOpcionDeListaEnumerada<string>(
                    "TITULO DE APLICACION", _casosDeUso.Keys,
                    "Selecciona un CASO DE USO"
                );
                _casosDeUso[key].Invoke();
            }
        }
        catch
        {
            _vista.Display("Agur usuario");
        }

    }
    void CasoDeUso1()
    {
        _vista.Display("CASO DE USO 1");
    }
    void CasoDeUso2()
    {
        _vista.Display("CASO DE USO 2");
    }

    void PruebasDeObtenerEntradaDeTipo()
        {
            try
            {

                var i = _vista.TryObtenerEntradaDeTipo<int>("un int");
                var j = _vista.TryObtenerEntradaDeTipo<int>("un int");
                var data = new DataModel{
                    a = i,
                    b = j
                };

                var res = _sistema.Metodo1(data);
                _vista.Display($"El resultado es {res}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
}