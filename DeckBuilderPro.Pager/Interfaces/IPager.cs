using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckBuilderPro.Pager.Interfaces
{
    public interface IPager
    {
        int CurrentPage { get; set; }
        int NumberOfPages { get; }
        int NumberOfItems { get; set; }
        int NumberOfItemsPerPage { get; set; }
        int NumberOfPagesToDisplay { get; set; }
        int[] GetPagesToDisplay();

    }
}
