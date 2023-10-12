namespace Practica_de_api.Implementaciones
{
    public class ImplementacionTemperatura
    {
        public class TemperaturaFachada : Fachada.ITemperaturaFachada
        {
            private readonly Models.ConvertidorTemperatura convertidor;

            public TemperaturaFachada()
            {
                convertidor = new Models.ConvertidorTemperatura();
            }

            public Models.TemperaturaEstructura ConvertirFahrenheitACelsius(double fahrenheit)
            {
                return convertidor.ConvertirFahrenheitACelsius(fahrenheit);
            }
        }
    }
}
