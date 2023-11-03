using System;

namespace BookProject.Contract.Domain
{
    /// <summary>
    /// 代表一筆 Author 的資料。
    /// </summary>
    public class Author
    {
        public int Flag { get; set; }

        /// <summary>
        /// 作者 Id。
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// 作者顯示名稱。
        /// </summary>
        public string DisplayName { get; set; }
    }
}

