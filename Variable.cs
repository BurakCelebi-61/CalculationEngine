using System;
using System.Collections.Generic;
using System.Data;

namespace CalculationEngine
{
    public class Variable
    {
        public Variable(string name,decimal value)
        {
            Name = name;
            Value = value;
        }
        public decimal Value { get; set; }
        public string Name { get; set; }
    }
}
