using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class StudentDAL
    {
        private ApplicationDbContext db;

        public StudentDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        //list 
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var std = db.Students.FirstOrDefault(s => s.Id == id);
            return std;
        }
        private static decimal CalculatePercentage(double sub1, double sub2, double sub3, double sub4)
        {
            return (decimal)((sub1 + sub2 + sub3 + sub4) / 4);
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            student.Percentage = CalculatePercentage(student.SQL, student.Angular, student.Java, student.DotNet);
            db.Students.Add(student);
            result = db.SaveChanges();
            return result;
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;
            var model = db.Students.FirstOrDefault(s => s.Id == student.Id);
            if (model != null)
            {
                model.Name = student.Name;
                model.Java = student.Java;
                model.DotNet = student.DotNet;
                model.SQL = student.SQL;
                model.Angular = student.Angular;
                model.Percentage = CalculatePercentage(student.SQL, student.Angular, student.Java, student.DotNet);

                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var model = db.Students.FirstOrDefault(s => s.Id == id);
            if (model != null)
            {
                db.Students.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
