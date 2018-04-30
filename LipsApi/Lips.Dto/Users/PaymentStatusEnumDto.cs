using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Users
{
    public enum PaymentStatusEnumDto
    {
        New = 1,
        Success = 2,
        Pending = 3,
        Cancelled = 4,
        Failure = 5,
        Rejected = 6
    }
}
