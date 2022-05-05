using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DomainModel
{
    public class ResponseData
    {
        public List<CarData> Car { get; set; }
        public int CollectionSize { get; set; }
    }
}
