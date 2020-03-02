using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspStudyDemo01.Models
{
    /// <summary>
    /// 学生模型信息
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassNameEnum ClassName { get; set; }
        public string Email { get; set; }
    }
}
