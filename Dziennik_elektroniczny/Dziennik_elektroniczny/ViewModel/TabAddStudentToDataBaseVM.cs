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
    //using DAL.Repository;
    class TabAddStudentToDataBaseVM : ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private char sex = 'M';
        private string student_name, student_secondName, phone_number;
        private string birth_date = "2015-01-01";
        private string student_residence = "Katowice";
        private bool addingAvailable = true;
        private int checkedID = -1;
        private bool addingavailable = true;
        private  bool editingavailable = true;
        #endregion

        #region Constructors
        public TabAddStudentToDataBaseVM(Model model)
        {
            this.model = model;
            Students = model.Students;
        }
        #endregion

        #region Properties
        public Students Current_Student { get; set; }
        public ObservableCollection<Students> Students { get; set; }

        public string Name
        {
            get { return student_name; }
            set
            {
                student_name = value;
                onPropertyChanged(nameof(Name));
            }
        }

        public string SecondName
        {
            get { return student_secondName; }
            set
            {
                student_secondName = value;
                onPropertyChanged(nameof(SecondName));
            }
        }
        public string Residence
        {
            get { return student_residence; }
            set
            {
                student_residence = value;
                onPropertyChanged(nameof(Residence));
            }
        }

        public string Birth_Date
        {
            get { return birth_date; }
            set
            {
                birth_date = value;
                onPropertyChanged(nameof(Birth_Date));
            }
        }

        public string Phone_Number
        {
            get { return phone_number; }
            set
            {
                phone_number = value;
                onPropertyChanged(nameof(Phone_Number));
            }
        }

        public char Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                onPropertyChanged(nameof(Sex));
            }
        }

        public int CheckedID
        {
            get { return checkedID; }
            set
            {
                checkedID = value;
                onPropertyChanged(nameof(checkedID));
            }
        }

        public bool AddingAvailable
        {
            get { return addingAvailable; }
            set
            {
                addingAvailable = value;
                onPropertyChanged(nameof(AddingAvailable));
            }
        }

        public bool EditingAvailable
        {
            get { return editingavailable; }
            set
            {
                addingavailable = value;
                onPropertyChanged(nameof(EditingAvailable));
            }
        }


       

        #endregion

        private void CleanForm()
        {
            Name = " ";
            SecondName = " ";
            Birth_Date = "2015-01-01";
            Residence = " ";
            EditingAvailable = false;
            AddingAvailable = true;
        }

        #region Instructions
        private ICommand add = null;
        public ICommand ADD
        {
            get
            {
                if (add == null)
                    add = new RelayCommand(
                        arg =>
                        {
                            var student = new Students(Name, SecondName, Sex, Birth_Date, Residence, Phone_Number);

                            if (model.AddStudentToDataBase(student))
                            {
                                CleanForm();
                                System.Windows.MessageBox.Show("Student Added To Database!");
                            }
                        }
                        ,
                        arg => (Name != "") && (SecondName != "") && (Residence != "") && (Birth_Date != "") && (Sex != ' ')
                        );


                return add;
            }
        }

        private ICommand loadForm = null;
        public ICommand LOADFORM
        {

            get
            {
                if (loadForm == null)
                    loadForm = new RelayCommand(
                        arg =>
                        {
                            if (CheckedID > -1)
                            {
                                Name = Current_Student.Student_name;
                                SecondName = Current_Student.Student_secondName;
                                Birth_Date = Current_Student.Birth_date;
                                Residence = Current_Student.Student_residence;
                                Sex = Current_Student.Student_sex;
                                Phone_Number = Current_Student.Phone_number;
                                AddingAvailable = false;
                                EditingAvailable = true;
                            }
                            else
                            {
                                CleanForm();
                            }
                        }
                        ,
                        arg => true
                        );


                return loadForm;
            }

        }

        private ICommand edit = null;
        public ICommand EDIT
        {
            get
            {
                if (edit == null)
                    edit = new RelayCommand(
                    arg =>
                    {
                        model.EditStudentInDataBase(new Students(Name, SecondName, Sex, Birth_Date, Residence, Phone_Number), (sbyte)Current_Student.Student_id);
                        CheckedID = -1;
                        AddingAvailable = true;
                    }
                         ,
                    arg => (Current_Student?.Student_name != Name) || (Current_Student?.Student_secondName != SecondName) || (Current_Student?.Birth_date != Birth_Date) || (Current_Student?.Student_residence != Residence) || (Current_Student?.Student_sex != Sex) || (Current_Student?.Phone_number != Phone_Number)
                   );


                return edit;
            }
        }

        #endregion
    }

}
