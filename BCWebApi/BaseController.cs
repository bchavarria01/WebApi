using System;
using Microsoft.AspNetCore.Mvc;

namespace BCWebApi
{
    public class BaseController: Controller
    {
        public BaseController()
        {
        }
        public object returnObject(string _message, int _code, int type)
        {
            var okMessage = new { ok = new { code = _code, message = _message } };
            var model = new { error = new { code = _code, message = _message } };
            if (type == 0)
            {
                return model;
            }
            return okMessage;
        }
    }
}
