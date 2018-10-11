using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStock.Common.Repository
{
    public class PagingResponse<TPagingModel>
    {
        public IEnumerable<TPagingModel> Result { get; set; }
        public int TotalCount { get; set; }
    }
}