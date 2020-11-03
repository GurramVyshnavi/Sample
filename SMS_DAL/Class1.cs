using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Entities;
using SMS_Exceptions;

namespace SMS_DAL
{
    public class StudentDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;
        List<Student> myStudents = null;
        DataTable mydt = null;
        public StudentDAO()
        {
            //init con
            con = new SqlConnection();
            con.ConnectionString = "Server=.\\SqlExpress;Integrated Security=true;DataBase=Lavanya";
        }

        public List<Student> ShowAllStudents()
        {
            //write your logic
            try
            {
                con.Open();
                //init cmd
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from students";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //exec cmd
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);

                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                }
                foreach (DataRow rw in mydt.Rows)
                {
                    //Converting datarow in class(Student) instanceor obj
                    Student s1 = new Student();
                    s1.rollNo = Int32.Parse(rw[0].ToString());
                    s1.name = rw[1].ToString();
                    s1.Addr = rw[2].ToString();

                    //Adding obj to list
                    myStudents.Add(s1);
                }
            }
            catch (SqlException se)
            {
                throw new Student_Exceptions(se.Message);
            }
            catch (Exception e)
            {
                throw new Student_Exceptions(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudents;
        }
        public List<Student> SearchStudentById(int id)
        {
            //write your logic
            try
            {
                con.Open();
                //create parameters for cmd
                SqlParameter p1;
                p1 = new SqlParameter("@rno", id);
                //init cmd
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from students where rollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //Adding param to cmd
                cmd.Parameters.Add(p1);

                //exec cmd
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);

                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow rw in mydt.Rows)
                    {
                        //Converting datarow in class(Student) instanceor obj
                        Student s1 = new Student();
                        s1.rollNo = Int32.Parse(rw[0].ToString());
                        s1.name = rw[1].ToString();
                        s1.Addr = rw[2].ToString();

                        //Adding obj to list
                        myStudents.Add(s1);
                    }
                }
                else
                {
                    throw new Student_Exceptions("Roll number doesn't exist...");
                }
            }
            catch (SqlException se)
            {
                throw new Student_Exceptions(se.Message);
            }
            catch (Exception e)
            {
                throw new Student_Exceptions(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudents;
        }
        public bool AddStudent(Student s1)

        {
            bool flag = false;
            try
            {
                con.Open();
                //create parameters for cmd
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@nam", s1.name);
                param[1] = new SqlParameter("@rno", s1.rollNo);
                param[2] = new SqlParameter("@add", s1.Addr);
                //init cmd
                cmd = new SqlCommand();
                cmd.CommandText = "Insert into students(Name,RollNo,Addr)values(@nam,@rno,@add)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //Adding param to cmd
                cmd.Parameters.AddRange(param);
                int recCount = cmd.ExecuteNonQuery();
                if (recCount > 0)
                {
                    flag = true;
                }

            }
            catch (SqlException se)
            {
                throw new Student_Exceptions(se.Message);
            }
            catch (Exception e)
            {
                throw new Student_Exceptions(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
        public bool UpdateStudent(Student s1)
        {
            bool flag = false;
            try
            {
                con.Open();
                //create parameters for cmd
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@nam", s1.name);
                param[1] = new SqlParameter("@rno", s1.rollNo);
                param[2] = new SqlParameter("@add", s1.Addr);
                //init cmd
                cmd = new SqlCommand();
                cmd.CommandText = "Update students set name=@nam,Addr=@adr where rollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //Adding param to cmd
                cmd.Parameters.AddRange(param);
                int recCount = cmd.ExecuteNonQuery();
                if (recCount > 0)
                {
                    flag = true;
                }
            }
            catch (SqlException se)
            {
                throw new Student_Exceptions(se.Message);
            }
            catch (Exception e)
            {
                throw new Student_Exceptions(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
        public bool DropStudent(int id)
        {
            bool flag = false;
            try
            {
                con.Open();
                //create parameters for cmd
                SqlParameter p1;
                p1 = new SqlParameter("@rno", id);
                //init cmd
                cmd = new SqlCommand();
                cmd.CommandText = "Delete from students where rollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //Adding param to cmd
                cmd.Parameters.Add(p1);
                int recCount = cmd.ExecuteNonQuery();
                if (recCount > 0)
                {
                    flag = true;
                }


            }
            catch (SqlException se)
            {
                throw new Student_Exceptions(se.Message);
            }
            catch (Exception e)
            {
                throw new Student_Exceptions(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return flag;
        }
    }
}