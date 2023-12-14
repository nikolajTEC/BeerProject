using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerProject
{
    internal class SortingBeerBy : IComparer<Beer>
    {
        SortBy sortBy;
        public SortingBeerBy(SortBy sort)
        {
            sortBy = sort;
        }
        public int Compare(Beer? x, Beer? y)
        {
            switch (sortBy)
            {
                case SortBy.UNIT:
                    double unitCompareValue = (x.GetUnits() - y.GetUnits()) * 100;
                    return (int)Math.Round(unitCompareValue);

                case SortBy.PERCENT:
                    double percentCompareValue = y.Percent - x.Percent;
                    return (int)Math.Round(percentCompareValue * 100);

                case SortBy.VOLUME:
                    return x.Volume - y.Volume;

                default:
                    return 0;
            }
        }
    }
}
