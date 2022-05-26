using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Filters
{
    public class PaginationFilter
    {
        public string Sort { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
