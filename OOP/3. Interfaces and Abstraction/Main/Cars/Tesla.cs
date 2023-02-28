using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : IElectricCar,ICar
    {
        public Tesla(string model,string color, int battery)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }

        public int Battery { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries\n{Start()}\n{Stop()}";
        }
    }
}
