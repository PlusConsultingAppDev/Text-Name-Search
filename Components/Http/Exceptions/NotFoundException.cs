﻿using System;
using App.Exceptions;

namespace App.HttpClient.Exceptions
{
    public class NotFoundException : HaltRequestExecutionException
    {
        public NotFoundException()
         : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
