//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="KetchupConfiguration.cs" company="James Dibble">
//     Copyright 2012 James Dibble
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Api;
    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// An instance of the <see cref="IKetchup"/> fluid context builder.
    /// </summary>
    internal sealed class KetchupConfiguration : IKetchupConfiguration
    {
        /// <summary>
        /// Create an <see cref="IKetchup"/> context with the previously set parameters.
        /// </summary>
        /// <returns>An <see cref="IKetchup"/> context.</returns>
        public IKetchup Build()
        {
            if (this.Persistence == null)
            {
                throw new InvalidOperationException("No IPersistenceManager has been defined to build Ketchup with.");
            }

            if (this.OrderNumberGenerator != null)
            {
                return new Ketchup(this.Persistence, this.OrderNumberGenerator);
            }

            return new Ketchup(this.Persistence);
        }

        /// <summary>
        /// Set a property to the <see cref="IKetchup"/> context.
        /// </summary>
        /// <param name="property">The property to set.</param>
        /// <param name="value">The value of the property.</param>
        /// <returns>The fluid interface builder.</returns>
        public IKetchupConfiguration With(Expression<Func<IKetchupConfiguration, object>> property, object value)
        {
            PropertyInfo propertyInfo;

            if (property.Body is MemberExpression)
            {
                propertyInfo = (property.Body as MemberExpression).Member as PropertyInfo;
            }
            else
            {
                propertyInfo = (((UnaryExpression)property.Body).Operand as MemberExpression).Member as PropertyInfo;
            }

            var ps = this.GetType().GetProperty(propertyInfo.Name);
            
            ps.SetValue(this, value);

            return this;
        }

        /// <summary>
        /// Gets the <see cref="IPersistenceManager"/> for <see cref="IKetchup"/> to use to read its object from.
        /// </summary>
        public IPersistenceManager Persistence { get; private set; }

        /// <summary>
        /// Gets the <see cref="IOrderNumberGenerator"/> for <see cref="IKetchup"/> to use.
        /// </summary>
        public IOrderNumberGenerator OrderNumberGenerator { get; private set; }
    }
}