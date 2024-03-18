using Newtonsoft.Json;

namespace LinqAndExtensions
{
    internal class Student
    {
        [JsonProperty("Student ID")]
        public required string StudentID { get; set; }

        [JsonProperty("Student Name")]
        public required string StudentName { get; set; }

        [JsonProperty("Student Age")]
        public required int StudentAge { get; set; }

        [JsonProperty("Student Address")]
        public required string StudentAddress { get; set; }

        [JsonProperty("Student Email")]
        public required string StudentEmail { get; set; }

        [JsonProperty("Student Points")]
        public required int StudentPoints { get; set; }

        [JsonProperty("Course ID")]
        public required string CourseID { get; set; }

        [JsonProperty("Course Name")]
        public required string CourseName { get; set; }
    }
}
