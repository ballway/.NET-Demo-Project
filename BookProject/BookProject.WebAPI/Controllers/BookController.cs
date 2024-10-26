using Autofac;
using BookProject.Contract.DTO;
using BookProject.Contract.Service;
using BookProject.Service;
using BookProject.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.WebAPI.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public IBookService _bookService;

        public BookController(IComponentContext componentContext, ILogger<BookController> logger)
        {
            _logger = logger;

            // 從容器解析註冊過的服務
            _bookService = componentContext.Resolve<IBookService>();
        }

        /// <summary>
        /// 取得所有書籍資料。
        /// </summary>
        [HttpGet("/book/all")]
        public IActionResult GetAllBooks()
        {
            List<BookInfo> bookInfos = _bookService.GetAllBooks();

            return Ok(bookInfos);
        }

        /// <summary>
        /// 取得指定 BookId 的書籍資料。
        /// </summary>
        [HttpGet("/book/{bookid}")]
        public IActionResult Get(string bookid)
        {
            BookInfo bookInfo = _bookService.GetBookById(bookid);

            return Ok(bookInfo);
        }

        /// <summary>
        /// 新增一筆書籍資料。
        /// </summary>
        [HttpPost("/book")]
        public IActionResult Post([FromBody] NewBook newBook)
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookId = GetGUID();
            bookInfo.DisplayName = newBook.DisplayName;
            bookInfo.LastModifiedDateTime = DateTime.UtcNow;
            _bookService.CreateBook(bookInfo);
            bookInfo = _bookService.GetBookById(bookInfo.BookId);

            return Ok(bookInfo);
        }

        /// <summary>
        /// 更新一筆書籍資料 (修改名稱)。
        /// </summary>
        [HttpPut("/book")]
        public IActionResult Put([FromBody] UpdateBook updateBook)
        {
            BookInfo bookInfo = new BookInfo();
            bookInfo.BookId = updateBook.BookId;
            bookInfo.DisplayName = updateBook.DisplayName;
            bookInfo.LastModifiedDateTime = DateTime.UtcNow;
            _bookService.UpdateBook(bookInfo);
            bookInfo = _bookService.GetBookById(bookInfo.BookId);

            return Ok(bookInfo);
        }

        /// <summary>
        /// 刪除一筆書籍資料。
        /// </summary>
        [HttpDelete("/book/{bookid}")]
        public IActionResult Delete(string bookid)
        {
            _bookService.DeleteBookById(bookid);

            return Ok("Delete book successfully.");
        }


        /// <summary>
        /// 建立一本新書籍的參數。
        /// </summary>
        public class NewBook
        {
            /// <summary>
            /// 書籍顯示名稱。
            /// </summary>
            public string DisplayName { get; set; }

            /// <summary>
            /// 書籍作者 Id。
            /// </summary>
            public string AuthorId { get; set; }

            /// <summary>
            /// 書籍類別 Id。
            /// </summary>
            public string CategoryId { get; set; }
        }

        /// <summary>
        /// 更新一本舊書籍的參數。
        /// </summary>
        public class UpdateBook
        {
            /// <summary>
            /// 書籍 Id。
            /// </summary>
            public string BookId { get; set; }

            /// <summary>
            /// 書籍顯示名稱。
            /// </summary>
            public string DisplayName { get; set; }
        }

        private string GetGUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
