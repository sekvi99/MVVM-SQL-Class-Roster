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
    class TabStudentGradesWithSubjectNames:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<GradesWithSubjects> gradesWithNames = null;
        private ObservableCollection<Students> students = null;

        private int selectedStudentIndex = -1;
        private int selectedGradeSubjectIndex = -1;
        #endregion


        #region Constructors
        public TabStudentGradesWithSubjectNames(Model model)
        {
            this.model = model;
            gradesWithNames = model.GradeWithSubjectNames;
            students = model.Students;
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

        public int SelectedGradeWithSubjectNameIndex
        {
            get => selectedGradeSubjectIndex;
            set
            {
                selectedGradeSubjectIndex = value;
                onPropertyChanged(nameof(SelectedGradeWithSubjectNameIndex));
            }
        }

        public Students CurrentStudent { get; set; }
        public GradesWithSubjects CurrentGradeSubject { get; set; }

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<GradesWithSubjects> GradesWithSubjectNames
        {
            get { return gradesWithNames; }
            set
            {
                gradesWithNames = value;
                onPropertyChanged(nameof(GradesWithSubjectNames));
            }
        }

        #endregion

        #region Methods
        public void RefreshStudent()
        {
            Students = model.Students;
            SelectedStudentIndex = -1;
        }
        public void RefreshGradesWithNames()
        {
            GradesWithSubjectNames = model.GradeWithSubjectNames;
            SelectedGradeWithSubjectNameIndex = -1;
        }
        #endregion

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
                            if (CurrentGradeSubject != null)
                                Students = model.GetStudentFromGrade(CurrentGradeSubject);
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
                                GradesWithSubjectNames = model.GetGradesFromStudent(CurrentStudent);
                        },
                        arg => true
                        );
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
                            GradesWithSubjectNames = model.GradeWithSubjectNames;
                            SelectedGradeWithSubjectNameIndex = -1;
                        },
                        arg => true
                        );
                return loadAllGrades;
            }
        }

        private ICommand refresh = null;
        public ICommand Refresh
        {
            get
            {
                if (refresh == null)
                    refresh = new RelayCommand(
                        arg =>
                        {
                            RefreshGradesWithNames();
                            RefreshStudent();
                        },
                        arg => true
                        );
                return refresh;
            }
        }
        #endregion
    }
}
