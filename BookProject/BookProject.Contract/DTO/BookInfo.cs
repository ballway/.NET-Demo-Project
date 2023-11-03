using System;
using System.Collections.Generic;

namespace BookProject.Contract.DTO
{
    public class BookInfo
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

        /// <summary>
        /// 此書籍的作者。
        /// </summary>
        public List<AuthorInfo> Authors { get; set; }

        /// <summary>
        /// 此書籍的分類。
        /// </summary>
        public List<CategoryInfo> Categories { get; set; }
    }
}
