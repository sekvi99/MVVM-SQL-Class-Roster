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
    class TabStudentsGrade:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<Grades> grades = null;
        private ObservableCollection<Students> students = null;
        private ObservableCollection<Subjects> subjects = null;

        private int selectedStudentIndex = -1;
        private int selectedGradeIndex = -1;
        #endregion

        #region Constructors
        public TabStudentsGrade(Model model)
        {
            this.model = model;
            grades = model.Grades;
            students = model.Students;
            subjects = model.Subjects;
        }
        #endregion

        #region Properties

        public int SelectedStudentIndex
        {
            get => selectedStudentIndex;
            set
            {
                selectedStudentIndex = value;
                onPropertyChanged(nameof(SelectedStudentIndex));
            }
        }

        public int SelectedGradeIndex
        {
            get => selectedGradeIndex;
            set
            {
                selectedGradeIndex = value;
                onPropertyChanged(nameof(SelectedGradeIndex));
            }
        }

        public Students CurrentStudent { get; set; }
        public Grades CurrentGrade { get; set; }

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<Grades> Grades
        {
            get { return grades; }
            set
            {
                grades = value;
                onPropertyChanged(nameof(Grades));

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

        #region Methods
        public void RefreshStudents() => Students = model.Students;
        #endregion

        /*
        #region Instructions
        private ICommand loadStudents = null;
        public ICommand LoadStudent
        {
            get
            {
                if (loadStudents == null)
                    loadStudents = new RelayCommand(
                        arg =>
                        {
                            if (CurrentGrade != null)
                                Students = model.GetStudentFromGrade(CurrentGrade);
                        },
                        arg => true
                        );
                return loadStudents;
            }
        }

        private ICommand loadAllStudents;
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

        private ICommand loadGrades = null;
        public ICommand LoadGrades
        {
            get
            {
                if (loadGrades == null)
                    loadGrades = new RelayCommand(
                        arg =>
                        {
                            if (CurrentStudent != null)
                                Grades = model.GetGradesFromStudent(CurrentStudent);
                        },
                        arg => true
                        ) ;
                return loadGrades;
            }
            
        }

        private ICommand loadAllGrades = null;
        public ICommand LoadAllGrades
        {
            get
            {
                if (loadAllGrades == null)
                    loadAllGrades = new RelayCommand(
                        arg =>
                        {
                            Grades = model.Grades;
                            SelectedGradeIndex = -1;
                        },
                        arg => true
                        );
                return loadAllGrades;
            }
        }

        #endregion
        */
    }
}
