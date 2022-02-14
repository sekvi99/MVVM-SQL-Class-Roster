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

    class TabStudentAbsences:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<Absence> absences = null;
        private ObservableCollection<Students> students = null;

        private int selectedStudentIndex = -1;
        private int selectedAbsenceIndex = -1;
        #endregion

        #region Constructors
        public TabStudentAbsences(Model model)
        {
            this.model = model;
            absences = model.Absences;
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

        public int SelectedAbsenceIndex
        {
            get => selectedAbsenceIndex;
            set
            {
                selectedAbsenceIndex = value;
                onPropertyChanged(nameof(SelectedAbsenceIndex));
            }
        }

        public Students CurrentStudent { get; set; }
        public Absence CurrentAbsence { get; set; }

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<Absence> Absences
        {
            get { return absences; }
            set
            {
                absences = value;
                onPropertyChanged(nameof(Absences));
            }
        }
        #endregion

        #region Methods
        public void RefreshStudents()
        {
            Students = model.Students;
            SelectedStudentIndex = -1;
        }
        public void RefreshAbsences()
        {
            Absences = model.Absences;
            SelectedAbsenceIndex = -1;
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
                            if (CurrentAbsence != null)
                                Students = model.GetStudentFromAbsences(CurrentAbsence);
                        },
                        arg => true
                        );
                return loadStudents;
            }
        }

        private ICommand loadAbsence;
        public ICommand LoadAbsence
        {
            get
            {
                if (loadAbsence == null)
                    loadAbsence = new RelayCommand(
                        arg =>
                        {
                            if (CurrentStudent != null)
                                Absences = model.GetAbsenceFromStudent(CurrentStudent);
                        },
                        arg => true
                        );
                return loadAbsence;
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

        private ICommand loadAllAbsences = null;
        public ICommand LoadAllAbsences
        {
            get
            {
                if (loadAllAbsences == null)
                    loadAllAbsences = new RelayCommand(
                        arg =>
                        {
                            Absences = model.Absences;
                            SelectedAbsenceIndex = -1;
                        },
                        arg => true
                        );
                return loadAllAbsences;
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
                            RefreshAbsences();
                            RefreshStudents();
                        },
                        arg => true
                        );
                return refresh;
            }
        }
        #endregion
    }
}
