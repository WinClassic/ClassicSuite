using System;

namespace Craftplacer.ClassicSuite.Wizards.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a method call expects the <see cref="System.Windows.Forms.UserControl"/> to have a specific type.
    /// </summary>
    public class InvalidParentFormException : InvalidOperationException
    {
        public InvalidParentFormException()
        {
        }

        public InvalidParentFormException(string message) : base(message)
        {
        }
    }
}
