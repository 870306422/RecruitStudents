using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelp
{
    public class DBHelper
    {
        string sqlconn = "server=.;database=ZSDB;uid=sa;pwd=123456";

        /// <summary>
        /// 查询的方法
        /// </summary>
        /// <param name="sql">要查询的语句 </param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string sql)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }

        }

        /// <summary>
        /// 数据操作的方法
        /// </summary>
        /// <param name="sql">要操作的SQL语句(增删改)</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {

            //链接对象
            SqlConnection conn = new SqlConnection(sqlconn);

            //事务对象
            SqlTransaction trans = null;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                //事务对象做初始化
                trans = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sql, conn, trans);
                int num = cmd.ExecuteNonQuery();
                //没有错误，就最终提交
                trans.Commit();
                return num;
            }
            catch (Exception ex)
            {
                //一旦有错误，就进行数据回滚
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }


        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQueryInt(string sql)
        {

            //链接对象
            SqlConnection conn = new SqlConnection(sqlconn);

            //事务对象
            SqlTransaction trans = null;

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                //事务对象做初始化
                trans = conn.BeginTransaction();

                SqlCommand cmd = new SqlCommand(sql, conn, trans);
                int num =Convert.ToInt32( cmd.ExecuteScalar());
                //没有错误，就最终提交
                trans.Commit();
                return num;
            }
            catch (Exception ex)
            {
                //一旦有错误，就进行数据回滚
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }


        }


        public DataTable QueryDataList(string sql, int pageSzie, int pageIndex, string sort, out int recordCount)
        {

            //设置存储过程参数
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("Source",SqlDbType.NVarChar),
                new SqlParameter("PageSize",SqlDbType.Int),
                new SqlParameter("CurrentPage",SqlDbType.Int),
                new SqlParameter("FieldList",SqlDbType.NVarChar),
                new SqlParameter("Sort",SqlDbType.NVarChar),
                new SqlParameter("RecordCount",SqlDbType.Int),
                new SqlParameter("FdName",SqlDbType.NVarChar)
            };

            //给参数赋值
            paras[0].Value = sql;
            paras[1].Value = pageSzie;
            paras[2].Value = pageIndex;
            paras[3].Value = DBNull.Value;
            paras[4].Value = sort;
            paras[5].Value = DBNull.Value;
            paras[6].Value = DBNull.Value;

            //指明参数为输出参数
            paras[5].Direction = ParameterDirection.Output;

            SqlConnection conn = new SqlConnection(sqlconn);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("pro_sys_GetRecordByPage", conn);
            //指明执行的是存储过程
            cmd.CommandType = CommandType.StoredProcedure;

            //给Command加入参数

            for (int i = 0; i < paras.Length; i++)
            {
                cmd.Parameters.Add(paras[i]);
            }

            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                recordCount = (int)paras[5].Value;
                return dt;

            }

        }
    }
}
