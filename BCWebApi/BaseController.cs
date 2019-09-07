using System;
using Microsoft.AspNetCore.Mvc;

namespace BCWebApi
{
    public class BaseController: Controller
    {
        public BaseController()
        {
        }
        public object returnError(string _message, int _code)
        {
            var model = new
            {
                error = new
                {
                    code = _code,
                    message = _message
                }
            };
            return model;
        }
    }
}
