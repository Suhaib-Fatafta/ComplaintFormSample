using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintForm.Entities
{
    [Table("USER_FORMS")]
    public class UserForms
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [Required]
        [Column("USER_NAME")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [Column("COMPLAINT_TITLE")]
        [StringLength(100)]
        public string ComplaintTitle { get; set; }
        [Required]
        [Column("IS_RECURRING")]
        [StringLength(50)]
        public string IsRecurring { get; set; }

        [Required]
        [Column("COMPLAINT_DETAILS")]
        public string ComplaintDetails { get; set; }

        [Column("LOG_DATE")]
        public DateTime LogDate { get; set; }

        [Column("STATUS_ID")]
        public int StatusId { get; set; }

        [Column("USER_ID")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Complaints> Complaints { get; set; }
    }
}
