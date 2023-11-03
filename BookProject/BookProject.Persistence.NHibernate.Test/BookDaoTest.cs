using BookProject.Contract.Domain;
using BookProject.Contract.Persistence;
using BookProject.Persistence.NHibernate.Utility;
using BookProject.Service.Persistence.NHibernate;
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
            string databasePath = Path.GetFullPath(@"Database\\Mike_Library.db3");
            string connectionString = @"Data Source=" + databasePath + ";";
            ISessionFactory sessionFactory = SessionFactoryProvider.GetSessionFactory(DatabaseType.SQLite, connectionString);
            bookDao.Session = sessionFactory.OpenSession();
        }

        [Test]
        [Category("BookDao")]
        public void Test001_GetAll()
        {
            IList books = bookDao.GetAll();

            Assert.That(books.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("BookDao")]
        public void Test002_Get()
        {
            string bookId = "google-seo-book";
            Book book = bookDao.Get(bookId);

            Assert.That(book.DisplayName, Is.EqualTo("Google SEO ���e��P��Խ�"));
        }

        [Test]
        [Category("BookDao")]
        public void Test003_Exists()
        {
            string bookId = "google-seo-book";
            bool result = bookDao.Exists(bookId);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [Category("BookDao")]
        public void Test004_Create()
        {
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "���իإߪ����y";
            newBook.LastModifiedDateTime = DateTime.UtcNow;

            using (ITransaction transaction = bookDao.Session.BeginTransaction())
            {
                bookDao.Create(newBook);
                transaction.Commit();
            }

            Book book = bookDao.Get(newBook.BookId);
            IList books = bookDao.GetAll();

            Assert.That(book.BookId, Is.EqualTo(newBook.BookId));
            Assert.That(book.DisplayName, Is.EqualTo("���իإߪ����y"));
            Assert.That(book.LastModifiedDateTime, Is.EqualTo(newBook.LastModifiedDateTime));
        }

        [Test]
        [Category("BookDao")]
        public void Test005_Update()
        {
            // �s�W�@�����ո��
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "���է�s�����y";
            newBook.LastModifiedDateTime = DateTime.UtcNow;
            using (ITransaction transaction = bookDao.Session.BeginTransaction())
            {
                bookDao.Create(newBook);
                transaction.Commit();
            }

            // ����s�W�����ո�ư���s
            string updateName = "��s�L�����y";
            DateTime updateDateTime = DateTime.UtcNow;
            Book book = bookDao.Get(newBook.BookId);
            book.DisplayName = updateName;
            book.LastModifiedDateTime = updateDateTime;
            using (ITransaction transaction = bookDao.Session.BeginTransaction())
            {
                bookDao.Update(newBook);
                transaction.Commit();
            }

            book = bookDao.Get(newBook.BookId);
            IList books = bookDao.GetAll(); // todo

            Assert.That(book.DisplayName, Is.EqualTo(updateName));
            Assert.That(book.LastModifiedDateTime, Is.EqualTo(updateDateTime));
        }

        [Test]
        [Category("BookDao")]
        public void Test006_Delete()
        {
            // �s�W�@�����ո��
            Book newBook = new Book();
            newBook.BookId = GetGUID();
            newBook.DisplayName = "�n�Q�R������";
            newBook.LastModifiedDateTime = DateTime.UtcNow;
            using (ITransaction transaction = bookDao.Session.BeginTransaction())
            {
                bookDao.Create(newBook);
                transaction.Commit();
            }
            int beforeDeleteCount = bookDao.GetAll().Count;

            // �R�����s�W�����ո��
            using (ITransaction transaction = bookDao.Session.BeginTransaction())
            {
                bookDao.Delete(newBook);
                transaction.Commit();
            }
            int afterDeleteCount = bookDao.GetAll().Count;

            IList books = bookDao.GetAll(); // todo

            Assert.That(afterDeleteCount, Is.EqualTo(beforeDeleteCount - 1));
        }

        [Test]
        [Category("BookDao")]
        public void Test007_GetAuthors()
        {
            IList authors = bookDao.GetAuthors("google-seo-book");
            Author author = authors[0] as Author;

            Assert.That(authors.Count, Is.EqualTo(1));
            Assert.That(author.DisplayName, Is.EqualTo("�����J"));
        }

        [Test]
        [Category("BookDao")]
        public void Test008_GetCategories()
        {
            IList catrgories = bookDao.GetCategories("google-seo-book");
            Category category = catrgories[0] as Category;

            Assert.That(catrgories.Count, Is.EqualTo(1));
            Assert.That(category.DisplayName, Is.EqualTo("�q�l�Ӱ�"));
        }


        private string GetGUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}