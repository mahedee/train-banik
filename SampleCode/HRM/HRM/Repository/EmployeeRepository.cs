using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        HRMContext context;
        public EmployeeRepository(HRMContext context)
        {
            this.context = context;
        }

        public IQueryable<Employee> All
        {
            get { return context.Employees; }
        }

        public Employee Find(int? id)
        {
            Employee objEmployee = new Employee();
            objEmployee = context.Employees.Where(p => p.Id == id).FirstOrDefault();
            return objEmployee;
        }

        public void InsertOrUpdate(Employee employee)
        {
            if (employee.Id == default(int))
            {
                // New entity
                context.Employees.Add(employee);
            }
            else
            {
                // Existing entity
                context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }


    public interface IEmployeeRepository : IDisposable
    {
        IQueryable<Employee> All { get; }
        Employee Find(int? id);
        void InsertOrUpdate(Employee employee);
        void Delete(int id);
        void Save();
    }
}