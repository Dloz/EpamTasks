using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneExchangeLibrary
{
    public interface IIdentifiable
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        Guid Id { get; }
    }
}