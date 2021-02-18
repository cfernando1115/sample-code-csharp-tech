using System;

namespace SampleCodeTech
{
    public abstract class TemperatureSet
    {
        protected ILogger _logger;
        protected float? C { get; set; }
        protected float? F { get; set; }

        public abstract void ConvertCtoF();
        public abstract void ConvertFtoC();
        public TemperatureSet(ILogger logger)
        {
            _logger = logger;
        }

        public void ConvertBoth()
        {
            if (C is null || F is null)
            {
                _logger.Log("Cannot convert unassigned temperatures");
                throw new NullReferenceException();
            }

            //DOWNCAST TO TEMPERATURE

            var temp=this as Temperature;
            temp.ConvertCtoF();
            temp.ConvertFtoC();
        }
    }

    public class Temperature : TemperatureSet
    {
        public Temperature(ILogger logger)
            : base(logger)
        {
        }

        public void SetCelsius(float c)
        {
            C = c;
        }

        public void SetFahrenheit(float f)
        {
            F = f;
        }

        public override void ConvertCtoF()
        {
            var convertToF = C * 1.8000 + 32.00;
            _logger.Log(C + " to Fahrenheit: " + convertToF);
        }

        public override void ConvertFtoC()
        {
            var convertToC = (F - 32) / 1.8000;
            _logger.Log(F + " to Celsius: " + convertToC);
        }
    }
}
