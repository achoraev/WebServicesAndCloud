namespace Blogging.Models
{
    using System;

    public class BlogUser
    {
        public Guid Username { get; set; }

        public string Name { get; set; }

        public string AuthCode { get; set; }
    }
}