using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface IDataCache<T>
    {
        public bool Valid { get; set; }
        public T Cache { get; set; }
    }
}
