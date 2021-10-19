using System;
using System.Collections.Generic;
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
                // Lambda
                { "Obtener la luna",() => vista.Display($"Caso de uso no implementado") },
            };
    }

    public void Run(){
        try{
            var menu = new List<string>{ "uno","dos"};
            var key =
            _vista.TrySeleccionarOpcionDeListaEnumerada<String>(
                "TITULO",
                menu,
                "Elige una opcion"
            );

            _casosDeUso[key].Invoke();

            _vista.Display($"escogido {key}");
            switch (menu.FindIndex(e => e == key))
            {
                case 1: _vista.Display("Ejecutar el caso de uso 1"); 
                break;

                case 2: _vista.Display("Ejecutar el caso de uso 2"); 
                break;

                case 3: _vista.Display("Ejecutar el cosas nuevas"); 
                break;
            }
        }catch{
            _vista.Display("Agur usuario");
        }
    }
    void CasoDeUso1()
    {

    }
    void CasoDeUso2()
    {

    }
}