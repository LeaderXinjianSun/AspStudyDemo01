using System.ComponentModel.DataAnnotations;

namespace AspStudyDemo01.Models
{
    /// <summary>
    /// 学生模型信息
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        [Display(Name= "姓名")]
        [Required(ErrorMessage ="请输入名字")]
        public string Name { get; set; }
        [Display(Name = "班级名称")]
        [Required]
        public ClassNameEnum? ClassName { get; set; }
        [Display(Name = "邮箱")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$",
            ErrorMessage ="邮箱的格式不正确")]
        [Required(ErrorMessage ="请输入邮件")]
        public string Email { get; set; }
        public string PhotoPath { set; get; }
    }
}
