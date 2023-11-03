namespace BookProject.Contract.DTO
{
    public class CategoryInfo
    {
        public int Flag { get; set; }

        /// <summary>
        /// 書籍類別 Id。
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// 書籍類別顯示名稱。
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 這個書籍類別的上層分類，若為 Null 則代表是最上層。
        /// </summary>
        public string ParentCategoryId { get; set; }
    }
}
