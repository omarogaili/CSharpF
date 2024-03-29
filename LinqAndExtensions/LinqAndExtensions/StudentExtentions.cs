﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndExtensions
{
    // Extensions är en static klass som vi använder föra att skapa metoder med Linq för att retunerar 
    //en
    internal static class StudentExtentions
    {
        public static string  EnrollmentId(this Student student)
        {
            return $"{student.StudentID}{student.CourseID}";
        }
        public static string StudentSummary(this Student student)
        {
            return $"{student.StudentName} ålder:{student.StudentAge} post: {student.StudentEmail}";
        }
        

    }
}
