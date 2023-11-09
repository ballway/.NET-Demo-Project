using Autofac;
using BookProject.Contract.DTO;
using BookProject.Contract.Service;
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
        [HttpGet("/book/getall")]
        public IActionResult GetAllBooks()
        {
            List<BookInfo> bookInfos = _bookService.GetAllBooks();

            return Ok(bookInfos);
        }

        /// <summary>
        /// 取得指定 BookId 的書籍資料。
        /// </summary>
        [HttpGet("/book/get/{bookid}")]
        public IActionResult Get(string bookid)
        {
            BookInfo bookInfo = _bookService.GetBookById(bookid);

            return Ok(bookInfo);
        }

    }
}
