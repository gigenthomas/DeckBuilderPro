using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Pager.Interfaces;

namespace DeckBuilderPro.Pager
{
    public class ListPager:IPager
    {
        public ListPager()
        {
            CurrentPage = 1;
            NumberOfItemsPerPage = 30;
            NumberOfPagesToDisplay = 10;
        }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get { return (int)Math.Ceiling((decimal)NumberOfItems / NumberOfItemsPerPage); } }
        public int NumberOfItems { get; set; } 
        public int NumberOfItemsPerPage { get; set; }
        public int NumberOfPagesToDisplay { get; set; }
        
        public int[] GetPagesToDisplay()
        {
            List<int> result = new List<int>();

            if (NumberOfPages < NumberOfPagesToDisplay)
            {
                for (int x = 1; x <= NumberOfPages; x++)
                {
                    result.Add(x);
                }
            }
            else
            {
                var range = NumberOfPagesToDisplay / 2;
                int startNumber = CurrentPage - (range - 1);
                int endNumber = CurrentPage + range;
                if (startNumber < 1)
                {
                    endNumber += Math.Abs(CurrentPage - range);
                    startNumber = 1;
                }
                if (endNumber > NumberOfPages)
                {
                    startNumber -= ((range + CurrentPage) - NumberOfPages);
                    endNumber = NumberOfPages;
                }
                for (int x = startNumber; x <= endNumber; x++)
                {
                    result.Add(x);
                }

            }
            return result.ToArray();
        }
    }
}
