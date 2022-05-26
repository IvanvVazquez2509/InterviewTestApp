﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Exceptions
{
    public  class ApiException : Exception
    {
        public ApiException() : base()
        {

        }
        public ApiException(string message) : base(message)
        {

        }
        public ApiException(string message, object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
