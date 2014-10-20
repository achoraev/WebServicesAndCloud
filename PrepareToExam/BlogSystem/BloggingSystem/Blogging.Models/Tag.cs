namespace Blogging.Models
{
    using System;
    using System.Collections.Generic;    

    public class Tag
    {
        public Tag()
        {
            this.Authors = new HashSet<BlogUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BlogUser> Authors { get; set; }
    }
}