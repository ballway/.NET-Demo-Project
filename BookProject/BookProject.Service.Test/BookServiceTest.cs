using BookProject.Contract.DTO;
using BookProject.Contract.Exceptions;
using BookProject.Persistence.Dummy;
using NUnit.Framework;

namespace BookProject.Service.Test
{
    public class BookServiceTest
    {
        readonly BookService bookService = new BookService()
        {
            BookDao = new DummyBookDao()
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Category("BookService")]
        public void Test_GetAllBooks()
        {
            List<BookInfo> bookInfos = bookService.GetAllBooks();

            Assert.That(bookInfos.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("BookService")]
        public void Test_GetBookById()
        {
            string bookId = "google-seo-book";
            BookInfo bookInfo = bookService.GetBookById(bookId);

            Assert.That(bookInfo.DisplayName, Is.EqualTo("Google SEO 內容行銷實戰課"));
        }

        [Test]
        [Category("BookService")]
        public void Test_GetBookById_EmptyBookIdException()
        {
            string bookId = "";

            var ex = Assert.Throws<EmptyBookIdException>(() => {
                bookService.GetBookById(bookId);
            });
        }

        [Test]
        [Category("BookService")]
        public void Test_GetBookAuthors()
        {
            string bookId = "google-seo-book";
            List<AuthorInfo> authorInfos = bookService.GetBookAuthors(bookId);

            Assert.That(authorInfos.Count, Is.EqualTo(1));
        }

        [Test]
        [Category("BookService")]
        public void Test_GetBookAuthors_EmptyBookIdException()
        {
            string bookId = "";

            var ex = Assert.Throws<EmptyBookIdException>(() => {
                bookService.GetBookAuthors(bookId);
            });
        }

        [Test]
        [Category("BookService")]
        public void Test_GetBookCategories()
        {
            string bookId = "google-seo-book";
            List<CategoryInfo> categoryInfos = bookService.GetBookCategories(bookId);

            Assert.That(categoryInfos, Has.Count.EqualTo(1));
        }

        [Test]
        [Category("BookService")]
        public void Test_GetBookCategories_EmptyBookIdException()
        {
            string bookId = "";

            var ex = Assert.Throws<EmptyBookIdException>(() => {
                bookService.GetBookCategories(bookId);
            });
        }

        [Test]
        [Category("BookService")]
        public void Test_CreateBook()
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookId = "new-bookid";
            bookInfo.DisplayName = "測試建立的書籍";
            bookService.CreateBook(bookInfo);

            Assert.Pass();
        }

        [Test]
        [Category("BookService")]
        public void Test_CreateBook_DuplicateBookException()
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookId = "google-seo-book";
            bookInfo.DisplayName = "Google SEO 內容行銷實戰課";

            var ex = Assert.Throws<DuplicateBookException>(() => {
                bookService.CreateBook(bookInfo);
            });
        }

        [Test]
        [Category("BookService")]
        public void Test_UpdateBook()
        {
            string bookId = "google-seo-book";
            BookInfo bookInfo = bookService.GetBookById(bookId);
            bookInfo.DisplayName = "測試更新的書籍";
            bookService.UpdateBook(bookInfo);

            Assert.Pass();
        }

        [Test]
        [Category("BookService")]
        public void Test_UpdateBook_BookNotExistException()
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookId = "new-bookid";
            bookInfo.DisplayName = "測試更新的書籍";
            
            var ex = Assert.Throws<BookNotExistException>(() => {
                bookService.UpdateBook(bookInfo);
            });
        }

        [Test]
        [Category("BookService")]
        public void Test_DeleteBookById()
        {
            string bookId = "google-seo-book";
            bookService.DeleteBookById(bookId);

            Assert.Pass();
        }

        [Test]
        [Category("BookService")]
        public void Test_DeleteBookById_BookNotExistException()
        {
            string bookId = "not-exist-id";

            var ex = Assert.Throws<BookNotExistException>(() => {
                bookService.DeleteBookById(bookId);
            });
        }
    }
}