namespace Practica_de_api.Implementaciones
{
    public class ImplementacionDivisas
    {
        public class DivisaFachada : Fachada.IDivisaFachada
        {
            public Models.DivisasEstructuras ConvertirDolarAPesoDominicano(double dolar)
            {
                var pesoDominicano = dolar * 56; 
                var divisa = new Models.DivisasEstructuras
                {
                    Dolar = dolar,
                    PesoDominicano = pesoDominicano,
                    Euro = dolar * 0.85 
                };
                return divisa;
            }
        }
    }
}
