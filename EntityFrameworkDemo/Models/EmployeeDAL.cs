using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class EmployeeDAL
    {
        private ApplicationDbContext db;

        public EmployeeDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Employee> GetEmployees()
        {
            //LINQ
          /*  var model = (from emp in db.Employees
                         select emp).ToList();
            return model;*/

            //Lambda Expression
            return db.Employees.ToList();
        }

        public Employee GetEmployeeByID(int id) 
        {
            //LINQ
           /* var model = (from emp in db.Employees
                         where emp.Id == id
                         select emp).FirstOrDefault();
            return model;*/
           
            //Lambda Expression
            var model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return model;
        }

        public int AddEmployee(Employee employee)
        {
            int result = 0;
            // add object in DbSet
            db.Employees.Add(employee); // Add method will add emp object in DbSet
            //update the changes in DB
            result = db.SaveChanges(); // SaveChanges() reflect the changes from DbSet to DB
            return result;

        }

        public int UpdateEmployee(Employee employee)
        {
            int result = 0;
            var model = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (model != null)
            {
                model.Name = employee.Name;
                model.City = employee.City;
                model.Salary = employee.Salary;
                result = db.SaveChanges(); // SaveChanges() reflect the changes from DbSet to DB

            }
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int result = 0;
            var model = db.Employees.Where(x => x.Id == id).SingleOrDefault();
            if (model != null)
            {
                // remove from dbSet
                db.Employees.Remove(model);
                result = db.SaveChanges();
            }
            return result;
        }

    }
}

