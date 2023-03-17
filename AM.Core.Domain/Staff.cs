using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }


        //TP1.Q12.A
        public override string GetPassengerType()
        {
            return base.GetPassengerType()+ " I am a staff";
        }
        public override string ToString()
        {
            return base.ToString() + 
                " ;EmploymentDate: " + EmploymentDate + " ;Function: "
                + Function + " ;Salary " + Salary;
        }
    }
}
