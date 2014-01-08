// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Customer
{
    using JamesDibble.ApplicationFramework.Data.Persistence;
    
    /// <summary>
    /// An object to represent a postal address location.
    /// </summary>
    public class Address : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the first line of the <see cref="Address"/>.
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// Gets or sets the second line of the <see cref="Address"/>.
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// Gets or sets the town or city of the <see cref="Address"/>.
        /// </summary>
        public string TownCity { get; set; }

        /// <summary>
        /// Gets or sets the county or state of the <see cref="Address"/>.
        /// </summary>
        public string CountyState { get; set; }

        /// <summary>
        /// Gets or sets the country of the <see cref="Address"/>.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code of the <see cref="Address"/>.
        /// </summary>
        public string PostalCode { get; set; }
    }
}