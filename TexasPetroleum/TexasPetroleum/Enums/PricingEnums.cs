using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TexasPetroleum.Enums
{
    public class PricingEnums
    {
        public enum Seasons
        {
            [Display(Name="Summer")]
            March,
            April,
            May,
            June,
            July,
            August,
            [Display(Name="Winter")]
            September,
            October,
            November,
            December,
            January,
            February
        }
    }
}