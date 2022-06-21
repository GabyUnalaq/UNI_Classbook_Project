using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNI_Classbook_Project
{
    public partial class Window : Form
    {
        DB_Utils_Interface DataBase_Classbook;

        DataSet DataSet_Students = new DataSet();
        DataSet DataSet_Courses = new DataSet();
        DataSet DataSet_Grades = new DataSet();

        public Window()
        {
            InitializeComponent();

            Panel_Edits.SendToBack();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            // Hiding Panels
            Panel_Grades.Hide();
            Panel_Courses.Hide();
        }

        private DB_Utils_Interface DataBase_Init()
        {
            DialogResult result = MessageBox.Show(
                    "Ce tip de baza de date folositi? \n - Yes: Access.accdb \n - No: Sql.mdf", "Alegerea tipului bazei de date", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                return new DB_Utils_OleDb();
            }
            else {
                return new DB_Utils_Sql();
            }
        }

#region on exit handlers

        private void Butt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClosing_OleDb(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string dataBase_path = Directory.GetParent(workingDirectory).Parent.FullName;
                DialogResult result = MessageBox.Show(
                    "Salvati inainte de iesire?", "Iesire", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (System.IO.File.Exists(dataBase_path + "\\Classbook_copy.accdb"))
                    {
                        try
                        {
                            System.IO.File.Delete(dataBase_path + "\\Classbook_copy.accdb");
                        }
                        catch (System.IO.IOException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    if (System.IO.File.Exists(dataBase_path + "\\Classbook_copy.accdb"))
                    {
                        try
                        {
                            System.IO.File.Copy(
                                dataBase_path + "\\Classbook_copy.accdb",
                                dataBase_path + "\\Classbook.accdb", true);
                            System.IO.File.Delete(dataBase_path + "\\Classbook_copy.accdb");
                        }
                        catch (System.IO.IOException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormClosing_Sql(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                String Current_Dir = Directory.GetCurrentDirectory();
                DialogResult result = MessageBox.Show(
                    "Sigur doriti sa iesiti?", "Iesire", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mLoaded) {
                Application.Exit();
                return;
            }
            
            if (DataBase_Classbook.GetType().Equals(typeof(DB_Utils_OleDb))) {
                FormClosing_OleDb(e);
            }
            else {
                FormClosing_Sql(e);
            }
        }

#endregion

#region utils

        private void Clear_TextBoxes()
        {
            if (Panel_Students.Visible)
            {
                Text_Student_Code.Text = "";
                Text_Student_Name.Text = "";
                Text_Student_Surname.Text = "";
            }
            else if (Panel_Courses.Visible)
            {
                Text_Courses_Code.Text = "";
                Text_Courses_Name.Text = "";
                Text_Courses_Credits.Text = "";
            }
            else if (Panel_Grades.Visible)
            {
                Text_Grades_Code_S.Text = "";
                Text_Grades_Code_C.Text = "";
                Text_Grades_Grade.Text = "";
            }
        }

        private void Populate_TextBoxes()
        {
            if (Panel_Students.Visible)
            {
                Text_Student_Code.Text = Grid_Students.Rows[mClicked_Row].Cells[0].Value.ToString();
                Text_Student_Name.Text = Grid_Students.Rows[mClicked_Row].Cells[1].Value.ToString();
                Text_Student_Surname.Text = Grid_Students.Rows[mClicked_Row].Cells[2].Value.ToString();
            }
            else if (Panel_Courses.Visible)
            {
                Text_Courses_Code.Text = Grid_Courses.Rows[mClicked_Row].Cells[0].Value.ToString();
                Text_Courses_Name.Text = Grid_Courses.Rows[mClicked_Row].Cells[1].Value.ToString();
                Text_Courses_Credits.Text = Grid_Courses.Rows[mClicked_Row].Cells[2].Value.ToString();
            }
            else if (Panel_Grades.Visible)
            {
                Text_Grades_Code_S.Text = Grid_Grades.Rows[mClicked_Row].Cells[1].Value.ToString();
                Text_Grades_Code_C.Text = Grid_Grades.Rows[mClicked_Row].Cells[2].Value.ToString();
                Text_Grades_Grade.Text = Grid_Grades.Rows[mClicked_Row].Cells[3].Value.ToString();
            }
        }

        private void Butt_Load_Data_Click(object sender, EventArgs e)
        {
            DataBase_Classbook = DataBase_Init();

            if (DataBase_Classbook.GetType().Equals(typeof(DB_Utils_OleDb)))
            {
                // Making saving copy for Access Database
                String Current_Dir = Directory.GetCurrentDirectory(); // path\UNI_Classbook_Project\UNI_Classbook_Project\bin\Debug
                String FileDir = Path.GetDirectoryName(Path.GetDirectoryName(Current_Dir)); // path\UNI_Classbook_Project\UNI_Classbook_Project\data
                System.IO.File.Copy(
                    FileDir + "\\\\Classbook.accdb",
                    FileDir + "\\\\Classbook_copy.accdb", true);
            }
            
            Load_dataSets();
            Butt_Report.Enabled = true;
            mLoaded = true;
        }

        private void Load_dataSets()
        {
            // Load Students
            DataSet_Students = DataBase_Classbook.Load_Students();
            Grid_Students.DataSource = DataSet_Students;
            Grid_Students.DataMember = "Classbook";

            // Load Courses
            DataSet_Courses = DataBase_Classbook.Load_Courses();
            Grid_Courses.DataSource = DataSet_Courses;
            Grid_Courses.DataMember = "Classbook";

            // Load Grades
            DataSet_Grades = DataBase_Classbook.Load_Grades();
            Grid_Grades.DataSource = DataSet_Grades;
            Grid_Grades.DataMember = "Classbook";
            Grid_Grades.Columns["Id"].Visible = false;

            // Clearing focus on the tables
            Grid_Students.ClearSelection();
            Grid_Grades.ClearSelection();
            Grid_Courses.ClearSelection();
        }

#endregion

#region on table focus changed handlers

        private void Butt_Students_Click(object sender, EventArgs e)
        {
            // Panel_Students.Visible = True
            Panel_Edits.SendToBack();

            Grid_Students.ClearSelection();
            Panel_Students.Show();

            Panel_Courses.Hide();
            Panel_Grades.Hide();

            mEditing = 0;
            mClicked_Row = -1;
        }

        private void Butt_Courses_Click(object sender, EventArgs e)
        {
            // Panel_Courses.Visible = True
            Panel_Edits.SendToBack();

            Grid_Courses.ClearSelection();
            Panel_Courses.Show();

            Panel_Students.Hide();
            Panel_Grades.Hide();

            mEditing = 0;
            mClicked_Row = -1;
        }

        private void Butt_Grades_Click(object sender, EventArgs e)
        {
            // Panel_Grades.Visible = True
            Panel_Edits.SendToBack();
            
            Grid_Grades.ClearSelection();
            Panel_Grades.Show();

            Panel_Students.Hide();
            Panel_Courses.Hide();

            mEditing = 0;
            mClicked_Row = -1;
        }

#endregion

#region on edit tables handlers

        private void Butt_Insert_Click(object sender, EventArgs e)
        {
            if (!mLoaded)
                return;

            Clear_TextBoxes();

            Panel_Edits.BringToFront();
            Panel_Edit_Students.Hide();
            Panel_Edit_Courses.Hide();
            Panel_Edit_Grades.Hide();

            mEditing = 1;

            if (Panel_Students.Visible)
                Panel_Edit_Students.Show();

            else if(Panel_Courses.Visible)
                Panel_Edit_Courses.Show();

            else if(Panel_Grades.Visible)
                Panel_Edit_Grades.Show();
        }

        private void Butt_Edit_Click(object sender, EventArgs e)
        {
            if (!mLoaded)
                return;

            if (mClicked_Row != -1)
            {
                Panel_Edits.BringToFront();
                Panel_Edit_Students.Hide();
                Panel_Edit_Courses.Hide();
                Panel_Edit_Grades.Hide();

                mEditing = 2;

                if (Panel_Students.Visible)
                    Panel_Edit_Students.Show();

                else if (Panel_Courses.Visible)
                    Panel_Edit_Courses.Show();

                else if (Panel_Grades.Visible)
                    Panel_Edit_Grades.Show();

                else
                    MessageBox.Show("Wtf \nButt_Edit_Click \nPanel_Students.Visible", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                Populate_TextBoxes();
            }
            else
            {
                mEditing = 0;
                MessageBox.Show("Nu ati selectat nici un rand", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Butt_Delete_Click(object sender, EventArgs e)
        {
            if (!mLoaded)
                return;

            if (mClicked_Row != -1)
            {
                DialogResult confirm = MessageBox.Show(
                    "Sunteti sigur ca stergeti aceasta intrare?", "Stergere", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    if (Panel_Students.Visible)
                    {
                        string code = DataSet_Students.Tables[0].Rows[mClicked_Row]["Nr Matricol"].ToString();

                        DataBase_Classbook.Delete_Students(code);
                        Load_dataSets();
                    }
                    else if (Panel_Courses.Visible)
                    {
                        string code = DataSet_Courses.Tables[0].Rows[mClicked_Row]["Cod disciplina"].ToString();

                        DataBase_Classbook.Delete_Courses(code);
                        Load_dataSets();
                    }
                    else if (Panel_Grades.Visible)
                    {
                        string Id = DataSet_Grades.Tables[0].Rows[mClicked_Row]["Id"].ToString();

                        DataBase_Classbook.Delete_Grades(Id);
                        Load_dataSets();
                    }

                    else
                        MessageBox.Show("Wtf", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Nu ati selectat nici un rand \npentru a sterge. \nIesire", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Butt_Edit_Global_Abort_Click(object sender, EventArgs e)
        {
            Panel_Edit_Students.Hide();
            Panel_Edit_Courses.Hide();
            Panel_Edit_Grades.Hide();
            Panel_Edits.SendToBack();
            mEditing = 0;
        }

#endregion

#region on save edits handlers

        private void Butt_Edit_Student_Save_Click(object sender, EventArgs e)
        {
            if (mEditing == 1) // Insert
            {
                DataBase_Classbook.InsertInto_Students(Text_Student_Code.Text, Text_Student_Name.Text, Text_Student_Surname.Text);
            }
            else if (mEditing == 2) // Edit
            {
                string code = DataSet_Students.Tables[0].Rows[mClicked_Row]["Nr Matricol"].ToString();
                DataBase_Classbook.Update_Students(code, Text_Student_Code.Text, Text_Student_Name.Text, Text_Student_Surname.Text);
            }
            else
                MessageBox.Show("Wtf \nButt_Edit_Student_Save_Click mEditing condition\n ", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            Load_dataSets();
            //Grid_Students.Update();
            //Grid_Students.Refresh();

            mEditing = 0;
            Panel_Edits.SendToBack();
        }

        private void Butt_Edit_Courses_Save_Click(object sender, EventArgs e)
        {
            if (mEditing == 1) // Insert
            {
                DataBase_Classbook.InsertInto_Courses(Text_Courses_Code.Text, Text_Courses_Name.Text, Text_Courses_Credits.Text);
            }
            else if (mEditing == 2) // Edit
            {
                string code = DataSet_Courses.Tables[0].Rows[mClicked_Row]["Cod disciplina"].ToString();
                DataBase_Classbook.Update_Courses(code, Text_Courses_Code.Text, Text_Courses_Name.Text, Text_Courses_Credits.Text);
            }
            else
                MessageBox.Show("Wtf \nButt_Edit_Courses_Save_Click mEditing condition\n ", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            Load_dataSets();
            //Grid_Students.Update();
            //Grid_Students.Refresh();

            mEditing = 0;
            Panel_Edits.SendToBack();
        }

        private void Butt_Edit_Grades_Save_Click(object sender, EventArgs e)
        {
            if (mEditing == 1) // Insert
            {
                DataBase_Classbook.InsertInto_Grades(Text_Grades_Code_C.Text, Text_Grades_Code_S.Text, Text_Grades_Grade.Text);
            }
            else if (mEditing == 2) // Edit
            {
                string Id = DataSet_Grades.Tables[0].Rows[mClicked_Row]["Id"].ToString();
                DataBase_Classbook.Update_Grades(Id, Text_Grades_Code_S.Text, Text_Grades_Code_C.Text, Text_Grades_Grade.Text);
            }
            else
                MessageBox.Show("Wtf \nButt_Edit_Grades_Save_Click mEditing condition\n ", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            Load_dataSets();
            //Grid_Students.Update();
            //Grid_Students.Refresh();

            mEditing = 0;
            Panel_Edits.SendToBack();
        }

#endregion

#region on click table rows handler

        private void Grid_Global_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Console.Write("Row selected: " + e.RowIndex + "\n");
            if (mEditing == 0)
                mClicked_Row = e.RowIndex;
            else
            {
                // Clearing focus on the tables
                Grid_Students.ClearSelection();
                Grid_Grades.ClearSelection();
                Grid_Courses.ClearSelection();

                Panel_Edit_Students.Hide();
                Panel_Edit_Courses.Hide();
                Panel_Edit_Grades.Hide();
                Panel_Edits.SendToBack();
                mEditing = 0;
            }
        }

#endregion

#region on report

        private void Butt_Report_Click(object sender, EventArgs e)
        {
            DataTable Report_DataTable = new DataTable();
            Report_DataTable = DataBase_Classbook.Get_Grades_Report();

            if (Report_DataTable == null)
                return;
            StringBuilder csv = new StringBuilder();

            string[] header = Report_DataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            csv.AppendLine(string.Join(",", header));

            foreach (DataRow row in Report_DataTable.Rows)
            {
                string[] cells = row.ItemArray.Select(field => field.ToString()).ToArray();
                csv.AppendLine(string.Join(",", cells));
            }

            //File.WriteAllText("Clasbook_Report.csv", csv.ToString());

            SaveAs(csv.ToString());
        }

        private void SaveAs(string csv)
        {
            SaveFileDialog SaveDialog = new SaveFileDialog
            {
                FileName = "Clasbook_Report.csv",
                Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (SaveDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(SaveDialog.FileName.ToString());
                file.WriteLine(csv);

                file.Close();
            }
        }

#endregion

    }
}
