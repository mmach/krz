using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Users
{
    public  enum PaymentStatusEnum
    {
        New = 1,
        Success = 2,
        Pending = 3,
        Cancelled = 4,
        Failure = 5,
        Rejected = 6

    }
}
