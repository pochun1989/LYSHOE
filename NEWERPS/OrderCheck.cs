using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NEWERPS
{
    class OrderCheck
    {
        Boolean ok = true;

        //static DDBHSave _ddbh = new DDBHSave();
        //internal static DDBHSave DDBH { get => _ddbh; set => _ddbh = value; }

        public Boolean check (string DDBH) 
        {
            Console.WriteLine(DDBH);
            string check1, check2, check3, check4, check5;
            check1 = DDBH;
            check2 = DDBH;
            check3 = DDBH;
            check4 = DDBH;
            check5 = DDBH;

            int length = DDBH.Length; 

            //for (int i = 0 ; i < length ; i++) 
            //{
            //    check5 = check5.Substring(i, 1);
            //    Console.WriteLine(check5);
            //    if (check5 == " ") 
            //    {
            //        ok = false;
            //        return ok;
            //    }
            //}

            check1 = check1.Substring(0, 1);
            Console.WriteLine(check1);
            if (check1 == "S" || check1 == "C" || check1 == "F")
            {
                ok = true;
            }
            else 
            {
                ok = false;
                return ok;
            }

            check2 = check2.Substring(3, 1);
            Console.WriteLine(check2);
            if (check2 == "V" || check2 == "C" )
            {
                ok = true;
            }
            else
            {
                ok = false;
                return ok;
            }


            check3 = check3.Substring(8, 1);
            Console.WriteLine(check3);
            if (check3 == "N" || check3 == "F")
            {
                ok = true;
            }
            else
            {
                ok = false;
                return ok;
            }


            check4 = check4.Substring(1, 2);
            Console.WriteLine(check4);
            int customer = 0;
            DBconnect dbConn1 = new DBconnect();
            string sql1 = string.Format("select count(kfdh) as count from kfzl where dybh = '{0}'", check4);
            SqlCommand cmd1 = new SqlCommand(sql1, dbConn1.connection);
            dbConn1.OpenConnection();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                customer = int.Parse(reader1["count"].ToString());
            }
            dbConn1.CloseConnection();

            if (customer == 1) 
            {
                ok = true;
            }
            else
            {
                ok = false;
                return ok;
            }

            //ok = true;
            return ok;
        }
    }
}
