using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsStore.Domain.Entities
{
    public class ShippingDetails
    {
            [Required(ErrorMessage = "Please enter a name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Please enter the first address line")]
            [Display(Name = "Line 1")]
            public string Line1 { get; set; }
            [Display(Name = "Line 2")]
            public string Line2 { get; set; }
            [Display(Name = "Line 3")]
            public string Line3 { get; set; }

            [Required(ErrorMessage = "Please enter a town name")]
            public string Town { get; set; }

            [Required(ErrorMessage = "Please enter a county name")]
            public string County { get; set; }

            public string Postcode { get; set; }

            [Required(ErrorMessage = "Please enter a country name")]
            public string Country { get; set; }

            public bool GiftWrap { get; set; }
    }
}



