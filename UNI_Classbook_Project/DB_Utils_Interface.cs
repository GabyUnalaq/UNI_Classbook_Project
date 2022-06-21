using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNI_Classbook_Project
{
    interface DB_Utils_Interface
    {
        // GetConnection();

    #region utils
        Int32 GetMaxGrades_Id();
        List<string> GetStudents_Codes();
        List<string> GetCourses_Codes();
        List<string> GetCourses_Names();
        DataTable Get_Grades_Report(int passing_grade = 5);
    #endregion

    #region on load data
        DataSet Load_Students();
        DataSet Load_Courses();
        DataSet Load_Grades();
    #endregion

    #region on save data
        void InsertInto_Students(string code, string name, string surname);
        void InsertInto_Courses(string code, string name, string credits);
        void InsertInto_Grades(string c_code, string s_code, string grade);
    #endregion

    #region on delete data
        void Delete_Students(string code);
        void Delete_Courses(string code);
        void Delete_Grades(string Id);
    #endregion

    #region on update data
        void Update_Students(string code, string new_code, string new_name, string new_surname);
        void Update_Courses(string code, string new_code, string new_name, string new_credits);
        void Update_Grades(string Id, string new_c_code, string new_s_code, string new_grade);
    #endregion

    }
}
