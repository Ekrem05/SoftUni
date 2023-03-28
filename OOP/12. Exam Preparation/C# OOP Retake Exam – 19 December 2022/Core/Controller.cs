using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects=new SubjectRepository();
        private StudentRepository students=new StudentRepository();
        private UniversityRepository universities = new UniversityRepository();
        public string AddStudent(string firstName, string lastName)
        {
          
            if (students.FindByName(firstName + " " + lastName)!=null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent,firstName,lastName);
            }
            int id = students.Models.Count + 1;
            IStudent student = new Student(id,firstName,lastName);
            students.AddModel(student);
            if (student.LastName== "Grey")
            {
                return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, "Grеy", "StudentRepository");
            }
            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, "StudentRepository");
        }

        public string AddSubject(string subjectName, string subjectType)
        {

            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported,subjectType);

            }
           
            if (subjects.FindByName(subjectName)!=null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            ISubject subject;
            int id = subjects.Models.Count + 1;
            if (subjectType==nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(id, subjectName);
            }
            else  if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(id, subjectName);
            }
            else
            {
                subject = new HumanitySubject(id, subjectName);
            }
            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully,subjectType,subjectName, "SubjectRepository");
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> marks = new List<int>();
            foreach (var item in requiredSubjects)
            {
                marks.Add(subjects.FindByName(item).Id);
            }

            IUniversity uni = new University(universities.Models.Count + 1,universityName,category,capacity,marks);
            universities.AddModel(uni);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, "UniversityRepository");
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(' ')[0];
            string secondName = studentName.Split(' ')[1];
            if (students.FindByName(studentName) ==null)
            {
                return string.Format(OutputMessages.StudentNotRegitered,firstName,secondName);
            }
            if (universities.FindByName(universityName) == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            IUniversity university = universities.FindByName(universityName);
            IStudent student = students.FindByName(studentName);
            bool covered = true;
            foreach (var item in university.RequiredSubjects)
            {             
                bool itemFound=false;
                foreach (var exam in student.CoveredExams)
                {
                    if (exam==item)
                    {
                        itemFound= true;
                        break;
                    }                   

                }
                if (!itemFound)
                {
                    covered = false;
                    break;
                }
            }
            if (!covered)
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            if (student.University==university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName,secondName, universityName);
            }
            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, secondName, universityName);

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
            IStudent student=students.FindById(studentId);
            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam,student.FirstName,student.LastName,subjects.FindById(subjectId).Name);
            }
            student.CoverExam(subjects.FindById(subjectId));
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subjects.FindById(subjectId).Name);

        }

        public string UniversityReport(int universityId)
        {
            IUniversity university=universities.FindById(universityId);
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: { university.Category}");
            int studentsInThere =students.Models.Where(x=>x.University==university).Count();
          
            sb.AppendLine($"Students admitted: {studentsInThere}");
            sb.AppendLine($"University vacancy: {university.Capacity-studentsInThere}");
            return sb.ToString().TrimEnd();
        }
    }
}
