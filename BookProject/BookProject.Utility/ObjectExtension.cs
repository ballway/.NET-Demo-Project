using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookProject.Utility
{
    /// <summary>
    /// object 相關擴充方法
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 把物件轉換成 JSON 字串。
        /// </summary>
        /// <param name="source">要被轉換的物件</param>
        /// <returns>物件內容 (如果物件為 null 則會回傳 null)</returns>
        public static string Dump(this object source)
        {
            return JsonSerializer.Serialize(source);
        }
    }
}
