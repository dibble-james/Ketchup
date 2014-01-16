// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupBuilder.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    using System;

    using JamesDibble.ApplicationFramework.Data.Persistence;

    /// <summary>
    /// A class to build a <see cref="IKetchup"/> context for the application using a fluid interface.
    /// </summary>
    public static class KetchupBuilder
    {
        /// <summary>
        /// Initialise the fluid interface.
        /// </summary>
        /// <param name="persistence">An access point to the persistence source for this <see cref="IKetchup"/> instance.</param>
        /// <returns>A new fluid interface builder.</returns>
        public static IKetchupConfiguration Configure(IPersistenceManager persistence)
        {
            return new KetchupConfiguration(persistence);
        }

        /// <summary>
        /// Initialise the fluid interface.
        /// </summary>
        /// <param name="persistenceManagerCreator">Build an access point to the persistence source for this <see cref="IKetchup"/> instance.</param>
        /// <returns>A new fluid interface builder.</returns>
        public static IKetchupConfiguration Configure(Func<IPersistenceManager> persistenceManagerCreator)
        {
            var persistence = persistenceManagerCreator.Invoke();

            return KetchupBuilder.Configure(persistence);
        }
    }
}