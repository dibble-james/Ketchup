// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOrderNumberGenerator.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Api
{
    /// <summary>
    /// Implementing classes describe methods for creating order numbers.
    /// </summary>
    public interface IOrderNumberGenerator
    {
        /// <summary>
        /// Get the next available order number.
        /// </summary>
        /// <returns>A <see langword="string" /> containing the new order number.</returns>
        string NextOrderNumber();
    }
}