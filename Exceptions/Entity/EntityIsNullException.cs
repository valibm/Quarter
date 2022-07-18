﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.Entity
{
    public class EntityIsNullException : Exception
    {
        private readonly static string _message = "Entity could not be found";
        public EntityIsNullException() : base(_message) { }
    }
}
