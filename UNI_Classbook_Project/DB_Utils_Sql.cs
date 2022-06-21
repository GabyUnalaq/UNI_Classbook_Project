using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UNI_Classbook_Project
{
    public class DB_Utils_Sql : DB_Utils_Interface
    {
        private SqlConnection GetConnection()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string dataBase_path = Directory.GetParent(workingDirectory).Parent.FullName; 
            return new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"" + dataBase_path + "\\Catalog.mdf\";Integrated Security=True");
        }

    #region utils
        public Int32 GetMaxGrades_Id()
        {
            string Id = "";
            SqlConnection conn = GetConnection();
            DataSet Auxiliar_DataSet = new DataSet();

            try
            {
                string sql_query = "SELECT Id from [Note] ORDER BY Id DESC;";

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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
            SqlConnection conn = GetConnection();
            DataSet aux_ds = new DataSet();

            try
            {
                string sql_query = "Select [Nr matricol] FROM Studenti ORDER BY [Nr matricol]";

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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
            SqlConnection conn = GetConnection();
            DataSet aux_ds = new DataSet();

            try
            {
                string sql_query = "Select [Cod disciplina] FROM Materii ORDER BY [Cod disciplina]";

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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
            SqlConnection conn = GetConnection();
            DataSet aux_ds = new DataSet();

            try
            {
                string sql_query = "Select Denumire FROM Materii ORDER BY Denumire";

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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
            SqlConnection conn = GetConnection();
            DataTable Report_Table = new DataTable();

            try
            {
                // Query like in the OleDb Class - working
                //string sql_query = "SELECT Studenti.Nume, Studenti.Prenume, Materii.Denumire, Materii.Credite, Note.Nota " +
                //    "FROM Studenti INNER JOIN (Materii INNER JOIN [Note] ON Materii.[Cod disciplina] = [Note].[Cod disciplina]) ON Studenti.[Nr Matricol] = [Note].[Nr Matricol] " +
                //    "ORDER BY Studenti.Nume, Studenti.Prenume;";

                // Query that computes everything - working
                string sql_query = string.Format(
                    "SELECT Studenti.Nume, Studenti.Prenume, Materii.Denumire, [Note].Nota, " +
                    "AVG([Note].Nota) OVER(PARTITION BY Studenti.Nume) AS Media, " +
                    "SUM(CASE WHEN MIN([Note].Nota) >= {0} THEN Materii.Credite END) OVER (PARTITION BY Studenti.Nume) AS Punctaj, " +
                    "CASE WHEN MIN([Note].Nota) OVER (PARTITION BY Studenti.Nume) >= {0} THEN 'True' ELSE 'False' END AS Integralist " +
                    "FROM Studenti INNER JOIN (Materii INNER JOIN [Note] ON Materii.[Cod disciplina] = [Note].[Cod disciplina]) ON Studenti.[Nr matricol] = [Note].[Nr matricol] " +
                    "GROUP BY Studenti.Nume, Studenti.Prenume, Materii.Denumire, Materii.Credite, [Note].Nota " +
                    "ORDER BY Studenti.Nume", passing_grade.ToString());

                // Pivot method (testing) - does not work
                //string cols = string.Join(",", GetCourses_Names().ToArray());
                //string sql_query = String.Format(
                //    "SELECT Nume, Prenume, {0} FROM ( SELECT Studenti.Nume, Studenti.Prenume, Materii.Denumire, Materii.Credite, [Note].Nota " +
                //    "FROM Studenti INNER JOIN (Materii INNER JOIN [Note] ON Materii.[Cod disciplina] = [Note].[Cod disciplina]) ON Studenti.[Nr matricol] = [Note].[Nr matricol] ) AS SourceTable " +
                //    "PIVOT ( MAX([Note].Nota) FOR Denumire IN ({0}) ) AS PivotTable"
                //    , cols);

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
                try
                {
                    dataAd.Fill(Report_Table);
                }
                finally
                {
                    dataAd.Dispose();
                }
                return Report_Table;
                //return GetInversedDataTable(Report_Table, "Denumire");
            }
            catch (SqlException e)
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

    #region on load data
        public DataSet Load_Students()
        {
            string sortfield = "Nume, Prenume";

            SqlConnection conn = GetConnection();
            DataSet DataSet_Students = new DataSet();

            try
            {
                string sql_query = "SELECT [Nr Matricol], Nume, Prenume FROM Studenti WHERE sters = 0 ORDER BY " + sortfield;

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();
            DataSet DataSet_Courses = new DataSet();

            try
            {
                string sql_query = "SELECT [Cod disciplina], Denumire, Credite FROM Materii WHERE sters = 0 ORDER BY " + sortfield;

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();
            DataSet DataSet_Grades = new DataSet();

            try
            {
                string sql_query = "SELECT Id, [Cod disciplina], [Nr matricol], Nota FROM [Note] WHERE sters = 0 ORDER BY " + sortfield;

                SqlDataAdapter dataAd = new SqlDataAdapter(sql_query, conn);
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
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();
            try
            {
                string sql_query = "INSERT INTO Studenti ( [Nr matricol], Nume, Prenume ) VALUES (@code, @name, @surname);";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@code", Int32.Parse(code));
                cmd.Parameters.AddWithValue("@name", name == null ? "" : name.ToString());
                cmd.Parameters.AddWithValue("@surname", surname == null ? "" : surname.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Added!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();
            try
            {
                string sql_query = "INSERT INTO Materii ( [Cod disciplina], Denumire, Credite ) VALUES(@code, @name, @credits); ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@name", name == null ? "" : name.ToString());
                cmd.Parameters.AddWithValue("@credits", credits != null ? Int32.Parse(credits) : 0);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Added!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();
            try
            {
                string sql_query = "INSERT INTO [Note] ( Id, [Cod disciplina], [Nr matricol], Nota ) VALUES(@id, @c_code, @s_code, @grade); ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@id", GetMaxGrades_Id() + 1);
                cmd.Parameters.AddWithValue("@c_code", c_code);
                cmd.Parameters.AddWithValue("@s_code", Int32.Parse(s_code));
                cmd.Parameters.AddWithValue("@grade", grade == "" || grade == null ? 0 : Int32.Parse(grade));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Added!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();

            try
            {
                string sql_query = "UPDATE Studenti SET sters = 1 WHERE[Nr matricol] = @code; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@code", Int32.Parse(code));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Data Deleted!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();

            try
            {
                string sql_query = "UPDATE Materii SET sters = 1 WHERE[Cod Disciplina] = @code; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@code", code);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Data Deleted!");
            }
            catch (SqlException e)
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
            SqlConnection conn = GetConnection();

            try
            {
                string sql_query = "UPDATE [Note] SET sters = 1 WHERE Id = @Id; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@Id", Int32.Parse(Id));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("Data Deleted!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();

            try
            {
                string sql_query =
                    "UPDATE Studenti SET " +
                    "[Nr matricol] = @new_code, " +
                    "Nume          = @new_name, " +
                    "Prenume       = @new_surname, " +
                    "sters         = 0 " +
                    "WHERE [Nr matricol] = @code;";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@new_code", Int32.Parse(new_code));
                cmd.Parameters.AddWithValue("@new_name", new_name == null ? "" : new_name.ToString());
                cmd.Parameters.AddWithValue("@new_surname", new_surname == null ? "" : new_surname.ToString());
                cmd.Parameters.AddWithValue("@code", Int32.Parse(code));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Updated!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();

            try
            {
                string sql_query =
                    "UPDATE Materii SET " +
                    "[Cod disciplina] = @new_code, " +
                    "Denumire         = @new_name, " +
                    "Credite          = @new_credits, " +
                    "sters         = 0 " +
                    "WHERE [Cod disciplina] = @code;";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@new_code", new_code);
                cmd.Parameters.AddWithValue("@new_name", new_name == null ? "" : new_name.ToString());
                cmd.Parameters.AddWithValue("@new_credits", new_credits != null ? Int32.Parse(new_credits) : 0);
                cmd.Parameters.AddWithValue("@code", code);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Updated!");
            }
            catch (SqlException e)
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

            SqlConnection conn = GetConnection();

            try
            {
                string sql_query =
                    "UPDATE [Note] SET " +
                    "[Cod disciplina] = @new_code_c, " +
                    "[Nr matricol]    = @new_code_s, " +
                    "Nota             = @new_grade, " +
                    "sters         = 0 " +
                    "WHERE Id = @Id; ";

                SqlCommand cmd = new SqlCommand(sql_query, conn);
                cmd.Parameters.AddWithValue("@new_code_c", new_c_code);
                cmd.Parameters.AddWithValue("@new_code_s", Int32.Parse(new_s_code));
                cmd.Parameters.AddWithValue("@new_grade", Int32.Parse(new_grade));
                cmd.Parameters.AddWithValue("@Id", Int32.Parse(Id));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("New data is Updated!");
            }
            catch (SqlException e)
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
