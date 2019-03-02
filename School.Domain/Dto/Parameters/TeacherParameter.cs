using System;
using System.Collections.Generic;
using System.Text;

namespace School.Domain.Dto.Parameters
{
    public class TeacherParameter
    {
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public DateTime TeacherDateTime { get; set; }
        public string TeacherPhone { get; set; }
        public int GenderId { get; set; }
        public  string GenderName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
