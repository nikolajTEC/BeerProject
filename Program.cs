namespace BeerProject
{
    enum BeerType { LAGER, PILSNER, MÜNCHENER, WIENERDORTMUNDER, BOCK, DOBBELBOCK, PORTER, MIX}
    internal class Program
    {
        static void Main(string[] args)
        {
            Beer beer1 = new Beer("Tuborg", "Tuborg grøn", BeerType.PILSNER, 33, 4.5);
            Beer beer2 = new Beer("Carlsberg", "Carlsberg", BeerType.PILSNER, 33, 4.5);
            Beer beer3 = new Beer("Skanderborg Bryghus", "Münchener dunkel", BeerType.MÜNCHENER, 33, 5.5);
            Console.WriteLine($"{beer1}\n {beer2}\n{beer3}");
            Console.WriteLine($"\nbeer1 units ={beer1.GetUnits()}");
            Console.WriteLine($"\nbeer3 units ={beer3.GetUnits()}");
            beer1.Add(beer3);
            Console.WriteLine($"\nbeer 1 with added beer 3{beer1}");

            Beer beer4 = beer1.Mix(beer2);

            Beer beer5 = Beer.Mix(beer1, beer2 );
            Console.WriteLine($"\nbeer 1 mixed with beer2 {beer4}");


            List<Beer> beers = new List<Beer>();
            beers.Add(beer1);
            beers.Add(beer2);
            beers.Add(beer3);
            beers.Sort();
            Console.WriteLine($"\nsorted by units: ");
            foreach (Beer beer in beers)
                Console.WriteLine($"\n{beer}");


            Beer[] beerArray = beers.ToArray();
            Array.Sort(beerArray, new SortingBeerBy(SortBy.UNIT));
            Console.WriteLine($"\nsorted by unit:");
            foreach (Beer beer in beerArray)
                Console.WriteLine($"\n{beer}");

            Array.Sort(beerArray, new SortingBeerBy(SortBy.PERCENT));
            Console.WriteLine($"\nsorted by percent:");
            foreach (Beer beer in beerArray)
                Console.WriteLine($"\n{beer}");

            Array.Sort(beerArray, new SortingBeerBy(SortBy.VOLUME));
            Console.WriteLine($"\nsorted by volume:");
            foreach (Beer beer in beerArray)
                Console.WriteLine($"\n{ beer}");

        }
    }
}
