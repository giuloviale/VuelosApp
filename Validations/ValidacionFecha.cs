using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Validations
{
    public class ValidacionFecha : ValidationAttribute
    {
        public ValidacionFecha()
        {
            ErrorMessage = "La fecha ingresada es menor a la fecha actual";
        }
        public override bool IsValid(object value)
        {
            {
                return DateTime.Compare(DateTime.Now, Convert.ToDateTime(value))<0;
            }
           
        }
    }
}