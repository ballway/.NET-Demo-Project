using System;

namespace BookProject.Contract.Domain
{
    /// <summary>
    /// 代表一組 Category 和 Book 的關聯。
    /// </summary>
    public class CategoryBookEdge
    {
        /// <summary>
        /// 書籍類別 Id。
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 書籍 Id。
        /// </summary>
        public string BookId { get; set; }
    }
}
