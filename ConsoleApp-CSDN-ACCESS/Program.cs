using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CSDN_ACCESS
{
    class Program
    {
        static void Main(string[] args)
        {
            Access access = new Access();
            access.Find();
            Console.ReadKey();
        }

        class Access
        {
            OleDbConnection oleDb = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\25454\Documents\CSDN.mdb");

            public Access() //构造函数
            {
                oleDb.Open();
            }

            public void Get()
            {
                string sql = "select * from 表1";
                //获取表1的内容
                OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, oleDb); //创建适配对象
                DataTable dt = new DataTable(); //新建表对象
                dbDataAdapter.Fill(dt); //用适配对象填充表对象
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item[0] + " | " + item[1]);
                }
            }

            public void Find()
            {
                string sql = "select * from 表1 WHERE 昵称='LanQ'";
                //获取表1中昵称为东熊的内容
                OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, oleDb); //创建适配对象
                DataTable dt = new DataTable(); //新建表对象
                dbDataAdapter.Fill(dt); //用适配对象填充表对象
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item[0] + " | " + item[1]);
                }
            }




            public bool Add()
            {
                string sql = "insert into 表1 (昵称,账号) values ('LanQ','2545493686')"; 
                //往表1添加一条记录，昵称是LanQ，账号是2545493686
                OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDb);
                int i = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
                return i > 0;
            }
            public bool Del()
            {
                string sql = "delete from 表1 where 昵称='LANQ'";
                //删除昵称为LanQ的记录
                OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDb);
                int i = oleDbCommand.ExecuteNonQuery(); 
                return i > 0;
            }
            public bool Change()
            {
                string sql = "update 表1 set 账号='233333' where 昵称='东熊'";
                //将表1中昵称为东熊的账号修改成233333
                OleDbCommand oleDbCommand = new OleDbCommand(sql, oleDb);
                int i = oleDbCommand.ExecuteNonQuery(); 
                return i > 0;
            }


        }
    }
}
