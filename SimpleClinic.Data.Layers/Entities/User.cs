using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(1000)]
        public string Username1 { get; set; }

        public string Password { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        //[ForeignKey("CreatorId")]
        public int? CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime Created { get; set; }

        //[ForeignKey("ModifierId")]
        public int? ModifierId { get; set; }

        public virtual User Modifier { get; set; }

        public DateTime Modified { get; set; }

        public virtual ICollection<User> CreatedUsers { get; set; }
    }
}
