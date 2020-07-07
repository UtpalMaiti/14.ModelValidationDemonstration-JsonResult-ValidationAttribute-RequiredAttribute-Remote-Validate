using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidationDemonstration.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Please Enter Employee ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [StringLength(20, ErrorMessage = "Name should not exceed more than 20 characters")]
        [Remote("ValidateName", "Home")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Email ID")]
        [RegularExpression(@"\w+([._-]\w+)*@\w+([._-]\w+)*\.\w+([._-]\w+)*",
            ErrorMessage = "Please Enter Valid Email ID")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Qualification")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Date Of Joining")]
        [FutureDate(ErrorMessage = "Date Of Joining should not be a Past Date")]
        public DateTime DOJ { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Please Accept the Terms and Conditions")]
        public bool IsTermsAccepted { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value >= DateTime.Now ? true : false;
        }
    }

    public class FutureDate2Attribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            bool isDataExists = base.IsValid(value);
            if (!isDataExists)
            {
                ErrorMessage = "Please enter Date of Joining";
                return false;
            }

            bool isFutureDate = (DateTime)value >= DateTime.Now ? true : false;

            if (!isFutureDate)
            {
                ErrorMessage = "Past date Can not be accepted as DOJ";
            }

            return isFutureDate;
        }
    }
}