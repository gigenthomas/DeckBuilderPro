using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        [DisplayName("Game"), Required]
        public string Name { get; set; }

        [DisplayName("Manufacturer"), Range(1, 10, ErrorMessage = "Select Manufacturer")]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public IEnumerable<Manufacturer> Manufacturers { get; set; }
    }
}
