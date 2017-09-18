namespace Matrix.NET.Models
{
    public interface IErrorResponse
    {
        string ErrCode { get; set; }

        string Error { get; set; }
    }
}