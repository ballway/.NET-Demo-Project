using BookProject.Contract.Domain;
using BookProject.Contract.DTO;
using System.Collections;
using System.Collections.Generic;

namespace BookProject.Contract.DTOConverter
{
    public class BookConverter
    {
        /// <summary>
        /// 把 Domain Objects 轉成 DTOs (多對多轉換)。
        /// </summary>
        public List<BookInfo> ToDataTransferObject(IList domainObjects)
        {
            List<BookInfo> dataTransferObjects = new List<BookInfo>();
            foreach (Book domainObject in domainObjects)
            {
                dataTransferObjects.Add(ToDataTransferObject(domainObject));
            }
            return dataTransferObjects;
        }

        /// <summary>
        /// 把 Domain Object 轉成 DTO (一對一轉換)。
        /// </summary>
        public BookInfo ToDataTransferObject(Book domainObject)
        {
            BookInfo dataTransferObject = new BookInfo
            {
                BookId = domainObject.BookId,
                Flag = domainObject.Flag,
                DisplayName = domainObject.DisplayName,
                LastModifiedDateTime = domainObject.LastModifiedDateTime
            };
            return dataTransferObject;
        }

        /// <summary>
        /// 把 DTOs 轉成 Domain Objects (多對多轉換)。
        /// </summary>
        public List<Book> ToDomainObject(List<BookInfo> dataTransferObjects)
        {
            List<Book> domainObjects = new List<Book>();
            foreach (BookInfo dataTransferObject in dataTransferObjects)
            {
                domainObjects.Add(ToDomainObject(dataTransferObject));
            }
            return domainObjects;
        }

        /// <summary>
        /// 把 DTO 轉成 Domain Object (一對一轉換)。
        /// </summary>
        public Book ToDomainObject(BookInfo dataTransferObject)
        {
            Book domainObject = new Book
            {
                BookId = dataTransferObject.BookId,
                Flag = dataTransferObject.Flag,
                DisplayName = dataTransferObject.DisplayName,
                LastModifiedDateTime = dataTransferObject.LastModifiedDateTime
            };
            return domainObject;
        }
    }
}
