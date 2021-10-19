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
            var opc =
            _vista.TrySeleccionarOpcionDeListaEnumerada<String>(
                "TITULO",
                new List<string>{ "uno","dos"},
                "Elige una opcion"
            );
    }
    void CasoDeUso1()
    {

    }
    void CasoDeUso2()
    {

    }
}