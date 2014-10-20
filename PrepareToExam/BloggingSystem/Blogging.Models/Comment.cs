namespace Blogging.Models
{
    using System;
    using System.Collections.Generic;    

    public class Comment
    {
        public Comment()
        {
            this.Authors = new HashSet<BlogUser>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuthorId { get; set; }

        public virtual ICollection<BlogUser> Authors { get; set; }
    }
}