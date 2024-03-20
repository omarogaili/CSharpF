using System.Linq;

namespace LinqAndExtensions
{
    internal class Program
    {
        private static readonly Roster roster = new();

        static void Main(string[] args)
        {
            //Implementera övriga funktioner så att Main-funktionen kan köras.
            //Ändra INTE i Main-funktionen.

            Console.WriteLine($"Studenternas sammanlagda ålder: {StudentsTotalAge()}");
            Console.WriteLine($"Antal olika kurser: {NumberOfCourses()}");
            
            Console.WriteLine();
            Console.WriteLine("------");
            Console.WriteLine("Närvarolista:");
            foreach (var student in roster.Students)
            {
                Console.Write(CreateEnrollmentID(student));
                Console.Write(" - ");
                Console.Write(CreateStudentSummary(student));
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("------");
            Console.WriteLine("Kurslista:");
            foreach (string course in GetCourseList(roster.Students))
            {
                Console.WriteLine(course);
            }
            Console.WriteLine();
            Console.WriteLine("------");
            Console.WriteLine("Stipendatlista:");
            foreach (var student in GetTopStudents(roster.Students))
            {
                Console.WriteLine(CreateStudentSummary(student));
            }
        }

        private static int StudentsTotalAge()
        {
            //Räkna samman studenternas ålder.
           int totalAge= roster.Students.Select(student => student.StudentAge).Sum();
            return totalAge;
            //throw new NotImplementedException();

        }

        private static int NumberOfCourses()
        {
            //Räkna ut hur många enskilda kurser som finns.
            //Gruppera på kurs som tillvägagångssätt.
            //throw new NotImplementedException();
            int totalCourses = roster.Students.Select(student => student.CourseID).Distinct().Count();
            return totalCourses;
            //use the grupp by its for the best . 
            //u can use .Count for grupp .
        }

        private static string CreateEnrollmentID(Student student)
        {
            //Gör en extension (kalla den EnrollmentID) på Student som kombinerar
            //studentens ID med kursens ID.
            //Exempel: "S1004C201"
            //throw new NotImplementedException();
            //string enrollmentId = roster.Students.Select(student => student.StudentID);
            //return enrollmentId;
            return student.EnrollmentId();
        }

        private static string CreateStudentSummary(Student student)
        {
            //Gör en extension (kalla den Summary) på Student som skriver ut
            //studentents namn, ålder, och epostadress.
            return student.StudentSummary();
        }

        private static IEnumerable<string> GetCourseList(List<Student> students)
        {
            //Gör en lista på alla kurser.
            //Varje kurs ska representeras av en sammanfattning.
            //Exempel på sådan sammanfattning: "C201 - Implement Extensible Networks"
            //Listan ska vara sorterad efter ID.
            //throw new NotImplementedException();
            var course = roster.Students.OrderBy(s => Convert.ToInt32(s.CourseID.Substring(1)))
                .Select(student => $"{student.CourseID} - {student.CourseName}")
                .Distinct();
            return course;
        }

        private static IEnumerable<Student> GetTopStudents(List<Student> students)
        {
            //Plocka ut alla studenter med 90 poäng eller mer.
            //Sortera dom efter ID.
            //throw new NotImplementedException();
            //var topStudents= students.Where(students=> students.StudentPoints >=90 )
            //    .OrderBy(students => students.StudentID);
            //return topStudents;
         return  roster.Students.GroupBy(s => s.StudentID)
                .OrderBy(g => Convert.ToInt32(g.First().StudentID.Substring(1)))
                .Select(g => new { Value = g.First(), Points = g.Select(s => s.StudentPoints).Sum() })
                .Where(s => s.Points >= 90)
                .Select(s => s.Value);


        }
    }
}
