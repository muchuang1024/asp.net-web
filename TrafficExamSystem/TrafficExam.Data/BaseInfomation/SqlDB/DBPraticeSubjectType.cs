using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficExam.Interface;
using TrafficExam.Model;
using System.Data.SqlClient;
using System.Data;
using TrafficExam.Command;

namespace TrafficExam.Data
{
    public class DBPraticeSubjectType : IPraticeSubjectType
    {
        public bool SetSubjectList(string SubjectIdlist, int once, int more, int deter, string loginName)
        {
           
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@SubjectTypeName", DbType.String);
            sp[0].Value = SubjectIdlist;
            sp[1] = new SqlParameter("@Once", DbType.String);
            sp[1].Value = once;
            sp[2] = new SqlParameter("@More", DbType.String);
            sp[2].Value = more;
            sp[3] = new SqlParameter("@Deter", DbType.String);
            sp[3].Value = deter;
            sp[4] = new SqlParameter("@LoginName", DbType.String);
            sp[4].Value = loginName;
            return SqlHelper.ExecuteSqlText(CommandType.StoredProcedure, "Proc_GetPraticeSubject", sp);
        }
    }
}
