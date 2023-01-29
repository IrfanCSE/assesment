using System;
using System.Collections.Generic;

namespace primetechmvc.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentsSubjects = new HashSet<StudentsSubject>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Roll { get; set; } = null!;
        public bool? IsActive { get; set; }

        public virtual ICollection<StudentsSubject> StudentsSubjects { get; set; }
    }
}
