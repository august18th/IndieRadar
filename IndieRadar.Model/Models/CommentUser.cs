using System;
using IndieRadar.Model.Models.Base;

namespace IndieRadar.Model.Models
{
    public class CommentUser : BaseEntity
    {
        public Int32 CommentId { get; set; }
        public Comment Comment { get; set; }

        public String UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}