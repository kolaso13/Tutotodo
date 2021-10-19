class DataModel {
    public int a;
    public int b;
    public  bool SonIguales() => a == b;
}
var i = _vista.TryObtenerEntradaDeTipo<int>("un int");
            var i2 = _vista.TryObtenerEntradaDeTipo<int>("un int2");
            var data = new DataModel
            {
                a = i,
                b = i2
            };
            var result = _sistema.SumaDataOno(data);
            _vista.Display($"El resultado es {result}");