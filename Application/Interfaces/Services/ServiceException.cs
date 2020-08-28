using System;

namespace $ext_specifiedsolutionname$.Application.Interfaces.Services
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        { }

        public ServiceException(Exception innerException, string message) : base(message, innerException)
        { }
    }
}