using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using web1201.Models;

namespace web1201.Service
{
	public class GuestbooksDBService : BaseService
    {
        //建立與資料的連線
        private readonly SqlConnection conn;
        protected override string tableName => "Guestbooks";

        public GuestbooksDBService():base()
        {
	        conn = new SqlConnection(cnstr);
        }

        //取得鄭烈資料方式
        public List<Guestbooks> GetDataList()
        {
            List<Guestbooks> DataList = new List<Guestbooks>();
            //sql語法
            string sql = $@"select * from {tableName}";
            try
            {
                //開啟資料庫連線
                conn.Open();
                //執行sql指令
                SqlCommand cmd = new SqlCommand(sql,conn);
                //取得sql資料
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guestbooks Data = new Guestbooks();
                    Data.Id = Convert.ToInt32(dr["Id"]);
                    Data.Name = dr["Name"].ToString();
                    Data.Content = dr["Content"].ToString();
                    Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    //確定此則留言是否回覆且不允許空白
                    if (!dr["ReplyTime"].Equals(DBNull.Value))
                    {
                        Data.Reply = dr["Reply"].ToString();
                        Data.ReplyTime =Convert.ToDateTime(dr["ReplyTime"]);
                    }
                    DataList.Add(Data);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
         return DataList;
        }



        //新增資料方式
        public void InsertGuestbooks(Guestbooks newData)
        {
            //sql新增語法
            string sql = $@"Insert INTO {tableName}(Name,Content,CreateTime) Values('{newData.Name}','{newData.Content}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            try
            {
                //開啟資料庫連線
                conn.Open();
                //執行sql指令
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                //關閉資料庫連線
                conn.Close();
            }
        }

        public Guestbooks GetDataById(int Id)
        {
            Guestbooks Data = new Guestbooks();

            string sql  =  $@"select * from {tableName} where Id ={Id}";

            try
            {
                //
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Data.Id = Convert.ToInt32(dr["Id"]);
                Data.Name = dr["Name"].ToString();
                Data.Content =  dr["Content"].ToString();
                Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                if (!string.IsNullOrWhiteSpace(dr["Reply"].ToString()))
                {
                    Data.Reply=  dr["Reply"].ToString();
                    Data.ReplyTime = Convert.ToDateTime(dr["ReplyTime"]);

                }
            }
            catch (Exception)
            {
                Data = null;
            }
            finally
            {
                conn.Close();
            }

            return Data;
        }

        public void UpdateGuestbooks(Guestbooks UpdateData)
        {
            //sql
            string sql  = $@"UPDATE {tableName} SET Name = '{UpdateData.Name}',Content = '{UpdateData.Content}' Where Id ={UpdateData.Id}";
            //
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void ReplyGuestbooks(Guestbooks ReplyData)
        {
            //sql command
            string  sql = $@"UPDate {tableName} set Reply ='{ReplyData.Reply}', ReplyTime = '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}' Where Id ={ReplyData.Id}";

            try
            {
                conn.Open();
                SqlCommand cmd=  new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public bool CheckUpdate(int Id)
        {
            Guestbooks data =  GetDataById(Id);

            return (data != null && data.ReplyTime ==null);
        }


        //刪除資料
        public void DeleteGuestbooks(int Id)
        {
            string sql = $@"delete from {tableName} where Id ={Id}";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }



        }


    }
}