//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IKetchupConfiguration.cs" company="James Dibble">
//     Copyright 2012 James Dibble
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using System;
    using System.Linq.Expressions;
    using Api;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// Implementing classes define methods for building <see cref="IKetchup"/> fluidly and the properties
    /// to define a <see cref="IKetchup"/> context.
    /// </summary>
    public interface IKetchupConfiguration
    {
        /// <summary>
        /// Gets the <see cref="IPersistenceManager"/> for <see cref="IKetchup"/> to use to read its object from.
        /// </summary>
        IPersistenceManager Persistence { get; }

        /// <summary>
        /// Gets the <see cref="IOrderNumberGenerator"/> for <see cref="IKetchup"/> to use.
        /// </summary>
        IOrderNumberGenerator OrderNumberGenerator { get; }

        /// <summary>
        /// Create an <see cref="IKetchup"/> context with the previously set parameters.
        /// </summary>
        /// <returns>An <see cref="IKetchup"/> context.</returns>
        IKetchup Build();

        /// <summary>
        /// Set a property to the <see cref="IKetchup"/> context.
        /// </summary>
        /// <param name="property">The property to set.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>The fluid interface builder.</returns>
        IKetchupConfiguration With(Expression<Func<IKetchupConfiguration, object>> property, object value);
    }
}