// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleContextFactory.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Data.Entity.Infrastructure;
namespace EntityFrameworkInit
{
    public class SampleContextFactory : IDbContextFactory<SampleContext>
    {
        public SampleContext Create()
        {
            return new SampleContext("KetchupConnection");
        }
    }
}