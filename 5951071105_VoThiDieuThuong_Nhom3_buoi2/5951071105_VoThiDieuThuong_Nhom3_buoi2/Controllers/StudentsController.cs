using _5951071105_VoThiDieuThuong_Nhom3_buoi2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _5951071105_VoThiDieuThuong_Nhom3_buoi2.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        private SqlConnection conn;
       public  SqlDataAdapter adapter;

       

        // GET api/<controller>
        public IEnumerable<Students> Get()
        {
            conn = new SqlConnection("Data Source=LAPTOP-E01MG43U\\SQLEXPRESS02;Initial Catalog=API;Integrated Security=true");
            DataTable dt = new DataTable();
            var sql = "SELECT* FROM Students";
            adapter = new SqlDataAdapter {
                SelectCommand = new SqlCommand(sql, conn)

        };
            adapter.Fill(dt);
            List<Students> students = new List<Students>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow studentsReocord in dt.Rows)
                {
                    students.Add(new ReadStudents(studentsReocord));
                }
            }

            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Students> Get(int ID)
        {
            conn = new SqlConnection("Data Source=LAPTOP-E01MG43U\\SQLEXPRESS02;Initial Catalog=API;Integrated Security=true");
            DataTable dt = new DataTable();
            var sql = "SELECT* FROM Students WHERE ID="+ ID;
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(sql, conn)

            };
            adapter.Fill(dt);
            List<Students> students = new List<Students>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentsReocord in dt.Rows)
                {
                    students.Add(new ReadStudents(studentsReocord));
                }
            }

            return students;
        }

        // POST api/<controller>
        public String Post([FromBody] createStudents value)

        {
            conn = new SqlConnection("Data Source=LAPTOP-E01MG43U\\SQLEXPRESS02;Initial Catalog=API;Integrated Security=true");
            var sql1 = "INSERT INTO Students(f_Name,l_Name,m_Name,Address,birthdate,score)values(@f_Name,@l_Name,@m_Name,@Address,@birthdate,@score)";
            SqlCommand insertCommand = new SqlCommand(sql1, conn);
            insertCommand.Parameters.AddWithValue("@f_Name",value.f_Name);
            insertCommand.Parameters.AddWithValue("@l_Name",value.l_Name);
            insertCommand.Parameters.AddWithValue("@m_Name",value.m_Name);
            insertCommand.Parameters.AddWithValue("@Address",value.Address);
            insertCommand.Parameters.AddWithValue("@birthdate",value.birthdate);
            insertCommand.Parameters.AddWithValue("@score", value.score);

            conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Them thanh cong";
            }
            else
            {
                return "Them that bai";
            }
        }

        // PUT api/<controller>/5
        public String Put(int ID, [FromBody] createStudents value)
        {
            conn = new SqlConnection("Data Source=LAPTOP-E01MG43U\\SQLEXPRESS02;Initial Catalog=API;Integrated Security=true");
            var sql1 = "UPDATE Students SET  f_Name=@f_Name,l_Name=@l_Name,m_Name=@m_Name,Address=@Address,birthdate=@birthdate,score=@score WHERE ID= "+ID;
            SqlCommand updateCommand = new SqlCommand(sql1, conn);
            updateCommand.Parameters.AddWithValue("@f_Name", value.f_Name);
            updateCommand.Parameters.AddWithValue("@l_Name", value.l_Name); 
            updateCommand.Parameters.AddWithValue("@m_Name", value.m_Name);
            updateCommand.Parameters.AddWithValue("@Address", value.Address);
            updateCommand.Parameters.AddWithValue("@birthdate", value.birthdate);
            updateCommand.Parameters.AddWithValue("@score", value.score);

            conn.Open();
            int result = updateCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Sua thanh cong";
            }
            else
            {
                return "Sua that bai";
            }
        }

        // DELETE api/<controller>/5
        public String Delete(int id)
        {
            conn = new SqlConnection("Data Source=LAPTOP-E01MG43U\\SQLEXPRESS02;Initial Catalog=API;Integrated Security=true");
            var sql1 = "DELETE FROM Students WHERE ID="+id;
            SqlCommand insertCommand = new SqlCommand(sql1, conn);
           

            conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Xoa thanh cong";
            }
            else
            {
                return "Xoa that bai";
            }
        }
    }
}