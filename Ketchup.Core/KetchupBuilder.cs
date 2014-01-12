// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupBuilder.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup
{
    /// <summary>
    /// A class to build a <see cref="IKetchup"/> context for the application using a fluid interface.
    /// </summary>
    public static class KetchupBuilder
    {
        /// <summary>
        /// Initialise the fluid interface.
        /// </summary>
        /// <returns>A new fluid interface builder.</returns>
        public static IKetchupConfiguration Configure()
        {
            return new KetchupConfiguration();
        }
    }
}