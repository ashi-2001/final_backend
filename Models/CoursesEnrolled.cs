using System.ComponentModel.DataAnnotations;

namespace Final_Assessment.Models
{
    public class CoursesEnrolled {

           [Key]
            public int CourseEnrolledId { get; set; }
            public int CourseId { get; set; }
            public int CollegeId { get; set; }

            public Courses Course { get; set; }
            public Colleges College { get; set; }
        

    }
}
