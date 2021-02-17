using Microsoft.AspNetCore.Mvc;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _Db;
        public StudentController(StudentContext Db)
        {
            _Db = Db;
        }
        public IActionResult StudentList()
        {

            try {

                var stdList = _Db.tbl_student1.ToList();


                return View(stdList);
            }
            catch(Exception ex) 
            {
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Create_Test(Student obj)
        {
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try {
                if(ModelState.IsValid)
                {
                    if(obj.id == 0)
                    {
                        _Db.tbl_student1.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    

                    return RedirectToAction("StudentList");
                }
                return View();
            }
            catch(Exception e)
            {
                return RedirectToAction("StudentList");
            }
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            try {

                var std = await _Db.tbl_student1.FindAsync(id);
                if(std!=null)
                {
                    _Db.tbl_student1.Remove(std);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("StudentList");
            }
            catch(Exception e)
            {
                return RedirectToAction("StudentList");
            }
        }
    }
}
