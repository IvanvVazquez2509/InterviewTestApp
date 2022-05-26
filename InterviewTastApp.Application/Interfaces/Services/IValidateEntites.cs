using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTastApp.Application.Interfaces.Services
{
    public interface IValidateEntites
    {
        Task<bool> IsValid(int branchId);
    }
}
