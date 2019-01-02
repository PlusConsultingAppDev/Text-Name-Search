﻿using System;
using App.Exceptions;

namespace App.HttpClient.Exceptions
{
    public class BadRequestException : HaltRequestExecutionException
    {
        public BadRequestException()
         : base()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
