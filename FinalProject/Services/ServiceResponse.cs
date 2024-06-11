using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Services
{
    public class ServiceResponse<T>
    {
        /*
         * 1. remove not used usings
         * 2. actually i do not think you need such class, it is small application, it will be more problematic and will look
         * more complicated with this approach.
         * 3. OPTIONAL: just to remove all ServiceResponses
         */
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
