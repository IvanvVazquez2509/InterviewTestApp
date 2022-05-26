using InterviewTestApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestApp.Domain.Entites
{
    public class HealthCheck : BaseModel
    {
        public string Message { get; set; }
    }
}
