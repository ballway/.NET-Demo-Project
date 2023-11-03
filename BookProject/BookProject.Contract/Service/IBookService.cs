using BookProject.Contract.Domain;
using BookProject.Contract.DTO;
using System.Collections;
using System.Collections.Generic;

namespace BookProject.Contract.Service
{
    public interface IBookService
    {
        /// <summary>
        /// 取得所有書籍資料。
        /// </summary>
        IList GetAllBooks();

        /// <summary>
        /// 取得一筆書籍資料。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        Book GetBookById(string bookId);

        /// <summary>
        /// 取得指定書籍的作者資料。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        List<AuthorInfo> GetBookAuthors(string bookId);

        /// <summary>
        /// 取得指定書籍的類別。
        /// </summary>
        /// <param name="bookId">書籍 Id。</param>
        List<CategoryInfo> GetBookCategories(string bookId);

        /// <summary>
        /// 新增一筆書籍資料。
        /// </summary>
        /// <param name="book">要新增的書籍資料。</param>
        int CreateBook(BookInfo bookInfo);

        /// <summary>
        /// 更新一筆書籍資料。
        /// </summary>
        /// <param name="book">要更新的書籍資料。</param>
        int UpdateBook(BookInfo bookInfo);

        /// <summary>
        /// 刪除一筆書籍資料。
        /// </summary>
        /// <param name="book">要刪除的書籍資料。</param>
        int DeleteBookById(string bookId);
    }
}
