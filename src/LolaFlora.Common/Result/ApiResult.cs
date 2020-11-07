namespace LolaFlora.Common.Result
{
    public class ApiResult
    {
        #region Properties

        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public string Path { get; set; }

        public int StatusCode { get; set; }

        #endregion Properties

        #region Constructors

        public ApiResult()
        {
        }

        public ApiResult(string path, string message, bool succeeded, int statusCode)
        {
            Path = path.ToLowerInvariant();
            Message = message;
            Succeeded = succeeded;
            StatusCode = statusCode;
        }

        #endregion Constructors
    }
}
