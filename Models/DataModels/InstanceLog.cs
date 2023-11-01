using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.DataModels
{
    [Table("INSTANCE_LOG")]
    public class InstanceLog : BaseModel
    {
        [Required]
        [Column("RAN_SUCCESSFULLY")]
        public bool IsSuccess { get; set; }
    }
}
