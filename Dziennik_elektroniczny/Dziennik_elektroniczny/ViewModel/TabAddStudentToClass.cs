using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Dziennik_elektroniczny.ViewModel
{
    using Model;
    using DAL.Entity;
    using BaseClass;
    using System.Windows.Input;
    class TabAddStudentToClass:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<Class> classes = null;
        private ObservableCollection<Students> students = null;
        

        private int selectedStudentIndex = -1;
        private int selectedClassIndex = -1;
        #endregion

        #region Constructors
        public TabAddStudentToClass(Model model)
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

        #region Instructions

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
                        );
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
                        );
                return loadAllStudents;
            }
        }

        private ICommand add = null;
        public ICommand Add
        {
            get
            {
                if (add == null)
                    add = new RelayCommand(
                        arg =>
                        {
                            if(model.AddStudentToClass(CurrentStudent, CurrentClass))
                            {
                                System.Windows.MessageBox.Show("Student Added To Class!");
                                Students = model.Students;
                                

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
