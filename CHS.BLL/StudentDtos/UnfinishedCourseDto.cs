namespace CHS.BLL.StudentDtos
{
    public class UnfinishedCourseDto
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public string preCourse { get; set; }
        public string preCourseTitle { get; set; }
        public int CreditHours { get; set; }
    }
}
