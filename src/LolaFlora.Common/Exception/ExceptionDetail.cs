using System.Collections;
using System.Collections.Generic;
namespace LolaFlora.Common.Exception
{
    public class ExceptionDetail
    {
        #region Properties

        public string Type { get; }
        public string Message { get; }
        public string StackTrace { get; }
        public string Source { get; }
        public string HelpLink { get; }
        public int HResult { get; }
        public ExceptionDetail InnerException { get; }
        public Dictionary<string, string> Data { get; }

        #endregion

        #region Constructor
        public ExceptionDetail(System.Exception exception)
        {
            Type = exception.GetType().Name;
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            Source = exception.Source;
            HelpLink = exception.HelpLink;
            HResult = exception.HResult;
            InnerException = exception.InnerException == null ? null : new ExceptionDetail(exception.InnerException);
            Data = new Dictionary<string, string>();
            foreach (DictionaryEntry item in exception.Data)
            {
                Data.Add(item.Key.ToString(), item.Value.ToString());
            }
        }

        #endregion
    }
}
