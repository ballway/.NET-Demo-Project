using BookProject.Contract.Domain;
using BookProject.Contract.Persistence;
using NHibernate;
using System.Collections;

namespace BookProject.Service.Persistence.NHibernate
{
    public class NHibernateBookDao : IBookDao
    {
        public ISession Session { get; set; }

        private ISession GetSession()
        {
            return Session;
        }

        public IList GetAll()
        {
            const string hql = "from Book";

            ISession session = GetSession();
            IQuery query = session.CreateQuery(hql);
            IList result = query.List();
            return result;
        }

        public Book Get(string bookId)
        {
            string hql = "from Book as b where b.BookId=:bookId";
            ISession session = GetSession();
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("bookId", bookId);
            IList result = query.List();

            return result[0] as Book;
        }

        public void Create(Book book)
        {
            ISession session = GetSession();
            session.Save(book);
        }

        public void Update(Book book)
        {
            ISession session = GetSession();
            session.SaveOrUpdate(book);
        }

        public void Delete(Book book)
        {
            ISession session = GetSession();
            session.Delete(book);
            session.Flush();
        }


        public IList GetAuthors(string bookId)
        {
            string hql = "select a from AuthorBookEdge as e, Author as a where e.BookId =:bookId and e.AuthorId = a.AuthorId";
            ISession session = GetSession();
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("bookId", bookId);
            IList result = query.List();
            return result;
        }

        public IList GetCategories(string bookId)
        {
            string hql = "select c from CategoryBookEdge as e, Category as c where e.BookId =:bookId and e.CategoryId = c.CategoryId";
            ISession session = GetSession();
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("bookId", bookId);
            IList result = query.List();
            return result;
        }
    }
}
