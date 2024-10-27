using System;
using System.Net;

namespace BookProject.Utility
{
    /// <summary>
    /// WebResponseEntity
    /// </summary>
    public class WebResponseEntity
    {
        /// <summary>
        /// 是否成功取得網頁內容
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 網址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 網頁內容
        /// </summary>
        public string HTML { get; set; }

        /// <summary>
        /// WebException 發生時的狀態碼
        /// </summary>
        public WebExceptionStatus WebExceptionStatus { get; set; }

        /// <summary>
        /// 失敗的錯誤資訊
        /// </summary>
        public Exception Exception { get; set; }
    }
}
