namespace LolaFlora.Common.Result
{
    public class DataApiResult<T> : ApiResult
    {
        public T Data { get; set; }

        public string DataType
        {
            get
            {
                return Data?.GetType().Name;
            }
        }

        public DataApiResult() : base()
        {
        }

        public DataApiResult(T data, string path, string message, bool succeded, int statusCode) : base(path, message, succeded, statusCode)
        {
            Data = data;
        }
    }
}
