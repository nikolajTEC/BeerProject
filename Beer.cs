using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{
    internal class Beer : IComparable<Beer>
    {
        string brewery;
        string beerName;
        BeerType beerType;
        int volume;
        double percent;

        public string Brewery { get => brewery; set => brewery = value; }
        public string BeerName { get => beerName; set => beerName = value; }
        public int Volume { get => volume; set => volume = value; }
        public double Percent { get => percent; set => percent = Math.Round(value, 2); }
        internal BeerType BeerType { get => beerType; set => beerType = value; }
        public Beer()
        {
            
        }

        public Beer(string brewery, string beerName, BeerType beerType, int volume, double percent)
        {
            this.Brewery = brewery;
            this.BeerName = beerName;
            this.BeerType = beerType;
            this.Volume = volume;
            this.Percent = percent;
        }
        public double GetUnits()
        {
            return Volume * Percent / 150;
        }

        public override string ToString()
        {
            return $"Brewery: {Brewery}, Beer Name: {BeerName}, Beer Type: {BeerType}, Volume: {Volume} ml, Alcohol Percentage: {Percent}%";
        }

        public void Add(Beer beer)
        {
            BeerName = $"{BeerName}, {beer.BeerName} ";
            Brewery = $"{Brewery}, {beer.Brewery} ";
            BeerType =  BeerType.MIX;
            Volume += beer.Volume;
            Percent = (Volume * Percent + beer.Volume * beer.Percent) / (Volume + beer.Volume);
        }
        public Beer Mix(Beer beer)
        {
            Beer newBeer = new Beer();
            newBeer.BeerName = $"{BeerName}, {beer.BeerName} ";
            newBeer.Brewery = $"{Brewery}, {beer.Brewery} ";
            newBeer.BeerType = BeerType.MIX;
            newBeer.Volume += beer.Volume;
            newBeer.Percent = (Volume * Percent + beer.Volume * beer.Percent)/(Volume + beer.Volume);
            return newBeer ;
        }
        public static Beer Mix(Beer beer1, Beer beer2)
        {
            Beer newBeer = new Beer();
            newBeer.BeerName = $"{beer1.BeerName}, {beer2.BeerName} ";
            newBeer.Brewery = $"{beer1.Brewery}, {beer2.Brewery} ";
            newBeer.BeerType = BeerType.MIX;
            newBeer.volume += beer2.Volume;
            newBeer.percent = (beer1.Volume * beer1.Percent + beer2.Volume * beer2.Percent) / (beer1.Volume + beer2.Volume);
            return newBeer;
        }

        public int CompareTo(Beer? beer)
        {
           return GetUnits().CompareTo(beer.GetUnits());
        }
    }
}
