using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.ProductService
{
    public class CategoryTransferObject
    {
        public string MainCategory { get; set; }

        public IEnumerable<string> SubCategories { get; set; }
    }
}
