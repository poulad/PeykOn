using Matrix.NET.Client.Tests.SysInteg.Common;
using Matrix.NET.Client.Tests.SysInteg.XunitExtensions;
using Xunit;

[assembly: TestFramework(CommonConstants.AssemblyName + ".XunitExtensions.XunitTestFrameworkWithAssemblyFixture", CommonConstants.AssemblyName)]
[assembly: AssemblyFixture(typeof(TestsFixture))]
[assembly: TestCollectionOrderer(CommonConstants.AssemblyName + ".Common.TestCollectionOrderer", CommonConstants.AssemblyName)]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
