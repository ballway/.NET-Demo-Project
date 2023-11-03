namespace BookProject.Contract.DTO
{
    public class AuthorInfo
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
