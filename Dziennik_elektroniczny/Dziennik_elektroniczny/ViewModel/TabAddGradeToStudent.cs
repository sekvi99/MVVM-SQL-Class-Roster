using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik_elektroniczny.ViewModel
{
    using Model;
    using DAL.Entity;
    using BaseClass;
    using System.Windows.Input;
    class TabAddGradeToStudent:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<Students> students;
        private ObservableCollection<Subjects> subjects;

        private int grade_value = 1;
        private int selectedStudentIndex = -1;
        private int selectedSubjectIndex = -1;
        #endregion

        #region Constructors
        public TabAddGradeToStudent(Model model)
        {
            this.model = model;
            students = model.Students;
            subjects = model.Subjects;
        }

        #endregion

        #region Properites
        public int SelectedStudentIndex
        {
            get => selectedStudentIndex;
            set
            {
                selectedStudentIndex = value;
                onPropertyChanged(nameof(SelectedStudentIndex));
            }
        }



        public int SelectedSubjectIndex
        {
            get => selectedSubjectIndex;
            set
            {
                selectedSubjectIndex = value;
                onPropertyChanged(nameof(SelectedSubjectIndex));
            }
        }

        public int Grade_Value
        {
            get => grade_value;
            set
            {
                grade_value = value;
                onPropertyChanged(nameof(Grade_Value));
            }
        }

        public Students CurrentStudent { get; set; }

        public Subjects CurrentSubject { get; set; }

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<Subjects> Subjects
        {
            get { return subjects; }
            set
            {
                subjects = value;
                onPropertyChanged(nameof(Subjects));
            }
        }
        #endregion

        #region Instructions
        private ICommand loadAllStudents = null;
        public ICommand LoadAllStudents
        {
            get
            {
                if (loadAllStudents == null)
                    loadAllStudents = new RelayCommand(
                        arg =>
                        {
                            Students = model.Students;
                            SelectedStudentIndex = -1;
                        },
                        arg => true
                        );
                return loadAllStudents;
            }
        }

        private ICommand loadAllSubjects = null;
        public ICommand LoadAllSubjects
        {
            get
            {
                if (loadAllSubjects == null)
                    loadAllSubjects = new RelayCommand(
                        arg =>
                        {
                            Subjects = model.Subjects;
                            SelectedSubjectIndex = -1;
                        },
                        arg => true
                        );
                return loadAllSubjects;
            }
        }

        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                    add = new RelayCommand(
                        arg =>
                        {
                            var grade = new Grades((sbyte)CurrentStudent.Student_id, (sbyte)CurrentSubject.Subject_id, grade_value);
                            if(model.AddGradeToDataBase(grade))
                            {
                                System.Windows.MessageBox.Show("Grade added to DB!");
                            }
                        },
                        arg => true
                        );
                return add;
            }
        }
        #endregion
    }
}
