namespace Template.Data
{
    using Template.Data.Repositories;
    using Template.Models;

    public interface IStudentData
    {
        IRepository<Student> Students { get; }

        void SaveChanges();
    }
}