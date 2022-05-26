using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Se presentaron uno o mas errores de validación")
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public List<string> Errors { get; }
    }
}
