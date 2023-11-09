using BookProject.Contract.DTO;
using BookProject.Contract.Service;
using BookProject.Persistence.Dummy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookProject.WebMVC.Controllers
{
    public class BookController : Controller
    {
        public IBookService BookService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        // GET: book/getallbooks
        /// <summary>
        /// 傳回所有書籍資訊。
        /// </summary>
        public JsonResult GetAllBooks()
        {
            try
            {
                List<BookInfo> bookInfos = BookService.GetAllBooks();
                return Json(bookInfos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: book/getbookbyid?bookid=google-seo-book
        /// <summary>
        /// 以 Id 取得指定書籍資訊。
        /// </summary>
        public JsonResult GetBookById(string bookId)
        {
            try
            {
                BookInfo bookInfo = BookService.GetBookById(bookId);
                return Json(bookInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}