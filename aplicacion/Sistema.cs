using System.Collections.Generic;
class Sistema
{
    // Datos
    List<int> data = new();

    // Metodos de en lenguaje empresarial
    public int SumaDataOno( DataModel data ){
        if(data.a>7) return -3;
        if(data.SonIguales()) return 5;
     
        return data.a + data.b;
    }

}