using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Student;
using UniversityCompetition.Models.Subject;
using UniversityCompetition.Models.University;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private string[] subjectTypes = new string[3] { "EconomicalSubject", "HumanitySubject", "TechnicalSubject" };
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;
        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (students.FindByName(firstName+" "+lastName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName,lastName);
            }
            IStudent student=new Student(students.Models.Count+1,firstName, lastName);
            students.AddModel(student);
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, "StudentRepository");

        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject;
            if (!subjectTypes.Contains(subjectType))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjects.FindByName(subjectName)!=null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            if (subjectType== "EconomicalSubject")
            {
                subject = new EconomicalSubject(subjects.Models.Count + 1,subjectName);
            }
            else if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
            }
            else
            {
                subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
            }
            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType,subjectName, "SubjectRepository");

        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int>ids=requiredSubjects.Select(x=>subjects.FindByName(x).Id).ToList();    
            IUniversity university=new University(universities.Models.Count+1,universityName,category,capacity, ids);
            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, "UniversityRepository");

        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(' ')[0];
            string lastName = studentName.Split(' ')[1];
            if (students.FindByName(firstName + " " + lastName) == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            if (universities.FindByName(universityName) == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            IStudent student = students.FindByName(firstName + " " + lastName);
            IUniversity university = universities.FindByName(universityName);
            bool covered = true;
            foreach (var item in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(item))
                {
                    covered= false;
                }
            }
            if (!covered)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            if (student.University==university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }
            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);

        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) ==null)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
            if (subjects.FindById(subjectId) == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);
            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName,student.LastName, subject.Name);
            }
            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);

        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            StringBuilder sb =new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {students.Models.Where(x=>x.University==university).Count()}");
            sb.AppendLine($"University vacancy: {university.Capacity-students.Models.Where(x => x.University == university).Count()}");
            return sb.ToString().TrimEnd();

        }
    }
}
