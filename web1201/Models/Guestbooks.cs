using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web1201.Models
{
    public class Guestbooks
    {

        [DisplayName("編號")]
        public int Id { get;set;} // 編號


        [DisplayName("名子")]
        [Required(ErrorMessage ="請輸入名子")]
        [StringLength(20, ErrorMessage ="名子不可超過20字元")]
        public string Name { get;set;} //名子

        [DisplayName("留言內容")]
        [Required(ErrorMessage ="請輸入留言內容")]
        [StringLength(100, ErrorMessage ="留言內容不可以超過100字元")]
        public string Content { get;set;}//留言內容


        [DisplayName("新增時間")]
        public DateTime CreateTime { get;set;} // 新增時間


        [DisplayName("回覆內容")]
        public string Reply { get;set;} //回覆內容

        public DateTime? ReplyTime { get;set;}//dateTime? 資料型態，允許Date.有null產生









    }
}