using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities;

public class Imtixonlar : BaseEntity,IAuditedEntity
{
    public string Name { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
