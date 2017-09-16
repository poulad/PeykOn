using System;

namespace Matrix.NET.Client.Tests.SysInteg.XunitExtensions
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyFixtureAttribute : Attribute
    {
        public Type FixtureType { get; }

        public AssemblyFixtureAttribute(Type fixtureType)
        {
            FixtureType = fixtureType;
        }
    }
}
