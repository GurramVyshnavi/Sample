using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Exceptions
{
    /// <summary>
    /// Custom Exception class created for student management system
    /// </summary>
    public class Student_Exceptions : ApplicationException
    {
        public Student_Exceptions() : base()
        {

        }
        public Student_Exceptions(string errormsg) : base(errormsg)
        {

        }
    }
}