using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNI_Classbook_Project
{
    public class DB_Utils_OleDb : DB_Utils_Interface
    {
        private System.Data.OleDb.OleDbConnection GetConnection()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string dataBase_path = Directory.GetParent(workingDirectory).Parent.FullName;
            return new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dataBase_path + "\\Classbook.accdb");
        }

    #region utils
        public Int32 GetMaxGrades_Id()
        {
            string Id = "";
            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet Auxiliar_DataSet = new DataSet();

            try
            {
                string sql_query = "SELECT Id from [Note] ORDER BY Id DESC;";

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(Auxiliar_DataSet, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }
                Id = Auxiliar_DataSet.Tables[0].Rows[0][0].ToString();
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return Int32.Parse(Id);
        }

        public List<string> GetStudents_Codes()
        {
            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet aux_ds = new DataSet();

            try
            {
                string sql_query = "Select [Nr matricol] FROM Studenti ORDER BY [Nr matricol]";

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(aux_ds, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }

                List<string> list = new List<string>();
                foreach (DataRow row in aux_ds.Tables[0].Rows)
                {
                    string cell = row.ItemArray.GetValue(0).ToString();
                    list.Add(cell);
                }

                return list;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<string> GetCourses_Codes()
        {
            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet aux_ds = new DataSet();

            try
            {
                string sql_query = "Select [Cod disciplina] FROM Materii ORDER BY [Cod disciplina]";

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(aux_ds, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }

                List<string> list = new List<string>();
                foreach (DataRow row in aux_ds.Tables[0].Rows)
                {
                    string cell = row.ItemArray.GetValue(0).ToString();
                    list.Add(cell);
                }

                return list;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<string> GetCourses_Names()
        {
            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet aux_ds = new DataSet();

            try
            {
                string sql_query = "Select Denumire FROM Materii ORDER BY Denumire";

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(aux_ds, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }

                List<string> list = new List<string>();
                foreach (DataRow row in aux_ds.Tables[0].Rows)
                {
                    string cell = row.ItemArray.GetValue(0).ToString();
                    list.Add(String.Format("[{0}]", cell));
                }

                return list;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataTable Get_Grades_Report(int passing_grade = 5)
        {
            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataTable Report_Table = new DataTable();

            try
            {
                // Original Query - working
                string sql_query = string.Format(
                    "SELECT Studenti.Nume, Studenti.Prenume, Materii.Denumire, Materii.Credite, Note.Nota " +
                    "FROM Studenti INNER JOIN (Materii INNER JOIN [Note] ON Materii.[Cod disciplina] = [Note].[Cod disciplina]) ON Studenti.[Nr Matricol] = [Note].[Nr Matricol] " +
                    "ORDER BY Studenti.Nume, Studenti.Prenume;", passing_grade.ToString());

                // Query that computes everything - does not work
                //string sql_query = string.Format(
                //    "SELECT Studenti.Nume, Studenti.Prenume, Materii.Denumire, [Note].Nota, " +
                //    "AVG([Note].Nota) OVER(PARTITION BY Studenti.Nume) AS Media, " +
                //    "SUM(CASE WHEN MIN([Note].Nota) >= {0} THEN Materii.Credite END) OVER (PARTITION BY Studenti.Nume) AS Punctaj, " +
                //    "CASE WHEN MIN([Note].Nota) OVER (PARTITION BY Studenti.Nume) >= {0} THEN 'True' ELSE 'False' END AS Integralist " +
                //    "FROM Studenti INNER JOIN (Materii INNER JOIN [Note] ON Materii.[Cod disciplina] = [Note].[Cod disciplina]) ON Studenti.[Nr matricol] = [Note].[Nr matricol] " +
                //    "GROUP BY Studenti.Nume, Studenti.Prenume, Materii.Denumire, Materii.Credite, [Note].Nota " +
                //    "ORDER BY Studenti.Nume", passing_grade.ToString());

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(Report_Table);
                }
                finally
                {
                    dataAd.Dispose();
                }
                return Report_Table;
            }
            //catch (System.Data.OleDb.OleDbException e)
            //{
            //    Console.WriteLine(e.Message);
            //    MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return null;
            //}
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    #endregion

    #region on load data
        public DataSet Load_Students()
        {
            string sortfield = "Nume, Prenume";

            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet DataSet_Students = new DataSet();

            try
            {
                string sql_query = "SELECT [Nr Matricol], Nume, Prenume FROM Studenti WHERE sters = 0 ORDER BY " + sortfield;

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(DataSet_Students, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }
                return DataSet_Students;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataSet Load_Courses()
        {
            string sortfield = "Denumire";

            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet DataSet_Courses = new DataSet();

            try
            {
                string sql_query = "SELECT [Cod disciplina], Denumire, Credite FROM Materii WHERE sters = 0 ORDER BY " + sortfield;

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(DataSet_Courses, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }
                return DataSet_Courses;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataSet Load_Grades()
        {
            string sortfield = "Id";

            System.Data.OleDb.OleDbConnection conn = GetConnection();
            DataSet DataSet_Grades = new DataSet();

            try
            {
                string sql_query = "SELECT Id, [Cod disciplina], [Nr matricol], Nota FROM [Note] WHERE sters = 0 ORDER BY " + sortfield;

                System.Data.OleDb.OleDbDataAdapter dataAd = new System.Data.OleDb.OleDbDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(DataSet_Grades, "Classbook");
                }
                finally
                {
                    dataAd.Dispose();
                }
                return DataSet_Grades;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    #endregion

    #region on save data
        public void InsertInto_Students(string code, string name, string surname)
        {
            #region check-ups
            if (code == "" || code == null)
            {
                MessageBox.Show("Campul numar matricol nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(code, out _))
            {
                MessageBox.Show("Numarul matricol este invalid. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (GetStudents_Codes().Contains(code.ToString()))
            {
                DialogResult result = MessageBox.Show(
                    "Numarul matricol exista deja. \nDoriti sa modificati intrarea deja existenta? ",
                    "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                {
                    Update_Students(code, code, name, surname);
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();
            try
            {
                string sql_query = "INSERT INTO Studenti ( [Nr matricol], Nume, Prenume ) VALUES (@code, @name, @surname);";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@code", Int32.Parse(code)));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@name", name == null ? "" : name.ToString()));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@surname", surname == null ? "" : surname.ToString()));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Added!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void InsertInto_Courses(string code, string name, string credits)
        {
            #region check-ups
            if (code == "" || code == null)
            {
                MessageBox.Show("Campul cod disciplina nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(credits, out _))
            {
                MessageBox.Show("Creditele sunt invalide. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (GetCourses_Codes().Contains(code.ToString()))
            {
                DialogResult result = MessageBox.Show(
                    "Codul disciplinei exista deja. \nDoriti sa modificati intrarea deja existenta? ",
                    "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                {
                    Update_Courses(code, code, name, credits);
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();
            try
            {
                string sql_query = "INSERT INTO Materii ( [Cod disciplina], Denumire, Credite ) VALUES(@code, @name, @credits); ";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@code", code));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@name", name == null ? "" : name.ToString()));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@credits", credits != null ? Int32.Parse(credits) : 0));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Added!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void InsertInto_Grades(string c_code, string s_code, string grade)
        {
            #region check-ups
            if (c_code == "" || c_code == null)
            {
                MessageBox.Show("Campul cod disciplina nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (s_code == "" || s_code == null)
            {
                MessageBox.Show("Campul numar matricol nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(s_code, out _))
            {
                MessageBox.Show("Numarul matricol este invalid. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(grade, out _))
            {
                MessageBox.Show("Nota este invalida. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!GetStudents_Codes().Contains(s_code.ToString()))
            {
                MessageBox.Show("Nu exista acest numar matricol in baza de date. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!GetCourses_Codes().Contains(c_code.ToString()))
            {
                MessageBox.Show("Nu exista acest cod de disciplina in baza de date. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();
            try
            {
                string sql_query = "INSERT INTO [Note] ( Id, [Cod disciplina], [Nr matricol], Nota ) VALUES(@id, @c_code, @s_code, @grade); ";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@id", GetMaxGrades_Id() + 1));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@c_code", c_code));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@s_code", Int32.Parse(s_code)));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@grade", grade == "" || grade == null ? 0 : Int32.Parse(grade)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Added!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    #endregion

    #region on delete data
        public void Delete_Students(string code)
        {
            #region check-ups
            if (!GetStudents_Codes().Contains(code.ToString()))
            {
                MessageBox.Show("Wtf \nDelete_Students \n!GetStudents_Codes().Contains(code.ToString())", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();

            try
            {
                string sql_query = "UPDATE Studenti SET sters = 1 WHERE[Nr matricol] = @code; ";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@code", Int32.Parse(code)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Data Deleted!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Delete_Courses(string code)
        {
            #region check-ups
            if (!GetCourses_Codes().Contains(code.ToString()))
            {
                MessageBox.Show("Wtf \nDelete_Courses \n!GetCourses_Codes().Contains(code.ToString())", "Wtf", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();

            try
            {
                string sql_query = "UPDATE Materii SET sters = 1 WHERE[Cod Disciplina] = @code; ";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@code", code));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Data Deleted!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Delete_Grades(string Id)
        {
            System.Data.OleDb.OleDbConnection conn = GetConnection();

            try
            {
                string sql_query = "UPDATE [Note] SET sters = 1 WHERE Id = @Id; ";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", Int32.Parse(Id)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Data Deleted!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    #endregion

    #region on update data
        public void Update_Students(string code, string new_code, string new_name, string new_surname)
        {
            #region check-ups
            if (new_code == "" || new_code == null)
            {
                MessageBox.Show("Campul numar matricol nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(new_code, out _))
            {
                MessageBox.Show("Numarul matricol este invalid. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (GetStudents_Codes().Contains(new_code.ToString()) && code != new_code)
            {
                DialogResult result = MessageBox.Show(
                    "Numarul matricol exista deja. \nDoriti sa modificati intrarea deja existenta? ",
                    "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                {
                    Update_Students(new_code, new_code, new_name, new_surname);
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();

            try
            {
                string sql_query =
                    "UPDATE Studenti SET " +
                    "[Nr matricol] = @new_code, " +
                    "Nume          = @new_name, " +
                    "Prenume       = @new_surname, " +
                    "sters         = 0 " +
                    "WHERE [Nr matricol] = @code;";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_code", Int32.Parse(new_code)));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_name", new_name == null ? "" : new_name.ToString()));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_surname", new_surname == null ? "" : new_surname.ToString()));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@code", Int32.Parse(code)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Updated!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Update_Courses(string code, string new_code, string new_name, string new_credits)
        {
            #region check-ups
            if (new_code == "" || new_code == null)
            {
                MessageBox.Show("Campul cod disciplina nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(new_credits, out _))
            {
                MessageBox.Show("Creditele sunt invalide. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (GetCourses_Codes().Contains(new_code.ToString()) && code != new_code)
            {
                DialogResult result = MessageBox.Show(
                    "Codul disciplinei exista deja. \nDoriti sa modificati intrarea deja existenta? ",
                    "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                {
                    Update_Courses(new_code, new_code, new_name, new_credits);
                    return;
                }
                else
                {
                    return;
                }
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();

            try
            {
                string sql_query =
                    "UPDATE Materii SET " +
                    "[Cod disciplina] = @new_code, " +
                    "Denumire         = @new_name, " +
                    "Credite          = @new_credits, " +
                    "sters         = 0 " +
                    "WHERE [Cod disciplina] = @code;";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_code", new_code));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_name", new_name == null ? "" : new_name.ToString()));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_credits", new_credits != null ? Int32.Parse(new_credits) : 0));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@code", code));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Updated!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                // TODO Fix
                /*
                 * 'The changes you requested to the table were not successful because they would create duplicate values in the index, 
                 * primary key, or relationship. Change the data in the field or fields that contain duplicate data, remove the index, 
                 * or redefine the index to permit duplicate entries and try again.'
                 */
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Update_Grades(string Id, string new_c_code, string new_s_code, string new_grade)
        {
            #region check-ups
            if (new_c_code == "" || new_c_code == null)
            {
                MessageBox.Show("Campul cod disciplina nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (new_s_code == "" || new_s_code == null)
            {
                MessageBox.Show("Campul numar matricol nu trebuie sa fie gol. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(new_s_code, out _))
            {
                MessageBox.Show("Numarul matricol este invalid. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!Int32.TryParse(new_grade, out _))
            {
                MessageBox.Show("Nota este invalida. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!GetStudents_Codes().Contains(new_s_code.ToString()))
            {
                MessageBox.Show("Nu exista acest numar matricol in baza de date. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!GetCourses_Codes().Contains(new_c_code.ToString()))
            {
                MessageBox.Show("Nu exista acest cod de disciplina in baza de date. ", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            #endregion

            System.Data.OleDb.OleDbConnection conn = GetConnection();

            try
            {
                string sql_query =
                    "UPDATE [Note] SET " +
                    "[Cod disciplina] = @new_code_c, " +
                    "[Nr matricol]    = @new_code_s, " +
                    "Nota             = @new_grade, " +
                    "sters         = 0 " +
                    "WHERE Id = @Id; ";

                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql_query, conn);
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_code_c", new_c_code));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_code_s", Int32.Parse(new_s_code)));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@new_grade", Int32.Parse(new_grade)));
                cmd.Parameters.Add(new System.Data.OleDb.OleDbParameter("@Id", Int32.Parse(Id)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Updated!");
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                // TODO Does not change values
                Console.WriteLine(e.Message);
                MessageBox.Show("Operatia nu a putut fi efectuata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    #endregion
    }
}
