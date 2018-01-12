using System;
using IndieRadar.Model.Models.Base;

namespace IndieRadar.Model.Models
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            CommentDate = DateTime.Now;
        }

        public String CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}