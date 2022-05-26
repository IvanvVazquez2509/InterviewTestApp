using InterviewTastApp.Application.Filters;
using InterviewTastApp.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }


        public Uri GetPostPaginationUri(PaginationFilter filter, string actionUrl)
        {
            // string baseUrl = $"{_baseUri}{actionUrl}";
            var _enpointUri = new Uri(string.Concat(_baseUri, actionUrl));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
