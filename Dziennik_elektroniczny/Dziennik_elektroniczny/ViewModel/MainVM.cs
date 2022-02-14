using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dziennik_elektroniczny.ViewModel
{
    using DAL;
    using Dziennik_elektroniczny.Model;
    using BaseClass;

    class MainVM
    {
        private readonly Model model = new Model();

        public TabAddStudentToDataBaseVM TabAddStudentVM { get; set; }
        public TabStudentsInClasses TabStudentInClassesVM { get; set; }
        public TabStudentsComments TabStudentComments { get; set; }
        public TabStudentAbsences TabStudentAbsences { get; set; }
        public TabStudentGradesWithSubjectNames TabStudentGradesWithSubjectNames { get; set; }
        public TabStudentAverage TabStudentAverage { get; set; }
        public TabAddGradeToStudent TabAddGradeToStudent {get; set;}
        
        public TabAddStudentToClass TabAddStudentToClass { get; set; }
        public MainVM()
        {
            //stworzenie viemodeli pomocniczych - dla każdej karty
            //przekazanie referencji do instancji modelu tak
            //aby wszystkie obiekty modeli widoków pracowały na tym samym modelu
            TabAddStudentVM = new TabAddStudentToDataBaseVM(model);
            TabStudentInClassesVM = new TabStudentsInClasses(model);
            TabStudentComments = new TabStudentsComments(model);
            TabStudentAbsences = new TabStudentAbsences(model);
            TabStudentGradesWithSubjectNames = new TabStudentGradesWithSubjectNames(model);
            TabStudentAverage = new TabStudentAverage(model);
            TabAddGradeToStudent = new TabAddGradeToStudent(model);
            TabAddStudentToClass = new TabAddStudentToClass(model);

        }

    }
}
