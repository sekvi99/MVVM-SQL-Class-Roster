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
    class TabStudentsComments:ViewModelBase
    {
        #region Private Fields
        private readonly Model model = null;
        private ObservableCollection<Comments> comments = null;
        private ObservableCollection<Students> students = null;

        private int selectedStudentIndex = -1;
        private int selectedCommentIndex = -1;
        #endregion

        #region Constructors
        public TabStudentsComments(Model model)
        {
            this.model = model;
            comments = model.Comments;
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

        public int SelectedCommentIndex
        {
            get => selectedCommentIndex;
            set
            {
                selectedCommentIndex = value;
                onPropertyChanged(nameof(SelectedCommentIndex));
            }
        }

        public Students CurrentStudent { get; set; }
        public Comments CurrentComment { get; set; }

        public ObservableCollection<Students> Students
        {
            get { return students; }
            set
            {
                students = value;
                onPropertyChanged(nameof(Students));
            }
        }

        public ObservableCollection<Comments> Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                onPropertyChanged(nameof(Comments));
            }
        }

        #endregion

        #region Methods
        public void RefreshStudents()
        {
            Students = model.Students;
            SelectedStudentIndex = -1;
        }

        public void RefreshComments()
        {
            Comments = model.Comments;
            SelectedCommentIndex = -1;
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
                            if (CurrentComment != null)
                                Students = model.GetStudentFromComments(CurrentComment);
                        },
                        arg => true
                        );
                return loadStudents;
            }
        }

        private ICommand loadComments;
        public ICommand LoadComments
        {
            get
            {
                if (loadComments == null)
                    loadComments = new RelayCommand(
                        arg =>
                        {
                            if (CurrentStudent != null)
                                Comments = model.GetCommentsFromStudent(CurrentStudent);
                        },
                        arg => true
                        );
                return loadComments;
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

        private ICommand loadAllComments = null;
        public ICommand LoadAllComments
        {
            get
            {
                if (loadAllComments == null)
                    loadAllComments = new RelayCommand(
                        arg =>
                        {
                            Comments = model.Comments;
                            SelectedCommentIndex = -1;
                        },
                        arg => true
                        );
                return loadAllComments;
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
                            RefreshComments();
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
