using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Matrix.Client.Responses;
using Newtonsoft.Json;

namespace Matrix.Client.Requests
{
    public class MediaUploadRequest : RequestBase<UploadMediaResponse>
    {
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                PathParameters.Add("fileName", _fileName);
            }
        }

        public string FilePath { get; }

        public string ContentType;

        private string _fileName;

        private readonly Stream _fileStream;

        public MediaUploadRequest(string fileName, string contentType, string filePath)
            : this(fileName, contentType, null, filePath)
        {

        }

        public MediaUploadRequest(string fileName, string contentType, Stream stream)
            : this(fileName, contentType, stream, null)
        {

        }

        private MediaUploadRequest(string fileName, string contentType, Stream fileStream, string filePath)
            : base("media/{version}/upload?access_token={accessToken}&filename={fileName}", HttpMethod.Post, true)
        {
            FileName = fileName;
            ContentType = contentType;
            _fileStream = fileStream;
            FilePath = filePath;
        }

        public override HttpContent GetHttpContent(JsonSerializerSettings serializerSettings)
        {
            HttpContent content;

            if (!string.IsNullOrWhiteSpace(FilePath))
            {
                var bytes = File.ReadAllBytes(FilePath);
                content = new ByteArrayContent(bytes);
            }
            else
            {
                content = new StreamContent(_fileStream);
            }

            content.Headers.ContentType = MediaTypeHeaderValue.Parse(ContentType);
            return content;
        }
    }
}
