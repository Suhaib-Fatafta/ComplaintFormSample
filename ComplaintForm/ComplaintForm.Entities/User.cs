using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplaintForm.Entities
{
    [Table("USER")]
    public class User
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("FULL_NAME")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Column("PASSWORD")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [Column("ROLE")]
        [StringLength(100)]
        public string Role { get; set; }
        public virtual ICollection<UserForms> UserForms { get; set; }
    }
}
