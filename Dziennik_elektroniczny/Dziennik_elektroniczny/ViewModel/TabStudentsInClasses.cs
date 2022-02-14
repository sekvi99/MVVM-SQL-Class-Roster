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

    class TabStudentsInClasses:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<Class> classes = null;
        private ObservableCollection<Students> students = null;
       

        private int selectedStudentIndex = -1;
        private int selectedClassIndex = -1;
        #endregion

        #region Constructors
        public TabStudentsInClasses(Model model)
        {
            this.model = model;
            classes = model.Classes;
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

        public int SelectedClassIndex
        {
            get => selectedClassIndex;
            set
            {
                selectedClassIndex = value;
                onPropertyChanged(nameof(SelectedClassIndex));
            }
        }

        public Students CurrentStudent { get; set; }

        public Class CurrentClass { get; set; }

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<Class> Classes
        {
            get { return classes; }
            set
            {
                classes = value;
                onPropertyChanged(nameof(Classes));
            }
        }

        #endregion

        #region Methods
        public void RefreshClasses()
        {
            Classes = model.Classes;
            SelectedClassIndex = -1;
        }
        public void RefreshStudents()
        {
            Students = model.Students;
            SelectedStudentIndex = -1;
        }

        #endregion

        #region Instructions
        //loads all classess witch contains choosen student
        private ICommand loadClasses = null;
        public ICommand LoadClasses
        {
            get
            {
                if (loadClasses == null)
                    loadClasses = new RelayCommand(
                        arg =>
                        {
                            if (CurrentStudent != null)
                                Classes = model.GetStudentClass(CurrentStudent);
                        },
                        arg => true
                        ) ;
                return loadClasses;
            }
        }

        //loads all students in choosen class
        private ICommand loadStudents = null;
        public ICommand LoadStudents
        {
            get
            {
                if (loadStudents == null)
                    loadStudents = new RelayCommand(
                        arg =>
                        {
                            if (CurrentClass != null)
                                Students = model.GetAllStudentsInClass(CurrentClass);
                        },
                        arg => true
                        ) ;
                return loadStudents;
            }
        }

        private ICommand loadAllClasses = null;
        public ICommand LoadAllClasses
        {
            get
            {
                if (loadAllClasses == null)
                    loadAllClasses = new RelayCommand(
                        arg =>
                        {
                            Classes = model.Classes;
                            SelectedClassIndex = -1;
                        },
                        arg => true
                        ) ;
                return loadAllClasses;
            }
        }

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
                        ) ;
                return loadAllStudents;
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
                            RefreshClasses();
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
