using BookProject.Contract.Domain;
using System.Collections;

namespace BookProject.Contract.Persistence
{
    public interface IBookDao
    {
        /// <summary>
        /// 取得所有書籍資料。
        /// </summary>
        IList GetAll();

        /// <summary>
        /// 取得一筆書籍資料。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        Book Get(string bookId);

        /// <summary>
        /// 檢查指定書籍資料是否存在。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        bool Exists(string bookId);

        /// <summary>
        /// 新增一筆書籍資料。
        /// </summary>
        /// <param name="book">要新增的書籍資料。</param>
        void Create(Book book);

        /// <summary>
        /// 更新一筆書籍資料。
        /// </summary>
        /// <param name="book">要更新的書籍資料。</param>
        void Update(Book book);

        /// <summary>
        /// 刪除一筆書籍資料。
        /// </summary>
        /// <param name="book">要刪除的書籍資料。</param>
        void Delete(Book book);


        /// <summary>
        /// 取得指定書籍的作者資料。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        IList GetAuthors(string bookId);


        /// <summary>
        /// 取得指定書籍的類別。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        IList GetCategories(string bookId);
    }
}
