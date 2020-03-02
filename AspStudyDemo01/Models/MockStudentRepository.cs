using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspStudyDemo01.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        List<Student> _students;
        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                new Student(){ Id = 1,Name = "张三",ClassName = "一年级",Email = "Tony_zhang@52abp.com" },
                new Student(){ Id = 2,Name = "李四",ClassName = "二年级",Email = "Lisi@52abp.com" },
                new Student(){ Id = 3,Name = "王二麻子",ClassName = "二年级",Email = "Wanger@52abp.com" }
            };
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(a => a.Id == id);
        }
    }
}
