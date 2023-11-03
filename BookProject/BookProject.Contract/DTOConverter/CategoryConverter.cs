using BookProject.Contract.Domain;
using BookProject.Contract.DTO;
using System.Collections;
using System.Collections.Generic;

namespace BookProject.Contract.DTOConverter
{
    public class CategoryConverter
    {
        /// <summary>
        /// 把 Domain Objects 轉成 DTOs (多對多轉換)。
        /// </summary>
        public List<CategoryInfo> ToDataTransferObject(IList domainObjects)
        {
            List<CategoryInfo> dataTransferObjects = new List<CategoryInfo>();
            foreach (Category domainObject in domainObjects)
            {
                dataTransferObjects.Add(ToDataTransferObject(domainObject));
            }
            return dataTransferObjects;
        }

        /// <summary>
        /// 把 Domain Object 轉成 DTO (一對一轉換)。
        /// </summary>
        public CategoryInfo ToDataTransferObject(Category domainObject)
        {
            CategoryInfo dataTransferObject = new CategoryInfo
            {
                CategoryId = domainObject.CategoryId,
                Flag = domainObject.Flag,
                DisplayName = domainObject.DisplayName,
                ParentCategoryId = domainObject.ParentId
            };
            return dataTransferObject;
        }

        /// <summary>
        /// 把 DTOs 轉成 Domain Objects (多對多轉換)。
        /// </summary>
        public List<Category> ToDomainObject(List<CategoryInfo> dataTransferObjects)
        {
            List<Category> domainObjects = new List<Category>();
            foreach (CategoryInfo dataTransferObject in dataTransferObjects)
            {
                domainObjects.Add(ToDomainObject(dataTransferObject));
            }
            return domainObjects;
        }

        /// <summary>
        /// 把 DTO 轉成 Domain Object (一對一轉換)。
        /// </summary>
        public Category ToDomainObject(CategoryInfo dataTransferObject)
        {
            Category domainObject = new Category
            {
                CategoryId = dataTransferObject.CategoryId,
                Flag = dataTransferObject.Flag,
                DisplayName = dataTransferObject.DisplayName,
                ParentId = dataTransferObject.ParentCategoryId
            };
            return domainObject;
        }
    }
}
