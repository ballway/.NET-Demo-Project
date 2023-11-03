using BookProject.Contract.Domain;
using BookProject.Contract.DTO;
using System.Collections;
using System.Collections.Generic;

namespace BookProject.Contract.DTOConverter
{
    public class AuthorConverter
    {
        /// <summary>
        /// 把 Domain Objects 轉成 DTOs (多對多轉換)。
        /// </summary>
        public List<AuthorInfo> ToDataTransferObject(IList domainObjects)
        {
            List<AuthorInfo> dataTransferObjects = new List<AuthorInfo>();
            foreach (Author domainObject in domainObjects)
            {
                dataTransferObjects.Add(ToDataTransferObject(domainObject));
            }
            return dataTransferObjects;
        }

        /// <summary>
        /// 把 Domain Object 轉成 DTO (一對一轉換)。
        /// </summary>
        public AuthorInfo ToDataTransferObject(Author domainObject)
        {
            AuthorInfo dataTransferObject = new AuthorInfo
            {
                AuthorId = domainObject.AuthorId,
                Flag = domainObject.Flag,
                DisplayName = domainObject.DisplayName,
            };
            return dataTransferObject;
        }

        /// <summary>
        /// 把 DTOs 轉成 Domain Objects (多對多轉換)。
        /// </summary>
        public List<Author> ToDomainObject(List<AuthorInfo> dataTransferObjects)
        {
            List<Author> domainObjects = new List<Author>();
            foreach (AuthorInfo dataTransferObject in dataTransferObjects)
            {
                domainObjects.Add(ToDomainObject(dataTransferObject));
            }
            return domainObjects;
        }

        /// <summary>
        /// 把 DTO 轉成 Domain Object (一對一轉換)。
        /// </summary>
        public Author ToDomainObject(AuthorInfo dataTransferObject)
        {
            Author domainObject = new Author
            {
                AuthorId = dataTransferObject.AuthorId,
                Flag = dataTransferObject.Flag,
                DisplayName = dataTransferObject.DisplayName
            };
            return domainObject;
        }
    }
}
