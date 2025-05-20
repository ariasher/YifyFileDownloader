using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyCommon.Models.DataModels
{
    [Index(nameof(IsActive))]
    [Index(nameof(DeletedAt))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(IsSuccess))]
    [Table("INSTANCE_LOGS")]
    public class InstanceLogs : BaseModel
    {
        [Required]
        [Column("RAN_SUCCESSFULLY")]
        public bool IsSuccess { get; set; }
    }
}
