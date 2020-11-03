using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Add refrences
using SMS_Entities;
using SMS_Exceptions;
using SMS_DAL;

namespace SMS_BL
{
    public class StudentBL
    {

        StudentDAO sDao;
        public StudentBL()
        {
            sDao = new StudentDAO();
        }
        public bool ValidateAll()
        {
            return true;
        }
        public List<Student> ShowAllStudents()
        {
            return sDao.ShowAllStudents();
        }
        public List<Student> SearchStudentById(int id)
        {
            return sDao.SearchStudentById(id);
        }
        public bool AddStudent(Student s1)
        {
            return sDao.AddStudent(s1);
        }
        public bool UpdateStudent(Student stud)
        {
            bool flag = false;
            if (ValidateAll())
            {
                flag = sDao.UpdateStudent(stud);
            }
            return sDao.UpdateStudent(stud);
        }
        public bool DropStudent(int id)
        {
            return sDao.DropStudent(id);
        }
    }
}