using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model.Responses
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public T Item { get; set; }
        public string Message { get; set; }

        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public BaseResponse(T item)
        {
            Success = true;
            Item = item;
        }
    }
}
