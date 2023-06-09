﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [DataType(DataType.DateTime,ErrorMessage ="Enter a valid date format")]
        public DateTime BirthDate { get; set; }
        [Key]
        [MaxLength(7,ErrorMessage ="Max length 7"),MinLength(7,ErrorMessage ="min length 7")]
        public string PassportNumber { get; set; }
        [EmailAddress(ErrorMessage ="Enter a valid Email")]
        public string EmailAddress { get; set; }
        [MinLength(3,ErrorMessage ="Min length 3"),MaxLength(25,ErrorMessage ="Max length 25")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone(ErrorMessage ="Phone number")]
        public string TelNumber { get; set; }

        //TP1.Q 14
        int age;
        public int Age
        {
            get
            {
                age = DateTime.Now.Year - BirthDate.Year;

                if (BirthDate.Month > DateTime.Now.Month)
                {
                    age -= 1;
                }
                else if (
            BirthDate.Month == DateTime.Now.Month
                    && BirthDate.Day > DateTime.Now.Day)
                {
                    age--;
                }
                return age;
            }
        }

        public IList<Flight> Flights { get; set; }


    //TP 1 . Q11.A
     //   public bool CheckProfile(string nom, string prenom) 
     //   {
     //       return FirstName == prenom && LastName == nom;
     //   }
     //TP1 .Q11.B
     //   public bool CheckProfile(string email, string nom, string prenom)
     //   {
     //       return EmailAddress == email && LastName ==nom && FirstName== prenom;
     //   }

        //TP1.Q11.C
        public bool CheckProfile(string nom, string prenom, string email=null)
        {
            return EmailAddress == email && LastName == nom && FirstName == prenom;
        }

        //TP1.Q12.A
        public virtual string GetPassengerType()
        {
            return "I am a passenger";
        } 

        //TP1.Q13
        public void GetAge(DateTime birthDate, ref int calculatedAge)
        {
            calculatedAge = DateTime.Now.Year- birthDate.Year;
            if (birthDate.Month > DateTime.Now.Month)
            {
                calculatedAge -= 1;
            }else if (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day) 
            {
                calculatedAge--;
            }
        }
     //  public void GetAge(Passenger aPassenger)
     //  {
     //      aPassenger.Age = DateTime.Now.Year - aPassenger.BirthDate.Year;
     //      if (aPassenger.BirthDate.Month > DateTime.Now.Month)
     //      {
     //          aPassenger.Age -= 1;
     //      }
     //      else if (aPassenger.BirthDate.Month == DateTime.Now.Month 
     //          && aPassenger.BirthDate.Day > DateTime.Now.Day)
     //      {
     //          aPassenger.Age--;
     //      }
     //  }
        public override string ToString()
        {
            return "BirthDate: " + BirthDate + " ;PassportNumber: "
                + PassportNumber + " ;EmailAddress: " + EmailAddress
                + " ;FirstName: " + FirstName + " ;LastName: "
                + LastName + " ;TelNumber: " + TelNumber;
        }

    }
}
