// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Image.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// An path to a graphical representation of the product.
    /// </summary>
    public class Image : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the location of the <see cref="Image"/>.
        /// </summary>
        public string Path { get; set; }
    }
}