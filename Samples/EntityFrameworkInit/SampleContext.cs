// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleContext.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EntityFrameworkInit
{
    using Ketchup.Persistence.EntityFramework;

    public class SampleContext : KetchupContext
    {
        public SampleContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}