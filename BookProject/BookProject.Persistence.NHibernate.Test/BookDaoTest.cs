using BookProject.Contract.Domain;
using BookProject.Contract.Persistence;
using BookProject.Persistence.NHibernate.Utility;
using NHibernate;
using NUnit.Framework;
using System.Collections;

namespace BookProject.Persistence.NHibernate.Test
{
    public class BookDaoTest
    {
        readonly NHibernateBookDao bookDao = new NHibernateBookDao();

        [SetUp]
        public void Setup()
        {
            string configurationPath = Path.GetFullPath(@"Configuration\\nhibernate.cfg.xml");
            string databasePath = Path.GetFullPath(@"Database\\Mike_Library.db3");
            string connectionString = @"Data Source=" + databasePath + ";";
            SessionProvider sessionProvider = new SessionProvider();
            sessionProvider.ConfigurationPath = configurationPath;
            ISessionFactory sessionFactory = sessionProvider.GetSessionFactory(DatabaseType.SQLite, connectionString);
            bookDao.Session = sessionFactory.OpenSession();
        }

        [Test]
        [Category("BookDao")]
        public void Test001_GetAll()
        {
            // Act
            IList books = bookDao.GetAll();

            // Assert
            Assert.That(books.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("BookDao")]
        public void Test002_Get()
        {
            // Act
            string bookId = "google-seo-book";
            Book book = bookDao.Get(bookId);

            // Assert
            Assert.That(book.DisplayName, Is.EqualTo("Google SEO 內容行銷實戰課"));
        }

        [Test]
        [Category("BookDao")]
        public void Test003_Exists()
        {
            // Act
            string bookId = "google-seo-book";
            bool result = bookDao.Exists(bookId);

            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [Category("BookDao")]
        public void Test004_Create()
        {
            // Arrange: 準備一筆待新增的測試資料
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "測試建立的書籍";
            newBook.LastModifiedDateTime = DateTime.UtcNow;

            // Act: 執行新增
            bookDao.Create(newBook);

            // Assert
            Book book = bookDao.Get(newBook.BookId);
            Assert.That(book.BookId, Is.EqualTo(newBook.BookId));
            Assert.That(book.DisplayName, Is.EqualTo("測試建立的書籍"));
            Assert.That(book.LastModifiedDateTime, Is.EqualTo(newBook.LastModifiedDateTime));
        }

        [Test]
        [Category("BookDao")]
        public void Test005_Update()
        {
            // Arrange: 新增一筆測試資料，並準備待更新的資料
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "測試更新的書籍";
            newBook.LastModifiedDateTime = DateTime.UtcNow;
            bookDao.Create(newBook);

            string updateName = "更新過的書籍";
            DateTime updateDateTime = DateTime.UtcNow;
            Book book = bookDao.Get(newBook.BookId);
            book.DisplayName = updateName;
            book.LastModifiedDateTime = updateDateTime;

            // Act: 對剛剛新增的測試資料做更新
            bookDao.Update(newBook);

            // Assert
            book = bookDao.Get(newBook.BookId);
            Assert.That(book.DisplayName, Is.EqualTo(updateName));
            Assert.That(book.LastModifiedDateTime, Is.EqualTo(updateDateTime));
        }

        [Test]
        [Category("BookDao")]
        public void Test006_Delete()
        {
            // Arrange: 新增一筆測試資料
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "要被刪除的書";
            newBook.LastModifiedDateTime = DateTime.UtcNow;
            bookDao.Create(newBook);
            int beforeDeleteCount = bookDao.GetAll().Count;

            // Act: 刪除剛剛新增的測試資料
            bookDao.Delete(newBook);

            // Assert
            int afterDeleteCount = bookDao.GetAll().Count;
            Assert.That(afterDeleteCount, Is.EqualTo(beforeDeleteCount - 1));
        }

        [Test]
        [Category("BookDao")]
        public void Test007_GetAuthors()
        {
            // Act
            IList authors = bookDao.GetAuthors("google-seo-book");
            Author author = authors[0] as Author;

            // Assert
            Assert.That(authors.Count, Is.EqualTo(1));
            Assert.That(author.DisplayName, Is.EqualTo("王麥克"));
        }

        [Test]
        [Category("BookDao")]
        public void Test008_GetCategories()
        {
            // Act
            IList catrgories = bookDao.GetCategories("google-seo-book");
            Category category = catrgories[0] as Category;

            // Assert
            Assert.That(catrgories.Count, Is.EqualTo(1));
            Assert.That(category.DisplayName, Is.EqualTo("電子商務"));
        }


        private string GetGUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}