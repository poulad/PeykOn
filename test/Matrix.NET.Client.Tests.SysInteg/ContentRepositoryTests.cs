using System.IO;
using System.Threading.Tasks;
using Matrix.NET.Abstractions;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.NET.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.ContentRepository)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class ContentRepositoryTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public ContentRepositoryTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1.1)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.ContentRepository.Upload)]
        public async Task Should_Upload_File_via_Path()
        {
            var req = new MediaUploadRequest("img.png", "image/png", @"Files/matrix.png");

            string contentUri = await Client.UploadMediaAsync(req);

            Assert.NotEmpty(contentUri);
            Assert.True(contentUri.StartsWith("mxc://"));
        }

        [Fact]
        [ExecutionOrder(1.2)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.ContentRepository.Upload)]
        public async Task Should_Upload_File_via_Stream()
        {
            string contentUri;
            using (var stream = new FileStream(@"Files/matrix.png", FileMode.Open))
            {
                var req = new MediaUploadRequest("img.png", "image/png", stream);

                contentUri = await Client.UploadMediaAsync(req);
            }

            Assert.NotEmpty(contentUri);
            Assert.True(contentUri.StartsWith("mxc://"));
        }
    }
}