using System;
using System.Collections.Generic;

namespace primetechmvc.Models
{
    public partial class StudentsSubject
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        public decimal Credit { get; set; }
        public bool? IsActive { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
