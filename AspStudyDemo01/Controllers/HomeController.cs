﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspStudyDemo01.Models;
using AspStudyDemo01.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AspStudyDemo01.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //return Json(new { id="1", name="张三"});
            //这里没有使用ViewModel
            //IEnumerable<Student> students =  _studentRepository.GetAllStudents();
            //return View(students);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Students = _studentRepository.GetAllStudents(),
                PageTitle = "学生详细信息列表"
            };

            return View(homeDetailsViewModel);
        }
        public IActionResult Details(int? id)
        {
            //return Json(new { id="1", name="张三"});
            //Student model = _studentRepository.GetStudent(1);
            //return Json(model);
            //ViewData["PageTitle"] = "学生的详情";
            //ViewData["Student"] = model;

            //实例化HomeDetailsViewModel并存储Student详细信息和PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(id ?? 1),
                PageTitle = "学生详细信息"
            };

            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder,uniqueFileName);
                    var filestream = new FileStream(filePath, FileMode.Create);
                    filestream.Position = 0;
                    model.Photo.CopyTo(filestream);

                    Student newStudent = new Student { 
                        Name = model.Name,
                        Email = model.Email,
                        ClassName = model.ClassName,
                        PhotoPath = uniqueFileName
                    };
                    _studentRepository.Add(newStudent);
                    return RedirectToAction("Details", new { id = newStudent.Id });
                }
                //Student newStudent = _studentRepository.Add(student);
                
            }

            return View();



        }
    }
}