﻿using Facility.Interfaces;

namespace Facility.Tables
{
    public class OrdinaryTable : ITable
    {
        public string Name { get; set; }
        public List<ITableLeg> TableLegs { get; }
        public ITableTop TableTop { get; }
        public double Price { get; }

        public OrdinaryTable(string name, ITableTop top, params ITableLeg[] legs)
        {
            Name = name;
            TableLegs = new List<ITableLeg>();
            double priceForLegs = 0;
            foreach (ITableLeg leg in legs)
            {
                TableLegs.Add(leg);
                priceForLegs += leg.Price;
            }
            TableTop = top;
            Price = top.Price + priceForLegs;
        }

        public double GetPriceForBuild() => Price;
    }
}
