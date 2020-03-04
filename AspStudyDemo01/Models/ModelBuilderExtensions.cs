using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspStudyDemo01.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                    new Student
                    {
                        Id = 1,
                        Name = "孙猴子",
                        ClassName = ClassNameEnum.FirstGrade,
                        Email = "sunhouzi@qq.com"
                    },
                    new Student
                    {
                        Id = 2,
                        Name = "猪八戒",
                        ClassName = ClassNameEnum.GradeThree,
                        Email = "zhubajie@qq.com"
                    }
                );
        }
    }
}
