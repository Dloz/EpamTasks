using System;

namespace TelephoneExchangeLibrary.Interfaces
{
    public interface IIdentifiable // models.
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        Guid Id { get; }
    }
}