namespace Practica_de_api.Models
{
    public class DivisasEstructuras
    {
        public double Dolar { get; set; }
        public double PesoDominicano { get; set; }
        public double Euro { get; set; }
    }

    public class ConvertidorDivisas
    {
        public DivisasEstructuras ConvertirDolarAPesoDominicano(double dolar)
        {
            var pesoDominicano = dolar * 56; 
            var divisa = new DivisasEstructuras
            {
                Dolar = dolar,
                PesoDominicano = pesoDominicano,
                Euro = dolar * 0.85 
            };
            return divisa;
        }

        public DivisasEstructuras ConvertirPesoDominicanoADolar(double pesoDominicano)
        {
            var dolar = pesoDominicano / 56; 
            var divisa = new DivisasEstructuras
            {
                Dolar = dolar,
                PesoDominicano = pesoDominicano,
                Euro = dolar * 0.85
            };
            return divisa;
        }

        public DivisasEstructuras ConvertirEuroADolar(double euro)
        {
            var dolar = euro / 0.85;
            var divisa = new DivisasEstructuras
            {
                Dolar = dolar,
                PesoDominicano = dolar * 60, 
                Euro = euro
            };
            return divisa;
        }
    }
}
