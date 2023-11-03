using System;
using System.Security.Cryptography;

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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this == obj)
            {
                return true;
            }
            if (!(obj is AuthorBookEdge))
            {
                return false;
            }

            var edge = (CategoryBookEdge)obj;
            var objKey = edge.CategoryId + "_" + edge.BookId;
            var thisKey = CategoryId + "_" + BookId;
            return (objKey.Equals(thisKey));
        }

        public override int GetHashCode()
        {
            return CategoryId.GetHashCode() + BookId.GetHashCode();
        }
    }
}
