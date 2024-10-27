using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BookProject.Utility
{
    public class WebRequestUtility
    {
        /// <summary>
        /// 取得指定網址的內容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static WebResponseEntity GetResponse(string url)
        {
            return GetResponse(url: url, encoding: Encoding.UTF8);
        }

        /// <summary>
        /// 取得指定網址的內容
        /// </summary>
        /// <param name="url">網址</param>
        /// <param name="encoding">編碼方式</param>
        /// <param name="retryOnce">失敗時是否要重試一次 (預設為 false)</param>
        /// <param name="httpMethod">HTTP Method</param>
        /// <param name="timeout">連線逾時的時間 (毫秒)</param>
        /// <returns>WebResponseEntity</returns>
        public static WebResponseEntity GetResponse(string url, Encoding encoding, bool retryOnce = false, string httpMethod = "GET", int timeout = 200000)
        {
            WebResponseEntity result = new WebResponseEntity();
            result.Url = url;

            try
            {
                // 建立 WebRequest 並指定目標的 uri
                Uri uri = new Uri(url);

                // 使用 HttpWebRequest.Create 實際上也是呼叫 WebRequest.Create
                // WebRequest webRequest = HttpWebRequest.Create(uri);
                HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
                httpWebRequest.Method = httpMethod;
                httpWebRequest.Timeout = timeout;
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/130.0.0.0 Safari/537.36";
                httpWebRequest.Headers.Set("Accept-Language", "zh-tw");
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.AllowWriteStreamBuffering = false;
                httpWebRequest.KeepAlive = true;

                using (var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse())
                {
                    // 在這裡對接收到的內容進行處理
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), encoding))
                    {
                        var htmlContent = streamReader.ReadToEnd();

                        result.IsSuccess = true;
                        result.HTML = htmlContent;
                    }
                }

                return result;
            }
            catch (WebException ex)
            {
                if (retryOnce)
                {
                    return GetResponse(url: url, encoding: encoding, retryOnce: false, httpMethod: httpMethod, timeout: timeout);
                }
                else
                {
                    result.IsSuccess = false;
                    result.WebExceptionStatus = ex.Status;
                    result.Exception = ex;

                    return result;
                }
            }
            catch (Exception ex)
            {
                if (retryOnce)
                {
                    return GetResponse(url: url, encoding: encoding, retryOnce: false, httpMethod: httpMethod, timeout: timeout);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Exception = ex;

                    return result;
                }
            }
        }


    }
}
