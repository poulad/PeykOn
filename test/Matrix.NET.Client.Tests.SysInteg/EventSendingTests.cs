using System;
using System.Threading.Tasks;
using Matrix.NET.Abstractions;
using Matrix.NET.Client.Requests;
using Matrix.NET.Client.Tests.SysInteg.Common;
using Xunit;

namespace Matrix.NET.Client.Tests.SysInteg
{
    [Collection(CommonConstants.TestCollections.EventSending)]
    [TestCaseOrderer(CommonConstants.TestCaseOrdererName, CommonConstants.AssemblyName)]
    public class EventSendingTests
    {
        private readonly TestsFixture _fixture;

        private IMatrixClient Client => _fixture.MatrixClient;

        public EventSendingTests(TestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ExecutionOrder(1)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.Events.TxnId)]
        public async Task Should_Send_Text_Message()
        {
            MessageEventRequestBase req =
                new TextMessageEventRequest(ConfigurationProvider.TestConfigurations.RoomId, Guid.NewGuid().ToString(), "Hello, World");

            string eventId = await Client.SendMessageEventAsync(req);

            Assert.NotEmpty(eventId);
        }

        [Fact]
        [ExecutionOrder(2)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.ContentRepository.Upload)]
        [Trait(CommonConstants.ApiRouteTraitName, Constants.Routes.Events.TxnId)]
        public async Task Should_Send_Image_Message()
        {
            string url = await Client.UploadMediaAsync(new MediaUploadRequest("img.png", "image/png", @"Files/matrix.png"));

            MessageEventRequestBase req =
                new ImageMessageEventRequest(ConfigurationProvider.TestConfigurations.RoomId, Guid.NewGuid().ToString())
                {
                    Body = "Matrix Logo",
                    Url = url
                };

            string eventId = await Client.SendMessageEventAsync(req);

            Assert.NotEmpty(eventId);
        }
    }
}
