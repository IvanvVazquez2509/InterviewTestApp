using InterviewTastApp.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PaginationFilter filter, string actionUrl);
    }
}
