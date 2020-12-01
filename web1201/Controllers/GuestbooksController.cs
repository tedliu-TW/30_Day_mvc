using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using web1201.Models;
using web1201.Service;
using web1201.ViewModels;

namespace web1201.Controllers
{
    public class GuestbooksController : Controller
    {
        //宣告Guestbooks 資料表的Service物件
        private readonly GuestbooksDBService GuestbookService = new GuestbooksDBService();
        // GET: Guestbooks
        public ActionResult Index()
        {
            //宣告一個新頁面的模型
            GuestbooksViewModel Data = new GuestbooksViewModel();
            //Service 中 取得葉面所需陣列資料;
            //將頁面
            Data.DataList = GuestbookService.GetDataList();

            return View(Data);
        }
        //新增留言
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,Content")]Guestbooks Data)
        {
            //使用service來新增資料
            GuestbookService.InsertGuestbooks(Data);
            return RedirectToAction("Index");
        }


    }
}