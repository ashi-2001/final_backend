using System.ComponentModel.DataAnnotations;

namespace Final_Assessment.Models
{
    public class Colleges
    {

             [Key]
            public int CollegeId { get; set; }
            public string RegistrationId { get; set; }
            public string CollegeName { get; set; }
            public string BranchName { get; set; }
            public DateTime RegistrationDate { get; set; }
            public string EmailId { get; set; }
            public string ContactNumber { get; set; }
            public string CurrentAddress { get; set; }
            public string DocumentType { get; set; }
            public string DocumentNumber { get; set; }
            public string Nationality { get; set; }

            public ICollection<CoursesEnrolled> CoursesEnrolled { get; set; }
        

    }
}
