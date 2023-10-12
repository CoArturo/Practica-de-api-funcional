namespace Practica_de_api.Models
{
    public class TemperaturaEstructura
    {
        public double Kelvin { get; set; }
        public double Celsius { get; set; }
        public double Fahrenheit { get; set; }
    }

    public class ConvertidorTemperatura
    {
        public TemperaturaEstructura ConvertirFahrenheitACelsius(double fahrenheit)
        {
            var celsius = (fahrenheit - 32) * 5 / 9;
            var temperatura = new TemperaturaEstructura
            {
                Kelvin = celsius + 273.15,
                Celsius = celsius,
                Fahrenheit = fahrenheit
            };
            return temperatura;
        }

        public TemperaturaEstructura ConvertirKelvinACelsius(double kelvin)
        {
            var celsius = kelvin - 273.15;
            var temperatura = new TemperaturaEstructura
            {
                Kelvin = kelvin,
                Celsius = celsius,
                Fahrenheit = celsius * 9 / 5 + 32
            };
            return temperatura;
        }

        public TemperaturaEstructura ConvertirCelsiusAKelvin(double celsius)
        {
            var kelvin = celsius + 273.15;
            var temperatura = new TemperaturaEstructura
            {
                Kelvin = kelvin,
                Celsius = celsius,
                Fahrenheit = celsius * 9 / 5 + 32
            };
            return temperatura;
        }
    }
}
