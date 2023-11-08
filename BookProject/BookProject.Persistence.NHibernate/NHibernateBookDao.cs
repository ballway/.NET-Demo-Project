using BookProject.Contract.Domain;
using BookProject.Contract.Persistence;
using BookProject.Persistence.NHibernate.Utility;
using NHibernate;
using System.Collections;

namespace BookProject.Persistence.NHibernate
{
    public class NHibernateBookDao : IBookDao
    {
        public SessionProvider SessionProvider { get; set; }

        public ISession Session { get; set; }

        private ISession GetSession()
        {
            if (Session == null)
            {
                Session = SessionProvider.GetSession();
            }
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

        public bool Exists(string bookId)
        {
            string hql = "from Book as b where b.BookId=:bookId";
            ISession session = GetSession();
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("bookId", bookId);
            if (query.List().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Create(Book book)
        {
            ISession session = GetSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(book);
                transaction.Commit();
            }
        }

        public void Update(Book book)
        {
            ISession session = GetSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(book);
                transaction.Commit();
            }
        }

        public void Delete(Book book)
        {
            ISession session = GetSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(book);
                session.Flush();
                transaction.Commit();
            }
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
