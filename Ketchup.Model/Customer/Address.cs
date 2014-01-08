// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model.Customer
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    public class Address : UniqueObject<int>
    {
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string TownCity { get; set; }

        public string CountyState { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}