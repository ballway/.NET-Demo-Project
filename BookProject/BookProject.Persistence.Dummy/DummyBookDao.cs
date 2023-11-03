using BookProject.Contract.Domain;
using BookProject.Contract.Exceptions;
using BookProject.Contract.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BookProject.Persistence.Dummy
{
    public class DummyBookDao : IBookDao
    {
        public IList GetAll()
        {
            Book book1 = new Book
            {
                BookId = "google-seo-book",
                Flag = 1,
                DisplayName = "Google SEO 內容行銷實戰課",
                LastModifiedDateTime = DateTime.UtcNow
            };

            Book book2 = new Book
            {
                BookId = "japan-travel-book",
                Flag = 1,
                DisplayName = "2023 日本旅遊攻略",
                LastModifiedDateTime = DateTime.UtcNow
            };

            List<Book> result = new List<Book>();
            result.Add(book1);
            result.Add(book2);

            return result;
        }

        public Book Get(string bookId)
        {
            IList books = GetAll();

            foreach(Book book in books)
            {
                if(book.BookId == bookId)
                {
                    return book;
                }
            }

            throw new BookNotExistException();
        }

        public bool Exists(string bookId)
        {
            IList books = GetAll();

            foreach (Book book in books)
            {
                if (book.BookId == bookId)
                {
                    return true;
                }
            }

            return false;
        }

        public void Create(Book book)
        {
            // Do Nothing
        }

        public void Update(Book book)
        {
            // Do Nothing
        }

        public void Delete(Book book)
        {
            // Do Nothing
        }


        public IList GetAuthors(string bookId)
        {
            Author author = new Author();
            author.AuthorId = "test-authorid";
            author.Flag = 1;
            author.DisplayName = "測試的顯示名稱";

            List<Author> result = new List<Author>();
            result.Add(author);

            return result;
        }

        public IList GetCategories(string bookId)
        {
            Category category = new Category();
            category.CategoryId = "test-categoryid";
            category.Flag = 1;
            category.DisplayName = "測試的顯示名稱";

            List<Category> result = new List<Category>();
            result.Add(category);

            return result;
        }
    }
}
