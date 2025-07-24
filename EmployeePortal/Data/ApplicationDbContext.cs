﻿using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Prevent cascade delete on Designation FK
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Designation)
            .WithMany()
            .HasForeignKey(e => e.DesignationId)
            .OnDelete(DeleteBehavior.Restrict);

            // Seed EmployeeTypes
            modelBuilder.Entity<EmployeeType>().HasData(
                new EmployeeType { Id = 1, Name = "Permanent" },
                new EmployeeType { Id = 2, Name = "Temporary" },
                new EmployeeType { Id = 3, Name = "Contract" },
                new EmployeeType { Id = 4, Name = "Intern" }
            );

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" },
                new Department { Id = 3, Name = "Sales" },
                new Department { Id = 4, Name = "Admin" }
            );

            // Seed Designations with DepartmentId
            modelBuilder.Entity<Designation>().HasData(
                new Designation { Id = 1, Name = "Software Developer", DepartmentId = 1 },
                new Designation { Id = 2, Name = "System Administrator", DepartmentId = 1 },
                new Designation { Id = 3, Name = "Network Engineer", DepartmentId = 1 },
                new Designation { Id = 4, Name = "HR Specialist", DepartmentId = 2 },
                new Designation { Id = 5, Name = "HR Manager", DepartmentId = 2 },
                new Designation { Id = 6, Name = "Talent Acquisition Coordinator", DepartmentId = 2 },
                new Designation { Id = 7, Name = "Sales Executive", DepartmentId = 3 },
                new Designation { Id = 8, Name = "Sales Manager", DepartmentId = 3 },
                new Designation { Id = 9, Name = "Account Executive", DepartmentId = 3 },
                new Designation { Id = 10, Name = "Office Manager", DepartmentId = 4 },
                new Designation { Id = 11, Name = "Executive Assistant", DepartmentId = 4 },
                new Designation { Id = 12, Name = "Receptionist", DepartmentId = 4 }
            );

            // Seed initial data
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "John Doe", Email = "johnd@gmail.com", DepartmentId = 1, DesignationId = 1, HireDate = new DateTime(2020, 1, 15), DateOfBirth = new DateTime(1990, 3, 12), EmployeeTypeId = 1, Gender = "Male", Salary = 60000m },
                new Employee { Id = 2, FullName = "Jane Smith", Email = "janed@gmail.com", DepartmentId = 2, DesignationId = 5, HireDate = new DateTime(2018, 5, 20), DateOfBirth = new DateTime(1985, 8, 22), EmployeeTypeId = 1, Gender = "Female", Salary = 80000m },
                new Employee { Id = 3, FullName = "Sam Wilson", Email = "samw@gmail.com", DepartmentId = 3, DesignationId = 7, HireDate = new DateTime(2021, 3, 10), DateOfBirth = new DateTime(1992, 6, 30), EmployeeTypeId = 3, Gender = "Male", Salary = 50000m },
                new Employee { Id = 4, FullName = "Wanda Maximoff", Email = "wandam@gmail.com", DepartmentId = 4, DesignationId = 11, HireDate = new DateTime(2022, 7, 5), DateOfBirth = new DateTime(1995, 11, 15), EmployeeTypeId = 2, Gender = "Female", Salary = 40000m },
                new Employee { Id = 5, FullName = "Tony Stark", Email = "tonys@gmail.com", DepartmentId = 1, DesignationId = 1, HireDate = new DateTime(2019, 4, 18), DateOfBirth = new DateTime(1989, 2, 25), EmployeeTypeId = 1, Gender = "Male", Salary = 95000m },
                new Employee { Id = 6, FullName = "Natasha Romanoff", Email = "natashar@gmail.com", DepartmentId = 2, DesignationId = 4, HireDate = new DateTime(2017, 10, 12), DateOfBirth = new DateTime(1987, 9, 10), EmployeeTypeId = 1, Gender = "Female", Salary = 75000m },
                new Employee { Id = 7, FullName = "Alexei Shostakov", Email = "alexeis@gmail.com", DepartmentId = 3, DesignationId = 8, HireDate = new DateTime(2020, 2, 20), DateOfBirth = new DateTime(1990, 1, 5), EmployeeTypeId = 3, Gender = "Male", Salary = 85000m },
                new Employee { Id = 8, FullName = "Yelena Belova", Email = "yelenab@gmail.com", DepartmentId = 4, DesignationId = 10, HireDate = new DateTime(2021, 6, 8), DateOfBirth = new DateTime(1993, 4, 18), EmployeeTypeId = 1, Gender = "Female", Salary = 65000m },
                new Employee { Id = 9, FullName = "Sue Storm", Email = "sues@gmail.com", DepartmentId = 2, DesignationId = 4, HireDate = new DateTime(2022, 8, 15), DateOfBirth = new DateTime(1997, 12, 20), EmployeeTypeId = 3, Gender = "Female", Salary = 52000m },
                new Employee { Id = 10, FullName = "Steve Rogers", Email = "stever@gmail.com", DepartmentId = 2, DesignationId = 6, HireDate = new DateTime(2018, 11, 25), DateOfBirth = new DateTime(1986, 7, 12), EmployeeTypeId = 2, Gender = "Other", Salary = 55000m },
                new Employee { Id = 11, FullName = "Morgan Stark", Email = "morgans@gmail.com", DepartmentId = 3, DesignationId = 7, HireDate = new DateTime(2024, 9, 10), DateOfBirth = new DateTime(2001, 5, 6), EmployeeTypeId = 4, Gender = "Female", Salary = 30000m },
                new Employee { Id = 12, FullName = "Bucky Barnes", Email = "buckyb@gmail.com", DepartmentId = 4, DesignationId = 12, HireDate = new DateTime(2020, 10, 3), DateOfBirth = new DateTime(1996, 8, 21), EmployeeTypeId = 2, Gender = "Male", Salary = 38000m },
                new Employee { Id = 13, FullName = "Peter Parker", Email = "peterp@gmail.com", DepartmentId = 1, DesignationId = 2, HireDate = new DateTime(2018, 12, 1), DateOfBirth = new DateTime(1991, 9, 18), EmployeeTypeId = 1, Gender = "Male", Salary = 65000m },
                new Employee { Id = 14, FullName = "Pepper Potts", Email = "pepperp@gmail.com", DepartmentId = 2, DesignationId = 4, HireDate = new DateTime(2017, 11, 30), DateOfBirth = new DateTime(1988, 4, 2), EmployeeTypeId = 1, Gender = "Female", Salary = 76000m },
                new Employee { Id = 15, FullName = "Teboho Mokgosi", Email = "mokgositeboho77@gmail.com", DepartmentId = 1, DesignationId = 1, HireDate = new DateTime(2021, 7, 21), DateOfBirth = new DateTime(1998, 8, 19), EmployeeTypeId = 1, Gender = "Male", Salary = 72000m }
            );
        }
    }
}
