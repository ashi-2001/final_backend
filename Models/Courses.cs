using System.ComponentModel.DataAnnotations;

namespace Final_Assessment.Models
{
    public class Courses
    {

           [Key]
            public int CourseId { get; set; }
            public string CourseName { get; set; }

            public ICollection<CoursesEnrolled> CoursesEnrolled { get; set; }
        

    }
}
