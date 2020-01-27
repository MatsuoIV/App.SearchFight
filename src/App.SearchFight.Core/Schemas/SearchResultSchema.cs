using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.SearchFight.Core.Schemas
{
    public class SearchResultSchema
    {
        public string Engine { get; set; }
        public string Query { get; set; }
        public long Result { get; set; }
    }
}
