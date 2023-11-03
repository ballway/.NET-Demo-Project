using System;

namespace BookProject.Contract.Domain
{
    /// <summary>
    /// 代表一組 Author 和 Book 的關聯。
    /// </summary>
    public class AuthorBookEdge
    {
        /// <summary>
        /// 作者 Id。
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// 書籍 Id。
        /// </summary>
        public string BookId { get; set; }
    }
}
