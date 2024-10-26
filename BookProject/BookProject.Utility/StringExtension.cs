using System;
using System.Linq;
using System.Text;

namespace BookProject.Utility
{
    /// <summary>
    /// 字串相關擴充方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 檢查字串是否為 null 或空字串。
        /// </summary>
        /// <param name="source">被檢查的字串</param>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 檢查字串是否為 null 或空字串或只有空白的字串。
        /// </summary>
        /// <param name="source">被檢查的字串</param>
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }
        
        /// <summary>
        /// 檢查字串是否為純數字 (阿拉伯數字)。
        /// </summary>
        /// <param name="source">被檢查的字串</param>
        public static bool IsNumber(this string source)
        {
            return source.All(char.IsDigit);
        }
         
        /// <summary>
        /// 檢查字串是否可被轉換成 DataTime 格式。
        /// </summary>
        /// <param name="source">被檢查的字串</param>
        public static bool IsDataTime(this string source)
        {
            if (source.IsNullOrWhiteSpace())
            {
                return false;
            }

            if (DateTime.TryParse(source, out DateTime result))
            {
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// 轉換成 int 型別，如果無法轉換則回傳 null。
        /// </summary>
        /// <param name="source">要被轉換的字串</param>
        public static int? TryParseToInt(this string source)
        {
            if (int.TryParse(source, out int result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 轉換成 int 型別，無法轉換則回傳預設值 (預設為 0)。
        /// </summary>
        /// <param name="source">要被轉換的字串</param>
        /// <param name="defaultValue">轉換失敗時要取得的預設值 (預設為 0)</param>
        /// <returns>轉換後的 int 型別。</returns>
        public static int ParseToInt(this string source, int defaultValue = 0)
        {
            if (int.TryParse(source, out int result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }
        }


        /// <summary>
        /// 轉換成 decimal 型別，如果無法轉換則回傳 null。
        /// </summary>
        /// <param name="value">要被轉換的字串</param>
        public static decimal? TryParseToDecimal(this string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
