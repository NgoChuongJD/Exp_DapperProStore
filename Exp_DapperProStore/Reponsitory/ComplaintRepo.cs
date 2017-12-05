using Dapper;
using Exp_DapperProStore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exp_DapperProStore.Reponsitory
{
    public class ComplaintRepo
    {
        SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString(); 
            con = new  SqlConnection(constr);
        }
        public string AddComplaint(ComplaintModel Obj)
        {
            DynamicParameters ObjParm = new DynamicParameters();
            ObjParm.Add("@ComplaintType", Obj.ComplaintType);
            ObjParm.Add("@ComplaintDesc", Obj.ComplaintDesc);
            ObjParm.Add("@ComplaintId", dbType: System.Data.DbType.String, direction: System.Data.ParameterDirection.Output, size: 951652);
            con.Open();
            con.Execute("AddComplaint", ObjParm, commandType: CommandType.StoredProcedure);
            var ComplaintId = ObjParm.Get<string>("@ComplaintId");
            con.Close();
            return ComplaintId;
        }
    }
}