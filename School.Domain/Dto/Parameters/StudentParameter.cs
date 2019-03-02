using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Dto.Parameters
{
    public class StudentParameter
    {
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string StudentPhone { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int ClassRoomId { get; set; }
        public string ClassName { get; set; }
    }
}
