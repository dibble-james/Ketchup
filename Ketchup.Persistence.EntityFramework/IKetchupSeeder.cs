// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKetchupSeeder.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementing classes define a collection of methods to insert objects into a <see cref="KetchupContext"/>.
    /// </summary>
    public interface IKetchupSeeder
    {
        /// <summary>
        /// Gets the methods to invoke to seed the <see cref="KetchupContext"/>.
        /// </summary>
        IEnumerable<Action<KetchupContext>> SeedMethods { get; } 
    }
}