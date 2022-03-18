using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace ManagementSystem.Foundation.Utilities
{
    public class DataTablesAjaxRequestModel
    {
        private HttpRequest _request;

        private int Start
        {
            get
            {
                var method = _request.Method.ToLower();

                if (method == "get")
                    return Convert.ToInt32(_request.Query["start"]);
                else if(method == "post")
                    return Convert.ToInt32(_request.Form["start"]);
                else
                    throw new InvalidOperationException("Http method not supported, use get or post");
            }
        }

        public int Length
        {
            get
            {
                var method = _request.Method.ToLower();

                if (method == "get")
                    return Convert.ToInt32(_request.Query["length"]);
                else if(method == "post")
                    return Convert.ToInt32(_request.Form["length"]);
                else
                    throw new InvalidOperationException("Http method not supported, use get or post");
            }
        }

        public string SearchText
        {
            get
            {
                return _request.Query["search[value]"];
            }
        }

        public int SortingCols { get; set; }

        public DataTablesAjaxRequestModel(HttpRequest request)
        {
            _request = request;
        }

        public int PageIndex
        {
            get
            {
                if (Length > 0)
                    return (Start / Length) + 1;
                else
                    return 1;
            }
        }

        public int PageSize
        {
            get
            {
                if (Length == 0)
                    return 10;
                else
                    return Length;
            }
        }

        public static object EmptyResult
        {
            get
            {
                return new
                {
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = (new string[] { }).ToArray()
                };
            }
        }

        public string GetSortText(string[] columnNames)
        {
            var method = _request.Method.ToLower();
            if (method == "get")
                return ReadValues(_request.Query, columnNames);
            else if (method == "post")
                return ReadValues(_request.Form, columnNames);
            else
                throw new InvalidOperationException("Http method not supported, use get or post");
        }

        private string ReadValues(IEnumerable<KeyValuePair<string, StringValues>>
            requestValues, string[] columnNames)
        {
            var sortText = new StringBuilder();
            for (var i = 0; i < columnNames.Length; i++)
            {
                if (requestValues.Any(x => x.Key == $"order[{i}][column]"))
                {
                    if (sortText.Length > 0)
                        sortText.Append(",");

                    var columnValue = requestValues.Where(x => x.Key == $"order[{i}][column]").FirstOrDefault();
                    var directionValue = requestValues.Where(x => x.Key == $"order[{i}][dir]").FirstOrDefault();

                    var column = int.Parse(columnValue.Value.ToArray()[0]);
                    var direction = directionValue.Value.ToArray()[0];
                    var sortDirection = $"{columnNames[column]} {(direction == "asc" ? "asc" : "desc")}";
                    sortText.Append(sortDirection);
                }
            }
            return sortText.ToString();
        }
    }
}