using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dziennik_elektroniczny.ViewModel
{
    using BaseClass;
    using Model;
    using System.Collections.ObjectModel;
    using DAL.Entity;
    class TabStudentAverage:ViewModelBase
    {
        #region Private FIelds
        private readonly Model model = null;
        private ObservableCollection<Students> students = null;
        private int selectedStudentIndex = -1;
        #endregion

        #region Constructors
        public TabStudentAverage(Model model)
        {
            this.model = model;
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
        public Students CurrentStudent { get; set; }
        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }
        #endregion

        #region Methods
        public void RefreshStudents()
        {
            SelectedStudentIndex = -1;
            Students = model.Students;
        }
        #endregion

        #region Instructions
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

        private ICommand refresh = null;
        public ICommand Refresh
        {
            get
            {
                if (refresh == null)
                    refresh = new RelayCommand(
                        arg =>
                        {
                            
                            RefreshStudents();
                        },
                        arg => true
                        );
                return refresh;
            }
        }

        private ICommand average = null;
        public ICommand Average
        {
            get
            {
                if (average == null)
                    average = new RelayCommand(
                        arg =>
                        {
                            double average = model.GetAverageForStudent(CurrentStudent);
                            System.Windows.MessageBox.Show("Średnia dla ucznia" + CurrentStudent.Student_name + " " + CurrentStudent.Student_secondName + " = " + average);
                        },
                        arg => true
                        );
                return average;
            }
        }
        #endregion
    }
}
