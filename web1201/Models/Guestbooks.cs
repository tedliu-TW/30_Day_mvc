using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web1201.Models
{
    public class Guestbooks
    {
        public int Id { get;set;} // 編號

        public string Name { get;set;} //名子

        public string Content { get;set;}//留言內容

        public DateTime CreateTime { get;set;} // 新增時間

        public string Reply { get;set;} //回覆內容

        public DateTime? ReplyTime { get;set;}//dateTime? 資料型態，允許Date.有null產生









    }
}