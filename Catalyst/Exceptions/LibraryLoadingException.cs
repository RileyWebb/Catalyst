using System;

namespace Catalyst.Exceptions
{
    public class LibraryLoadingException : Exception
    {
        public LibraryLoadingException(string name) : base($"Unable To Load Library: {name}") { }
    }
}