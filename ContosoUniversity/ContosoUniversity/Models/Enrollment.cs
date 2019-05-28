using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        //The EnrollmentID property will be the primary key; 
        //this entity uses the classname ID pattern instead of ID by itself as you saw in the Student entity.
        public int EnrollmentID { get; set; }
        //CourseID = Foreign key
        public int CourseID { get; set; }
        //StudentID = Foreign key
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        //Grade = enum
        //The question mark after the Grade type declaration indicates that the Grade property is nullable. 
        //A grade that's null is different from a zero grade — null means a grade isn't known or hasn't been assigned yet.
        public Grade? Grade { get; set; }
        //Course = navigation property corresponding to CourseID foreign key
        public virtual Course Course { get; set; }
        //Student = navigation property corresponding to studentID foreign key
        public virtual Student Student { get; set; }
    }
}