using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Entities
{
    public class Student
    {
        #region Variables
        int RollNo;
        string Name;
        string addr;
        #endregion

        #region Properties
        public int rollNo { get => RollNo; set => RollNo = value; }
        public string name { get => Name; set => Name = value; }
        public string Addr { get => addr; set => addr = value; }
        #endregion

        #region Constructors
        public Student()
        {

        }
        /// <summary>
        /// Parameterized Constructor for Student
        /// </summary>
        /// <param name="rno">Roll Number</param>
        /// <param name="name">Name of the Candidate</param>
        /// <param name="addr">Permanent Address</param>
        public Student(int rno, string name, string addr)
        {
            RollNo = rno;
            Name = name;
            Addr = addr;

        }
        #endregion


    }
}