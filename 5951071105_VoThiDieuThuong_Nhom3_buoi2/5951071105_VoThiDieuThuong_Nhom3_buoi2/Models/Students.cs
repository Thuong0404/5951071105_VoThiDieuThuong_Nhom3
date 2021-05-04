using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5951071105_VoThiDieuThuong_Nhom3_buoi2.Models
{
    public class Students
    {
        public int ID { get; set; }
        public string f_Name { get; set; }
        public string m_Name { get; set; }
        public string l_Name { get; set; }
        public string Address { get; set; }
        public string birthdate { get; set; }
        public string score { get; set; }
        public string dep_id{ get; set; }
    }
    public class ReadStudents: Students
    {
        public ReadStudents(DataRow row)
        {
            ID = Convert.ToInt32(row["ID"]);
            f_Name = row["f_Name"].ToString();
            l_Name = row["l_Name"].ToString();
            m_Name = row["m_Name"].ToString();
            Address = row["Address"].ToString();
            birthdate = row["birthdate"].ToString();
            score= row["score"].ToString();
            dep_id=row["dep_id"].ToString();
        }

    }
    public class createStudents : Students
    {}
}