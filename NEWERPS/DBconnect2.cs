using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NEWERPS
{
    class DBconnect2
    {
        //private string _connString = @"Data Source = 192.168.11.15; Initial Catalog = LY_SHOE ; User Id = yijhan ; Password = sa123yo ";
        private string _connString = @"Data Source = 192.168.88.240; Initial Catalog = LY_SHOE; User Id = yijhan ; Password = sa123yo ";
        private SqlConnection _connection; // 連線欄位

        public SqlConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connString);
                }
                return _connection;
            }
        }

        #region 開啟資料庫連接

        /// <summary>
        /// 開啟資料庫連接
        /// </summary>
        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
        }

        #endregion

        #region 關閉資料庫連接

        /// <summary>
        /// 關閉資料庫連接
        /// </summary>
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open || connection.State == ConnectionState.Broken)
            {
                connection.Close();
            }
        }

        #endregion   
    }
}
