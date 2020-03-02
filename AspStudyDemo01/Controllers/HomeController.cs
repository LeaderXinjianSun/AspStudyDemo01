using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspStudyDemo01.Models;
using AspStudyDemo01.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspStudyDemo01.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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
    }
}