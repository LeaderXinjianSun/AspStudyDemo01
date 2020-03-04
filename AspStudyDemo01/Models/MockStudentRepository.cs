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
                new Student(){ Id = 1,Name = "张三",ClassName = ClassNameEnum.FirstGrade,Email = "Tony_zhang@52abp.com" },
                new Student(){ Id = 2,Name = "李四",ClassName = ClassNameEnum.SecondGrade,Email = "Lisi@52abp.com" },
                new Student(){ Id = 3,Name = "王二麻子",ClassName = ClassNameEnum.SecondGrade,Email = "Wanger@52abp.com" }
            };
        }

        public Student Add(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(a => a.Id == id);
        }
        public Student Delete(int id)
        {
            Student student = _students.FirstOrDefault(s=>s.Id == id);
            if (student !=null)
            {
                _students.Remove(student);
            }
            return student;
        }
        public Student Update(Student updateStudent)
        {
            Student student = _students.FirstOrDefault(s => s.Id == updateStudent.Id);
            if (student != null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.ClassName = updateStudent.ClassName;
            }
            return student;
        }
    }
}
