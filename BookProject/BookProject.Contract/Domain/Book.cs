using System;

namespace BookProject.Contract.Domain
{
    /// <summary>
    /// 代表一筆 Book 的資料。
    /// </summary>
    public class Book
    {
        public int Flag { get; set; }

        /// <summary>
        /// 書籍 Id。
        /// </summary>
        public string BookId { get; set; }

        /// <summary>
        /// 書籍顯示名稱。
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 資料最後更新時間。
        /// </summary>
        public DateTime LastModifiedDateTime { get; set; }
    }
}
