﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
  public class DatabaseExampleController : Controller
  {
    public ApplicationDbContext dbContext;

    public DatabaseExampleController(ApplicationDbContext context)
    {
      dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> DatabaseOperations()
    {
      // CREATE operation
      Company MyCompany = new Company();
      MyCompany.symbol = "MCOB";
      MyCompany.name = "ISM";
      MyCompany.date = "ISM";
      MyCompany.isEnabled = true;
      MyCompany.type = "ISM";
      MyCompany.iexId = "ISM";

      
     Student NewStudent = new Student();
            NewStudent.Name = "Travis Weadock";
            dbContext.Students.Add(NewStudent);
     Student NewStudent1 = new Student();
            NewStudent1.Name = "Bart Simpson";
            dbContext.Students.AddRange(NewStudent1);
     Student NewStudent2 = new Student();
            NewStudent2.Name = "Bruce Wayne";
            dbContext.Students.AddRange(NewStudent2);
     Student NewStudent3 = new Student();
            NewStudent3.Name = "Betty Boop";
            dbContext.Students.AddRange(NewStudent3);


            Course NewCourse = new Course();
            NewCourse.Name = "Biology";
            NewCourse.Professor = "Prof. Frink";
            dbContext.Courses.Add(NewCourse);

            Course NewCourse1 = new Course();
            NewCourse1.Name = "Management";
            NewCourse1.Professor = "Mr. Belding";
            dbContext.Courses.Add(NewCourse1);
            
            Course NewCourse2 = new Course();
            NewCourse2.Name = "Engineering 101";
            NewCourse2.Professor = "Prof. E. Coyote";
            dbContext.Courses.Add(NewCourse2);

            Course NewCourse3 = new Course();
            NewCourse3.Name = "Algebra";
            NewCourse3.Professor = "Dr. Einstein";
            dbContext.Courses.Add(NewCourse3);


            Enrolment NewEnrolment = new Enrolment();
            NewEnrolment.student = NewStudent;
            NewEnrolment.course = NewCourse;
            NewEnrolment.grade = "A";
            dbContext.Enrolments.Add(NewEnrolment);

            Enrolment NewEnrolment1 = new Enrolment();
            NewEnrolment1.student = NewStudent1;
            NewEnrolment1.course = NewCourse1;
            NewEnrolment1.grade = "A-";
            dbContext.Enrolments.Add(NewEnrolment1);

            Enrolment NewEnrolment2 = new Enrolment();
            NewEnrolment2.student = NewStudent2;
            NewEnrolment2.course = NewCourse2;
            NewEnrolment2.grade = "C";
            dbContext.Enrolments.Add(NewEnrolment2);

            Enrolment NewEnrolment3 = new Enrolment();
            NewEnrolment3.student = NewStudent3;
            NewEnrolment3.course = NewCourse3;
            NewEnrolment3.grade = "B";
            dbContext.Enrolments.Add(NewEnrolment3);




            Quote MyCompanyQuote1 = new Quote();
      //MyCompanyQuote1.EquityId = 123;
      MyCompanyQuote1.date = "11-23-2018";
      MyCompanyQuote1.open = 46.13F;
      MyCompanyQuote1.high = 47.18F;
      MyCompanyQuote1.low = 44.67F;
      MyCompanyQuote1.close = 47.01F;
      MyCompanyQuote1.volume = 37654000;
      MyCompanyQuote1.unadjustedVolume = 37654000;
      MyCompanyQuote1.change = 1.43F;
      MyCompanyQuote1.changePercent = 0.03F;
      MyCompanyQuote1.vwap = 9.76F;
      MyCompanyQuote1.label = "Nov 23";
      MyCompanyQuote1.changeOverTime = 0.56F;
      MyCompanyQuote1.symbol = "MCOB";

      Quote MyCompanyQuote2 = new Quote();
      //MyCompanyQuote1.EquityId = 123;
      MyCompanyQuote2.date = "11-23-2018";
      MyCompanyQuote2.open = 46.13F;
      MyCompanyQuote2.high = 47.18F;
      MyCompanyQuote2.low = 44.67F;
      MyCompanyQuote2.close = 47.01F;
      MyCompanyQuote2.volume = 37654000;
      MyCompanyQuote2.unadjustedVolume = 37654000;
      MyCompanyQuote2.change = 1.43F;
      MyCompanyQuote2.changePercent = 0.03F;
      MyCompanyQuote2.vwap = 9.76F;
      MyCompanyQuote2.label = "Nov 23";
      MyCompanyQuote2.changeOverTime = 0.56F;
      MyCompanyQuote2.symbol = "MCOB";

      dbContext.Companies.AddRange(MyCompany);
      dbContext.Quotes.AddRange(MyCompanyQuote1);
      dbContext.Quotes.AddRange(MyCompanyQuote2);
      dbContext.Courses.AddRange(NewCourse);
      dbContext.Students.AddRange(NewStudent);
      

            dbContext.SaveChanges();
      
      // READ operation
      Company CompanyRead1 = dbContext.Companies
                              .Where(c => c.symbol == "MCOB")
                              .First();

      Company CompanyRead2 = dbContext.Companies
                              .Include(c => c.Quotes)
                              .Where(c => c.symbol == "MCOB")
                              .First();

      // UPDATE operation
      CompanyRead1.iexId = "MCOB";
      dbContext.Companies.Update(CompanyRead1);
      //dbContext.SaveChanges();
      await dbContext.SaveChangesAsync();
      
      // DELETE operation
      //dbContext.Companies.Remove(CompanyRead1);
      //await dbContext.SaveChangesAsync();

      return View();
    }

    public ViewResult LINQOperations()
    {
      Student CompanyRead1 = dbContext.Students
                                      .Where(c => c.Name == "Betty Boop")
                                      .First();

      Course CompanyRead2 = dbContext.Courses                                      
                                      .Where(c => c.Name == "Algebra")
                                      .First();

      Course Quote1 = dbContext.Courses
                                    .Include(c => c.Professor)
                                    .Where(c => c.Name == "Engineering 101")
                                    .FirstOrDefault();
                             

      return View();
    }

  }
}