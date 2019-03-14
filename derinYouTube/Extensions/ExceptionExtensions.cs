using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derinYouTube.Extensions
{
    public static class ExceptionExtensions
    {
        public static string ToMessage(this DbEntityValidationException ex)
        {
            var errorMessage = "";
            foreach (var eve in ex.EntityValidationErrors)
            {
                errorMessage =
                    $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:";
                foreach (var ve in eve.ValidationErrors)
                {
                    errorMessage += $"\r\n- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";
                }
            }
            return errorMessage;
        }
    }
}
