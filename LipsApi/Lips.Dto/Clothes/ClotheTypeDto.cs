using Lips.Dto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Clothes
{
    public class ClotheTypeDto : BaseDto
    {
        public new int Id { get; set; }

        public string Name { get; set; }

        public long ExternalClotheId { get; set; }
        public int ExternalGroupCodeId { get; set; }
        public string ExternalGroupName { get; set; }

        public int Total { get; set; }

    }
}
