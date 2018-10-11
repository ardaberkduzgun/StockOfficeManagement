using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStock.Common.Repository
{
    public class PagingRequest
    {
        public OrderByType? OrderByType { get; set; }

        public string OrderColumn { get; set; }

        public int? SkipCount { get; set; }

        public int? TakeCount { get; set; }
    }
}