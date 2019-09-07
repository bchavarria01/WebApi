using System;
using Microsoft.AspNetCore.Mvc;

namespace BCWebApi
{
    public class PublicFunctions: Controller
    {
        public PublicFunctions()
        {
        }
        public object returnError(string _message)
        {
            var model = new
            {
                error = new
                {
                    code = 400,
                    message = _message
                }
            };
            return model;
        }
    }
}
