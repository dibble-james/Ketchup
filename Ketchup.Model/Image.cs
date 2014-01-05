// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Image.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Model
{
    using JamesDibble.ApplicationFramework.Data.Persistence;

    public class Image : UniqueObject<int>
    {
        public string Path { get; set; }
    }
}