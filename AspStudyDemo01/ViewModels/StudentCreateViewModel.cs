using AspStudyDemo01.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspStudyDemo01.ViewModels
{
    public class StudentCreateViewModel
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请输入名字")]
        public string Name { get; set; }
        [Display(Name = "班级名称")]
        [Required]
        public ClassNameEnum? ClassName { get; set; }
        [Display(Name = "邮箱")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$",
            ErrorMessage = "邮箱的格式不正确")]
        [Required(ErrorMessage = "请输入邮件")]
        public string Email { get; set; }
        [Display(Name="图片")]
        public IFormFile Photo { set; get; }
    }
}
