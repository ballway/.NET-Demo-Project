using System;
using System.Security.Cryptography;

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

            var edge = (AuthorBookEdge)obj;
            var objKey = edge.AuthorId + "_" + edge.BookId;
            var thisKey = AuthorId + "_" + BookId;
            return (objKey.Equals(thisKey));
        }

        public override int GetHashCode()
        {
            return AuthorId.GetHashCode() + BookId.GetHashCode();
        }
    }
}
