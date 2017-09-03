using System;
using Matrix.Client.Responses;

namespace Matrix.Client.Tests.SysInteg.Common
{
    public class TestsFixture : IDisposable
    {
        public Login Login { get; set; }

        public void Dispose()
        {

        }
    }
}
