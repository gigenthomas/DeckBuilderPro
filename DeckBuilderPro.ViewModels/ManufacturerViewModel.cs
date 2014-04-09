using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DeckBuilderPro.Entity;

namespace DeckBuilderPro.ViewModels
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }

        [DisplayName("Manufacturer"), Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
