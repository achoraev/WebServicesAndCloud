namespace Blogging.Models
{
    using System;

    public class BlogUser
    {
        public BlogUser() 
        {
            this.Id = Guid.NewGuid();            
        }  
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AuthCode { get; set; }
    }
}