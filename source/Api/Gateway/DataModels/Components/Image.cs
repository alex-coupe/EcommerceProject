using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class Image
    {
        public string FilePath { get; set; }

        public string AltText { get; set; }
    }
}
