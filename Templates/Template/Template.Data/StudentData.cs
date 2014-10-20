namespace Template.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Template.Data.Repositories;
    using Template.Models;

    public class StudentData : IStudentData
    {
        // Unit of Work
        private ITemplateDbContext context;
        private IDictionary<Type, object> repositories;

        public StudentData()
            : this(new TemplateDbContext())
        {
        }              

        public IRepository<Student> Students
        {
            get
            {
                return this.GetRepository<Student>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public StudentData(ITemplateDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        // Unit of Work
        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Student)))
                {
                    type = typeof(Repository<Student>);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }    
    }
}