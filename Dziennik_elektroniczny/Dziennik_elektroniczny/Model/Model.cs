using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Dziennik_elektroniczny.Model
{
    using DAL.Entity;
    using DAL.Repository;
    using System.Collections.ObjectModel;
    class Model
    {
        #region Databse State
        //Database state
        public ObservableCollection<Students> Students { get; set; } = new ObservableCollection<Students>();
        public ObservableCollection<Subjects> Subjects { get; set; } = new ObservableCollection<Subjects>();
        public ObservableCollection<Student_Groups> Student_groups { get; set; } = new ObservableCollection<Student_Groups>();
        public ObservableCollection<Grades> Grades { get; set; } = new ObservableCollection<Grades>();
        public ObservableCollection<Comments> Comments { get; set; } = new ObservableCollection<Comments>();
        public ObservableCollection<Class> Classes { get; set; } = new ObservableCollection<Class>();
        public ObservableCollection<Absence> Absences { get; set; } = new ObservableCollection<Absence>();
        public ObservableCollection<GradesWithSubjects> GradeWithSubjectNames { get; set; } = new ObservableCollection<GradesWithSubjects>();
        #endregion

        #region Constructor
        public Model()
        {
            try
            {
                //Students
                var students = StudentsRepository.GetAllStudents();
                foreach (var student in students)
                {
                    Students.Add(student);
                }

                //Subjects
                var subjects = SubjectsRepository.GetAllSubjects();
                foreach (var subject in subjects)
                {
                    Subjects.Add(subject);
                }

                //Student_Groups
                var student_groups = StudentGroupsRepository.GetAllStudentInGroups();
                foreach (var student_group in student_groups)
                {
                    Student_groups.Add(student_group);
                }

                

                //Classes
                var classes = ClassRepository.GetAllClasses();
                foreach (var cl in classes)
                {
                    Classes.Add(cl);

                }

                //Absemces
                var absences = AbsenceRepository.GetAllAbsences();
                foreach (var absence in absences)
                {
                    Absences.Add(absence);
                }

                //Grades
                var grades = GradesRepository.GetAllGrades();
                foreach (var grade in grades)
                {
                    Grades.Add(grade);
                }

                //Comments
                var comments = CommentsRepository.GetAllComments();
                foreach (var comment in comments)
                {
                    Comments.Add(comment);
                }

                var grades_subjects = GradesWithSubjectsRepository.GetAllGradesWithSubjectNames();
                foreach (var gs in grades_subjects)
                {
                    GradeWithSubjectNames.Add(gs);
                }

            }
            catch (Exception e)
            {
                //plik tekstowy do bledow
                Console.WriteLine(e.ToString());
                List<string> lines = new List<string>();
                lines.Add(e.ToString());
                string filePath = @"C:\Users\User\Desktop\Dziennik_elektroniczny\Dziennik_elektroniczny\log.txt";
                File.WriteAllLines(filePath, lines);
            }

        }
        #endregion

        #region Find Methods
        //Find Student - default from 1 to 80
        public Students FindStudentByID(sbyte id)
        {
            foreach (var student in Students)
            {
                if (student.Student_id == id) return student;
            }
            return null;
        }

        public GradesWithSubjects FindGradeByID(int id)
        {
            foreach (var grade in GradeWithSubjectNames)
            {
                if (grade.Grade_ID == id) return grade;
            }
            return null;
        }

        //Find class Pierwsza - 1, Druga - 2, Trzecia - 3 itd.
        public Class FindClassBydID(sbyte id)
        {
            foreach (var c in Classes)
            {
                if (c.Class_ID == id) return c;
            }
            return null;
        }

        public Comments FindCommentByID(sbyte id)
        {
            foreach (var comment in Comments)
            {
                if (comment.Comment_ID == id) return comment;
            }
            return null; 
        }

        public Absence FindAbsenceByID(sbyte id)
        {
            foreach (var absence in Absences)
            {
                if (absence.Absence_ID == id) return absence;
            }
            return null;
        }
        //Find Subject
        /// 1 - matematyka
        /// 2 - jezyk polski
        /// 3 - Jezyk Angielski
        /// 4 - Historia
        /// 5 - Biologia
        /// 6 - Fizyka
        /// 7 - Chemia
        /// 8 - Informatyka
        /// 9 - Plastyka
        /// 10 - Muzyka

        public Subjects FindSubjectByID(sbyte id)
        {
            foreach (var subject in Subjects)
            {
                if (subject.Subject_id == id) return subject;
            }
            return null;
        }

        #endregion

        #region Get Methods
        //Get student grades from every subject in database
        public ObservableCollection<Grades> GetAllStudentGrades(Students s)
        {
            var grades = new ObservableCollection<Grades>();
            foreach (var grade in Grades)
            {
                if (grade.Student_ID == s.Student_id) grades.Add(grade);
            }
            return grades;
        }


        //calculate whole average for student
        public double GetAverageForStudent(Students s)
        {
            double average = 0;
            int grades_amount = 0;
            var student_grades = GetAllStudentGrades(s);
            foreach (var grade in student_grades)
            {
                average += grade.Grade_Value;
                grades_amount++;
            }

            average /= grades_amount;
            return average;
        }

        //get all absences of student
        public ObservableCollection<Absence> GetAllAbsences(Students s)
        {
            var absences = new ObservableCollection<Absence>();
            foreach (var absence in Absences)
            {
                if (absence.Student_ID == s.Student_id) absences.Add(absence);
            }

            return absences;
        }

        //get all comment of student
        public ObservableCollection<Comments> GetAllComments(Students s)
        {
            var comments = new ObservableCollection<Comments>();
            foreach (var comment in Comments)
            {
                if (comment.Student_ID == s.Student_id) comments.Add(comment);
            }
            return comments;
        }

        //Get all students from exact group of students
        public ObservableCollection<Students> GetAllStudentsInStudentGroup(Student_Groups sg)
        {
            var students_in_group = new ObservableCollection<Students>();
            var students_indexes = new ObservableCollection<Student_Groups>();
            foreach (var studentgroup in Student_groups)
            {
                if (studentgroup.Class_id == sg.Class_id) students_indexes.Add(studentgroup);
            }

            foreach (var record in students_indexes)
            {
                students_in_group.Add(FindStudentByID(record.Student_id));
            }

            return students_in_group;
        }

        //get all grades of student of exact subject
        public ObservableCollection<Grades> GetAllGradesFromSubjectX(Students student, Subjects subject)
        {
            var grades = new ObservableCollection<Grades>();
            foreach (var grade in Grades)
            {
                if ((student.Student_id == grade.Student_ID) && (subject.Subject_id == grade.Subject_ID))
                    grades.Add(grade);
            }
            return grades;
        }

        //calculate average of subject x
        public double CalculateSubjectAverage(Students student, Subjects subject)
        {
            var grades = GetAllGradesFromSubjectX(student, subject);
            double average = 0;
            int grades_amount = 0;

            foreach (var grade in grades)
            {
                average += grade.Grade_Value;
                grades_amount++;
            }

            average = (average / grades_amount);
            return average;

        }

        //Get All students in Exact Class
        public ObservableCollection<Students> GetAllStudentsInClass(Class someClass)
        {
            var students = new ObservableCollection<Students>();
            foreach (var student in Student_groups)
            {
                if(student.Class_id == someClass.Class_ID)
                {
                    students.Add(FindStudentByID(student.Student_id));
                }
            }
            return students;
        }

        //Get Students Class
        public ObservableCollection<Class> GetStudentClass(Students student)
        {
            var classes = new ObservableCollection<Class>();
            foreach (var studentG in Student_groups)
            {
                if(studentG.Student_id  == student.Student_id)
                {
                    classes.Add(FindClassBydID(studentG.Class_id));
                }
            }
            return classes;
        }

        //Pobierz uwagi studenta
        public ObservableCollection<Comments> GetCommentsFromStudent(Students student)
        {
            var comments = new ObservableCollection<Comments>();
            foreach (var comment in Comments)
            {
                if(student.Student_id == comment.Student_ID)
                {
                    comments.Add(FindCommentByID((sbyte)comment.Comment_ID));
                }
            }
            return comments;
        }


        //Pobierz studenta, ktorego jest uwaga
        public ObservableCollection<Students> GetStudentFromComments(Comments comment)
        {
            var students = new ObservableCollection<Students>();
            foreach (var student in Students)
            {
                if(comment.Student_ID == student.Student_id)
                {
                    students.Add(FindStudentByID((sbyte)student.Student_id));
                }
            }
            return students;
        }

        //Pobierz studenta, ktorego jest nieobecnosc
        public ObservableCollection<Students> GetStudentFromAbsences(Absence absence)
        {
            var students = new ObservableCollection<Students>();
            foreach (var student in Students)
            {
                if(absence.Student_ID == student.Student_id)
                {
                    students.Add(FindStudentByID((sbyte)student.Student_id));
                }
            }
            return students;
        }
        //Pobierz Nieobecnosc od studenta
        public ObservableCollection<Absence> GetAbsenceFromStudent(Students student)
        {
            var absences = new ObservableCollection<Absence>();
            foreach (var absence in Absences)
            {
                if(student.Student_id == absence.Student_ID)
                {
                    absences.Add(FindAbsenceByID((sbyte)absence.Absence_ID));
                }
            }

            return absences;
        }

        //Pobierz studenta ktorego jest ocena
        public ObservableCollection<Students> GetStudentFromGrade(GradesWithSubjects grade)
        {
            var students = new ObservableCollection<Students>();
            foreach (var student in Students)
            {
                if (student.Student_id == grade.Student_ID)
                    students.Add(FindStudentByID((sbyte)student.Student_id));
            }
            return students;
        }


        //Pobierz ocene ktorej jest student
        public ObservableCollection<GradesWithSubjects> GetGradesFromStudent(Students student)
        {
            var grades = new ObservableCollection<GradesWithSubjects>();
            foreach (var grade in Grades)
            {
                if (student.Student_id == grade.Student_ID)
                    grades.Add(FindGradeByID((int)grade.Grade_ID));
            }
            return grades;
        }

        #endregion

        #region Contain Methods
        public bool IsStudentAlreadyInDB(Students s) => Students.Contains(s);
        public bool IsStudentAlreadyInClass(Students s)
        {
            foreach (var student in Student_groups)
            {
                if (s.Student_id == student.Student_id)
                    return true;
            }
            return false;
        }


        #endregion

        #region Add Methods
        public bool AddStudentToDataBase(Students student)
        {
            if (!IsStudentAlreadyInDB(student))
            {
                if (StudentsRepository.AddStudentToDataBase(student))
                {
                    Students.Add(student);
                    return true;

                }
            }
            return false;

        }

        public bool AddGradeToDataBase(Grades grade)
        {
            if(GradesRepository.AddGradeToBase(grade))
            {
                Grades.Add(grade);
                return true;
            }
            return false;
        }

        public bool AddStudentToClass(Students student, Class cl)
        {
            if(!IsStudentAlreadyInClass(student))
            {
                var sg = new Student_Groups((sbyte)student.Student_id, (sbyte)cl.Class_ID);
                if(StudentGroupsRepository.AddStudentToGroup(sg))
                {
                    return true;
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Student Already In Database!");
                return false;
            }

            return false;
        }

        #endregion

        #region Edit Methods
        public bool EditStudentInDataBase(Students choosenStudent, sbyte idOstudentIDsoby)
        {
            if (StudentsRepository.EditStudentInDatabase(choosenStudent, idOstudentIDsoby))
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].Student_id == idOstudentIDsoby)
                    {
                        choosenStudent.Student_id = idOstudentIDsoby;
                        Students[i] = new Students(choosenStudent);
                    }
                }
                return true;
            }
            return false;
        }

        #endregion


    }
}
