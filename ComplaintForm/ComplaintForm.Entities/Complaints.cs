using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintForm.Entities
{
    [Table("COMPLAINTS")]
    public class Complaints
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("COMPLAINT_TYPE")]
        [StringLength(200)]
        public string ComplaintType { get; set; }

        [Column("FORM_ID")]
        public string FormId { get; set; }

        public virtual UserForms UserForm { get; set; }
    }
}
