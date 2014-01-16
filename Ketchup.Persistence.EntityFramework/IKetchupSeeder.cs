// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKetchupSeeder.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework
{
    using System;
    using System.Collections.Generic;

    public interface IKetchupSeeder
    {
        IEnumerable<Action<KetchupContext>> SeedMethods { get; } 
    }
}