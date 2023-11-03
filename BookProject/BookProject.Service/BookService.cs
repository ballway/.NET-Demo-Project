using BookProject.Contract.Domain;
using BookProject.Contract.DTO;
using BookProject.Contract.DTOConverter;
using BookProject.Contract.Exceptions;
using BookProject.Contract.Persistence;
using BookProject.Contract.Service;
using System.Collections;
using System.Collections.Generic;

namespace BookProject.Service
{
    public class BookService : IBookService
    {
        private readonly BookConverter _bookConverter = new BookConverter();
        private readonly AuthorConverter _authorConverter = new AuthorConverter();
        private readonly CategoryConverter _categoryConverter = new CategoryConverter();

        public IBookDao BookDao { get; set; }

        public List<BookInfo> GetAllBooks()
        {
            IList books = BookDao.GetAll();
            List<BookInfo> result = _bookConverter.ToDataTransferObject(books);
            return result;
        }

        public BookInfo GetBookById(string bookId)
        {
            // 檢查參數
            if (string.IsNullOrEmpty(bookId))
            {
                throw new EmptyBookIdException();
            }

            // 檢查該書籍是否存在
            if (!BookDao.Exists(bookId))
            {
                throw new BookNotExistException(bookId);
            }

            Book book = BookDao.Get(bookId);
            BookInfo result = _bookConverter.ToDataTransferObject(book);
            return result;
        }

        public List<AuthorInfo> GetBookAuthors(string bookId)
        {
            // 檢查參數
            if (string.IsNullOrEmpty(bookId))
            {
                throw new EmptyBookIdException();
            }

            // 檢查該書籍是否存在
            if (!BookDao.Exists(bookId))
            {
                throw new BookNotExistException(bookId);
            }

            IList authors = BookDao.GetAuthors(bookId);
            List<AuthorInfo> result = _authorConverter.ToDataTransferObject(authors);
            return result;
        }

        public List<CategoryInfo> GetBookCategories(string bookId)
        {
            // 檢查參數
            if (string.IsNullOrEmpty(bookId))
            {
                throw new EmptyBookIdException();
            }

            // 檢查該書籍是否存在
            if (!BookDao.Exists(bookId))
            {
                throw new BookNotExistException(bookId);
            }

            IList categories = BookDao.GetCategories(bookId);
            List<CategoryInfo> result = _categoryConverter.ToDataTransferObject(categories);
            return result;
        }

        public void CreateBook(BookInfo bookInfo)
        {
            // 檢查參數
            if (string.IsNullOrEmpty(bookInfo.BookId))
            {
                throw new EmptyBookIdException();
            }

            // 檢查該書籍是否存在
            if (BookDao.Exists(bookInfo.BookId))
            {
                throw new DuplicateBookException(bookInfo.BookId);
            }

            Book book = _bookConverter.ToDomainObject(bookInfo);
            BookDao.Create(book);
        }

        public void UpdateBook(BookInfo bookInfo)
        {
            // 檢查參數
            if (string.IsNullOrEmpty(bookInfo.BookId))
            {
                throw new EmptyBookIdException();
            }

            // 檢查該書籍是否存在 (不存在就沒得更新了)
            if (!BookDao.Exists(bookInfo.BookId))
            {
                throw new BookNotExistException(bookInfo.BookId);
            }

            Book book = _bookConverter.ToDomainObject(bookInfo);
            BookDao.Update(book);
        }

        public void DeleteBookById(string bookId)
        {
            // 檢查參數
            if (string.IsNullOrEmpty(bookId))
            {
                throw new EmptyBookIdException();
            }

            // 檢查該書籍是否存在
            if (!BookDao.Exists(bookId))
            {
                throw new BookNotExistException(bookId);
            }

            Book book = BookDao.Get(bookId);
            BookDao.Delete(book);
        }
    }
}
