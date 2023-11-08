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
            Assert.That(book.DisplayName, Is.EqualTo("Google SEO ���e��P��Խ�"));
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
            // Arrange: �ǳƤ@���ݷs�W�����ո��
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "���իإߪ����y";
            newBook.LastModifiedDateTime = DateTime.UtcNow;

            // Act: ����s�W
            bookDao.Create(newBook);

            // Assert
            Book book = bookDao.Get(newBook.BookId);
            Assert.That(book.BookId, Is.EqualTo(newBook.BookId));
            Assert.That(book.DisplayName, Is.EqualTo("���իإߪ����y"));
            Assert.That(book.LastModifiedDateTime, Is.EqualTo(newBook.LastModifiedDateTime));
        }

        [Test]
        [Category("BookDao")]
        public void Test005_Update()
        {
            // Arrange: �s�W�@�����ո�ơA�÷ǳƫݧ�s�����
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "���է�s�����y";
            newBook.LastModifiedDateTime = DateTime.UtcNow;
            bookDao.Create(newBook);

            string updateName = "��s�L�����y";
            DateTime updateDateTime = DateTime.UtcNow;
            Book book = bookDao.Get(newBook.BookId);
            book.DisplayName = updateName;
            book.LastModifiedDateTime = updateDateTime;

            // Act: ����s�W�����ո�ư���s
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
            // Arrange: �s�W�@�����ո��
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "�n�Q�R������";
            newBook.LastModifiedDateTime = DateTime.UtcNow;
            bookDao.Create(newBook);
            int beforeDeleteCount = bookDao.GetAll().Count;

            // Act: �R�����s�W�����ո��
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
            Assert.That(author.DisplayName, Is.EqualTo("�����J"));
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
            Assert.That(category.DisplayName, Is.EqualTo("�q�l�Ӱ�"));
        }


        private string GetGUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}