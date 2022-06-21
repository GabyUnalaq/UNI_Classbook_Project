namespace UNI_Classbook_Project
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.Panel_Students = new System.Windows.Forms.Panel();
            this.Grid_Students = new System.Windows.Forms.DataGridView();
            this.Panel_Courses = new System.Windows.Forms.Panel();
            this.Grid_Courses = new System.Windows.Forms.DataGridView();
            this.Panel_Edits = new System.Windows.Forms.Panel();
            this.Panel_Edit_Courses = new System.Windows.Forms.Panel();
            this.Butt_Edit_Courses_Abort = new System.Windows.Forms.Button();
            this.Butt_Edit_Courses_Save = new System.Windows.Forms.Button();
            this.Text_Courses_Credits = new System.Windows.Forms.TextBox();
            this.Text_Courses_Name = new System.Windows.Forms.TextBox();
            this.Text_Courses_Code = new System.Windows.Forms.TextBox();
            this.Label_Courses_Credits = new System.Windows.Forms.Label();
            this.Label_Courses_Name = new System.Windows.Forms.Label();
            this.Label_Courses_Code = new System.Windows.Forms.Label();
            this.Panel_Edit_Grades = new System.Windows.Forms.Panel();
            this.Butt_Edit_Grades_Abort = new System.Windows.Forms.Button();
            this.Butt_Edit_Grades_Save = new System.Windows.Forms.Button();
            this.Text_Grades_Grade = new System.Windows.Forms.TextBox();
            this.Text_Grades_Code_C = new System.Windows.Forms.TextBox();
            this.Text_Grades_Code_S = new System.Windows.Forms.TextBox();
            this.Label_Grades_Grade = new System.Windows.Forms.Label();
            this.Label_Grades_Code_C = new System.Windows.Forms.Label();
            this.Label_Grades_Code_S = new System.Windows.Forms.Label();
            this.Panel_Edit_Students = new System.Windows.Forms.Panel();
            this.Butt_Edit_Student_Abort = new System.Windows.Forms.Button();
            this.Butt_Edit_Student_Save = new System.Windows.Forms.Button();
            this.Text_Student_Surname = new System.Windows.Forms.TextBox();
            this.Text_Student_Name = new System.Windows.Forms.TextBox();
            this.Text_Student_Code = new System.Windows.Forms.TextBox();
            this.Label_Student_Surname = new System.Windows.Forms.Label();
            this.Label_Student_Name = new System.Windows.Forms.Label();
            this.Label_Student_Code = new System.Windows.Forms.Label();
            this.Panel_Grades = new System.Windows.Forms.Panel();
            this.Grid_Grades = new System.Windows.Forms.DataGridView();
            this.Panel_Main = new System.Windows.Forms.Panel();
            this.Panel_Edit_Buttons = new System.Windows.Forms.Panel();
            this.Butt_Delete = new System.Windows.Forms.Button();
            this.Butt_Edit = new System.Windows.Forms.Button();
            this.Butt_Insert = new System.Windows.Forms.Button();
            this.Panel_Grid_Buttons = new System.Windows.Forms.Panel();
            this.Butt_Report = new System.Windows.Forms.Button();
            this.Butt_Exit = new System.Windows.Forms.Button();
            this.Butt_Load_Data = new System.Windows.Forms.Button();
            this.Butt_Courses = new System.Windows.Forms.Button();
            this.Butt_Grades = new System.Windows.Forms.Button();
            this.Butt_Students = new System.Windows.Forms.Button();
            this.Edit_Tips = new System.Windows.Forms.ToolTip(this.components);
            this.Panel_Students.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Students)).BeginInit();
            this.Panel_Courses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Courses)).BeginInit();
            this.Panel_Edits.SuspendLayout();
            this.Panel_Edit_Courses.SuspendLayout();
            this.Panel_Edit_Grades.SuspendLayout();
            this.Panel_Edit_Students.SuspendLayout();
            this.Panel_Grades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Grades)).BeginInit();
            this.Panel_Main.SuspendLayout();
            this.Panel_Edit_Buttons.SuspendLayout();
            this.Panel_Grid_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Students
            // 
            this.Panel_Students.Controls.Add(this.Grid_Students);
            this.Panel_Students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Students.Location = new System.Drawing.Point(117, 67);
            this.Panel_Students.Name = "Panel_Students";
            this.Panel_Students.Padding = new System.Windows.Forms.Padding(3);
            this.Panel_Students.Size = new System.Drawing.Size(684, 383);
            this.Panel_Students.TabIndex = 0;
            // 
            // Grid_Students
            // 
            this.Grid_Students.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Students.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Grid_Students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Students.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Students.Location = new System.Drawing.Point(3, 3);
            this.Grid_Students.MultiSelect = false;
            this.Grid_Students.Name = "Grid_Students";
            this.Grid_Students.ReadOnly = true;
            this.Grid_Students.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Grid_Students.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Students.Size = new System.Drawing.Size(678, 377);
            this.Grid_Students.TabIndex = 0;
            this.Grid_Students.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Global_CellClick);
            // 
            // Panel_Courses
            // 
            this.Panel_Courses.Controls.Add(this.Grid_Courses);
            this.Panel_Courses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Courses.Location = new System.Drawing.Point(117, 67);
            this.Panel_Courses.Name = "Panel_Courses";
            this.Panel_Courses.Padding = new System.Windows.Forms.Padding(3);
            this.Panel_Courses.Size = new System.Drawing.Size(684, 383);
            this.Panel_Courses.TabIndex = 1;
            // 
            // Grid_Courses
            // 
            this.Grid_Courses.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Courses.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Grid_Courses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Courses.Location = new System.Drawing.Point(3, 3);
            this.Grid_Courses.MultiSelect = false;
            this.Grid_Courses.Name = "Grid_Courses";
            this.Grid_Courses.ReadOnly = true;
            this.Grid_Courses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Courses.Size = new System.Drawing.Size(678, 377);
            this.Grid_Courses.TabIndex = 0;
            this.Grid_Courses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Global_CellClick);
            // 
            // Panel_Edits
            // 
            this.Panel_Edits.Controls.Add(this.Panel_Edit_Courses);
            this.Panel_Edits.Controls.Add(this.Panel_Edit_Grades);
            this.Panel_Edits.Controls.Add(this.Panel_Edit_Students);
            this.Panel_Edits.Location = new System.Drawing.Point(496, 231);
            this.Panel_Edits.Name = "Panel_Edits";
            this.Panel_Edits.Size = new System.Drawing.Size(305, 216);
            this.Panel_Edits.TabIndex = 1;
            // 
            // Panel_Edit_Courses
            // 
            this.Panel_Edit_Courses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Edit_Courses.Controls.Add(this.Butt_Edit_Courses_Abort);
            this.Panel_Edit_Courses.Controls.Add(this.Butt_Edit_Courses_Save);
            this.Panel_Edit_Courses.Controls.Add(this.Text_Courses_Credits);
            this.Panel_Edit_Courses.Controls.Add(this.Text_Courses_Name);
            this.Panel_Edit_Courses.Controls.Add(this.Text_Courses_Code);
            this.Panel_Edit_Courses.Controls.Add(this.Label_Courses_Credits);
            this.Panel_Edit_Courses.Controls.Add(this.Label_Courses_Name);
            this.Panel_Edit_Courses.Controls.Add(this.Label_Courses_Code);
            this.Panel_Edit_Courses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel_Edit_Courses.Location = new System.Drawing.Point(0, 0);
            this.Panel_Edit_Courses.Name = "Panel_Edit_Courses";
            this.Panel_Edit_Courses.Size = new System.Drawing.Size(305, 216);
            this.Panel_Edit_Courses.TabIndex = 2;
            // 
            // Butt_Edit_Courses_Abort
            // 
            this.Butt_Edit_Courses_Abort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit_Courses_Abort.Location = new System.Drawing.Point(184, 155);
            this.Butt_Edit_Courses_Abort.Name = "Butt_Edit_Courses_Abort";
            this.Butt_Edit_Courses_Abort.Size = new System.Drawing.Size(87, 34);
            this.Butt_Edit_Courses_Abort.TabIndex = 7;
            this.Butt_Edit_Courses_Abort.Text = "Renunta";
            this.Butt_Edit_Courses_Abort.UseVisualStyleBackColor = true;
            this.Butt_Edit_Courses_Abort.Click += new System.EventHandler(this.Butt_Edit_Global_Abort_Click);
            // 
            // Butt_Edit_Courses_Save
            // 
            this.Butt_Edit_Courses_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit_Courses_Save.Location = new System.Drawing.Point(30, 155);
            this.Butt_Edit_Courses_Save.Name = "Butt_Edit_Courses_Save";
            this.Butt_Edit_Courses_Save.Size = new System.Drawing.Size(87, 34);
            this.Butt_Edit_Courses_Save.TabIndex = 6;
            this.Butt_Edit_Courses_Save.Text = "Salveaza";
            this.Butt_Edit_Courses_Save.UseVisualStyleBackColor = true;
            this.Butt_Edit_Courses_Save.Click += new System.EventHandler(this.Butt_Edit_Courses_Save_Click);
            // 
            // Text_Courses_Credits
            // 
            this.Text_Courses_Credits.Location = new System.Drawing.Point(184, 93);
            this.Text_Courses_Credits.Name = "Text_Courses_Credits";
            this.Text_Courses_Credits.Size = new System.Drawing.Size(100, 23);
            this.Text_Courses_Credits.TabIndex = 5;
            // 
            // Text_Courses_Name
            // 
            this.Text_Courses_Name.Location = new System.Drawing.Point(184, 53);
            this.Text_Courses_Name.Name = "Text_Courses_Name";
            this.Text_Courses_Name.Size = new System.Drawing.Size(100, 23);
            this.Text_Courses_Name.TabIndex = 4;
            // 
            // Text_Courses_Code
            // 
            this.Text_Courses_Code.Location = new System.Drawing.Point(184, 18);
            this.Text_Courses_Code.Name = "Text_Courses_Code";
            this.Text_Courses_Code.Size = new System.Drawing.Size(100, 23);
            this.Text_Courses_Code.TabIndex = 3;
            // 
            // Label_Courses_Credits
            // 
            this.Label_Courses_Credits.AutoSize = true;
            this.Label_Courses_Credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Courses_Credits.Location = new System.Drawing.Point(19, 99);
            this.Label_Courses_Credits.Name = "Label_Courses_Credits";
            this.Label_Courses_Credits.Size = new System.Drawing.Size(60, 17);
            this.Label_Courses_Credits.TabIndex = 2;
            this.Label_Courses_Credits.Text = "Credite";
            // 
            // Label_Courses_Name
            // 
            this.Label_Courses_Name.AutoSize = true;
            this.Label_Courses_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Courses_Name.Location = new System.Drawing.Point(19, 59);
            this.Label_Courses_Name.Name = "Label_Courses_Name";
            this.Label_Courses_Name.Size = new System.Drawing.Size(77, 17);
            this.Label_Courses_Name.TabIndex = 1;
            this.Label_Courses_Name.Text = "Denumire";
            // 
            // Label_Courses_Code
            // 
            this.Label_Courses_Code.AutoSize = true;
            this.Label_Courses_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Courses_Code.Location = new System.Drawing.Point(19, 24);
            this.Label_Courses_Code.Name = "Label_Courses_Code";
            this.Label_Courses_Code.Size = new System.Drawing.Size(109, 17);
            this.Label_Courses_Code.TabIndex = 0;
            this.Label_Courses_Code.Text = "Cod disciplina";
            // 
            // Panel_Edit_Grades
            // 
            this.Panel_Edit_Grades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Edit_Grades.Controls.Add(this.Butt_Edit_Grades_Abort);
            this.Panel_Edit_Grades.Controls.Add(this.Butt_Edit_Grades_Save);
            this.Panel_Edit_Grades.Controls.Add(this.Text_Grades_Grade);
            this.Panel_Edit_Grades.Controls.Add(this.Text_Grades_Code_C);
            this.Panel_Edit_Grades.Controls.Add(this.Text_Grades_Code_S);
            this.Panel_Edit_Grades.Controls.Add(this.Label_Grades_Grade);
            this.Panel_Edit_Grades.Controls.Add(this.Label_Grades_Code_C);
            this.Panel_Edit_Grades.Controls.Add(this.Label_Grades_Code_S);
            this.Panel_Edit_Grades.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel_Edit_Grades.Location = new System.Drawing.Point(0, 0);
            this.Panel_Edit_Grades.Name = "Panel_Edit_Grades";
            this.Panel_Edit_Grades.Size = new System.Drawing.Size(305, 216);
            this.Panel_Edit_Grades.TabIndex = 1;
            // 
            // Butt_Edit_Grades_Abort
            // 
            this.Butt_Edit_Grades_Abort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit_Grades_Abort.Location = new System.Drawing.Point(184, 155);
            this.Butt_Edit_Grades_Abort.Name = "Butt_Edit_Grades_Abort";
            this.Butt_Edit_Grades_Abort.Size = new System.Drawing.Size(87, 34);
            this.Butt_Edit_Grades_Abort.TabIndex = 7;
            this.Butt_Edit_Grades_Abort.Text = "Renunta";
            this.Butt_Edit_Grades_Abort.UseVisualStyleBackColor = true;
            this.Butt_Edit_Grades_Abort.Click += new System.EventHandler(this.Butt_Edit_Global_Abort_Click);
            // 
            // Butt_Edit_Grades_Save
            // 
            this.Butt_Edit_Grades_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit_Grades_Save.Location = new System.Drawing.Point(30, 155);
            this.Butt_Edit_Grades_Save.Name = "Butt_Edit_Grades_Save";
            this.Butt_Edit_Grades_Save.Size = new System.Drawing.Size(87, 34);
            this.Butt_Edit_Grades_Save.TabIndex = 6;
            this.Butt_Edit_Grades_Save.Text = "Salveaza";
            this.Butt_Edit_Grades_Save.UseVisualStyleBackColor = true;
            this.Butt_Edit_Grades_Save.Click += new System.EventHandler(this.Butt_Edit_Grades_Save_Click);
            // 
            // Text_Grades_Grade
            // 
            this.Text_Grades_Grade.Location = new System.Drawing.Point(184, 93);
            this.Text_Grades_Grade.Name = "Text_Grades_Grade";
            this.Text_Grades_Grade.Size = new System.Drawing.Size(100, 23);
            this.Text_Grades_Grade.TabIndex = 5;
            // 
            // Text_Grades_Code_C
            // 
            this.Text_Grades_Code_C.Location = new System.Drawing.Point(184, 53);
            this.Text_Grades_Code_C.Name = "Text_Grades_Code_C";
            this.Text_Grades_Code_C.Size = new System.Drawing.Size(100, 23);
            this.Text_Grades_Code_C.TabIndex = 4;
            // 
            // Text_Grades_Code_S
            // 
            this.Text_Grades_Code_S.Location = new System.Drawing.Point(184, 18);
            this.Text_Grades_Code_S.Name = "Text_Grades_Code_S";
            this.Text_Grades_Code_S.Size = new System.Drawing.Size(100, 23);
            this.Text_Grades_Code_S.TabIndex = 3;
            // 
            // Label_Grades_Grade
            // 
            this.Label_Grades_Grade.AutoSize = true;
            this.Label_Grades_Grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Grades_Grade.Location = new System.Drawing.Point(19, 99);
            this.Label_Grades_Grade.Name = "Label_Grades_Grade";
            this.Label_Grades_Grade.Size = new System.Drawing.Size(42, 17);
            this.Label_Grades_Grade.TabIndex = 2;
            this.Label_Grades_Grade.Text = "Nota";
            // 
            // Label_Grades_Code_C
            // 
            this.Label_Grades_Code_C.AutoSize = true;
            this.Label_Grades_Code_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Grades_Code_C.Location = new System.Drawing.Point(19, 59);
            this.Label_Grades_Code_C.Name = "Label_Grades_Code_C";
            this.Label_Grades_Code_C.Size = new System.Drawing.Size(111, 17);
            this.Label_Grades_Code_C.TabIndex = 1;
            this.Label_Grades_Code_C.Text = "Cod Disciplina";
            // 
            // Label_Grades_Code_S
            // 
            this.Label_Grades_Code_S.AutoSize = true;
            this.Label_Grades_Code_S.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Grades_Code_S.Location = new System.Drawing.Point(19, 24);
            this.Label_Grades_Code_S.Name = "Label_Grades_Code_S";
            this.Label_Grades_Code_S.Size = new System.Drawing.Size(92, 17);
            this.Label_Grades_Code_S.TabIndex = 0;
            this.Label_Grades_Code_S.Text = "Nr. Matricol";
            // 
            // Panel_Edit_Students
            // 
            this.Panel_Edit_Students.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Edit_Students.Controls.Add(this.Butt_Edit_Student_Abort);
            this.Panel_Edit_Students.Controls.Add(this.Butt_Edit_Student_Save);
            this.Panel_Edit_Students.Controls.Add(this.Text_Student_Surname);
            this.Panel_Edit_Students.Controls.Add(this.Text_Student_Name);
            this.Panel_Edit_Students.Controls.Add(this.Text_Student_Code);
            this.Panel_Edit_Students.Controls.Add(this.Label_Student_Surname);
            this.Panel_Edit_Students.Controls.Add(this.Label_Student_Name);
            this.Panel_Edit_Students.Controls.Add(this.Label_Student_Code);
            this.Panel_Edit_Students.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel_Edit_Students.Location = new System.Drawing.Point(0, 0);
            this.Panel_Edit_Students.Name = "Panel_Edit_Students";
            this.Panel_Edit_Students.Size = new System.Drawing.Size(305, 216);
            this.Panel_Edit_Students.TabIndex = 0;
            // 
            // Butt_Edit_Student_Abort
            // 
            this.Butt_Edit_Student_Abort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit_Student_Abort.Location = new System.Drawing.Point(184, 155);
            this.Butt_Edit_Student_Abort.Name = "Butt_Edit_Student_Abort";
            this.Butt_Edit_Student_Abort.Size = new System.Drawing.Size(87, 34);
            this.Butt_Edit_Student_Abort.TabIndex = 7;
            this.Butt_Edit_Student_Abort.Text = "Renunta";
            this.Butt_Edit_Student_Abort.UseVisualStyleBackColor = true;
            this.Butt_Edit_Student_Abort.Click += new System.EventHandler(this.Butt_Edit_Global_Abort_Click);
            // 
            // Butt_Edit_Student_Save
            // 
            this.Butt_Edit_Student_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit_Student_Save.Location = new System.Drawing.Point(30, 155);
            this.Butt_Edit_Student_Save.Name = "Butt_Edit_Student_Save";
            this.Butt_Edit_Student_Save.Size = new System.Drawing.Size(87, 34);
            this.Butt_Edit_Student_Save.TabIndex = 6;
            this.Butt_Edit_Student_Save.Text = "Salveaza";
            this.Butt_Edit_Student_Save.UseVisualStyleBackColor = true;
            this.Butt_Edit_Student_Save.Click += new System.EventHandler(this.Butt_Edit_Student_Save_Click);
            // 
            // Text_Student_Surname
            // 
            this.Text_Student_Surname.Location = new System.Drawing.Point(184, 93);
            this.Text_Student_Surname.Name = "Text_Student_Surname";
            this.Text_Student_Surname.Size = new System.Drawing.Size(100, 23);
            this.Text_Student_Surname.TabIndex = 5;
            // 
            // Text_Student_Name
            // 
            this.Text_Student_Name.Location = new System.Drawing.Point(184, 53);
            this.Text_Student_Name.Name = "Text_Student_Name";
            this.Text_Student_Name.Size = new System.Drawing.Size(100, 23);
            this.Text_Student_Name.TabIndex = 4;
            // 
            // Text_Student_Code
            // 
            this.Text_Student_Code.Location = new System.Drawing.Point(184, 18);
            this.Text_Student_Code.Name = "Text_Student_Code";
            this.Text_Student_Code.Size = new System.Drawing.Size(100, 23);
            this.Text_Student_Code.TabIndex = 3;
            // 
            // Label_Student_Surname
            // 
            this.Label_Student_Surname.AutoSize = true;
            this.Label_Student_Surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Student_Surname.Location = new System.Drawing.Point(19, 99);
            this.Label_Student_Surname.Name = "Label_Student_Surname";
            this.Label_Student_Surname.Size = new System.Drawing.Size(133, 17);
            this.Label_Student_Surname.TabIndex = 2;
            this.Label_Student_Surname.Text = "Prenume Student";
            // 
            // Label_Student_Name
            // 
            this.Label_Student_Name.AutoSize = true;
            this.Label_Student_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Student_Name.Location = new System.Drawing.Point(19, 59);
            this.Label_Student_Name.Name = "Label_Student_Name";
            this.Label_Student_Name.Size = new System.Drawing.Size(110, 17);
            this.Label_Student_Name.TabIndex = 1;
            this.Label_Student_Name.Text = "Nume Student";
            // 
            // Label_Student_Code
            // 
            this.Label_Student_Code.AutoSize = true;
            this.Label_Student_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Student_Code.Location = new System.Drawing.Point(19, 24);
            this.Label_Student_Code.Name = "Label_Student_Code";
            this.Label_Student_Code.Size = new System.Drawing.Size(92, 17);
            this.Label_Student_Code.TabIndex = 0;
            this.Label_Student_Code.Text = "Nr. Matricol";
            // 
            // Panel_Grades
            // 
            this.Panel_Grades.Controls.Add(this.Grid_Grades);
            this.Panel_Grades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Grades.Location = new System.Drawing.Point(117, 67);
            this.Panel_Grades.Name = "Panel_Grades";
            this.Panel_Grades.Padding = new System.Windows.Forms.Padding(3);
            this.Panel_Grades.Size = new System.Drawing.Size(684, 383);
            this.Panel_Grades.TabIndex = 2;
            // 
            // Grid_Grades
            // 
            this.Grid_Grades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Grades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Grades.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Grid_Grades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Grades.Location = new System.Drawing.Point(3, 3);
            this.Grid_Grades.MultiSelect = false;
            this.Grid_Grades.Name = "Grid_Grades";
            this.Grid_Grades.ReadOnly = true;
            this.Grid_Grades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Grades.Size = new System.Drawing.Size(678, 377);
            this.Grid_Grades.TabIndex = 0;
            this.Grid_Grades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Global_CellClick);
            // 
            // Panel_Main
            // 
            this.Panel_Main.Controls.Add(this.Panel_Grades);
            this.Panel_Main.Controls.Add(this.Panel_Courses);
            this.Panel_Main.Controls.Add(this.Panel_Students);
            this.Panel_Main.Controls.Add(this.Panel_Edits);
            this.Panel_Main.Controls.Add(this.Panel_Edit_Buttons);
            this.Panel_Main.Controls.Add(this.Panel_Grid_Buttons);
            this.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Main.Location = new System.Drawing.Point(0, 0);
            this.Panel_Main.Name = "Panel_Main";
            this.Panel_Main.Size = new System.Drawing.Size(801, 450);
            this.Panel_Main.TabIndex = 3;
            // 
            // Panel_Edit_Buttons
            // 
            this.Panel_Edit_Buttons.Controls.Add(this.Butt_Delete);
            this.Panel_Edit_Buttons.Controls.Add(this.Butt_Edit);
            this.Panel_Edit_Buttons.Controls.Add(this.Butt_Insert);
            this.Panel_Edit_Buttons.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel_Edit_Buttons.Location = new System.Drawing.Point(0, 67);
            this.Panel_Edit_Buttons.Name = "Panel_Edit_Buttons";
            this.Panel_Edit_Buttons.Padding = new System.Windows.Forms.Padding(3);
            this.Panel_Edit_Buttons.Size = new System.Drawing.Size(117, 383);
            this.Panel_Edit_Buttons.TabIndex = 8;
            // 
            // Butt_Delete
            // 
            this.Butt_Delete.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Butt_Delete.BackgroundImage")));
            this.Butt_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Butt_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Butt_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Butt_Delete.Location = new System.Drawing.Point(12, 274);
            this.Butt_Delete.Name = "Butt_Delete";
            this.Butt_Delete.Size = new System.Drawing.Size(90, 97);
            this.Butt_Delete.TabIndex = 6;
            this.Edit_Tips.SetToolTip(this.Butt_Delete, "Sterge o intrare din tabel.");
            this.Butt_Delete.UseVisualStyleBackColor = false;
            this.Butt_Delete.Click += new System.EventHandler(this.Butt_Delete_Click);
            // 
            // Butt_Edit
            // 
            this.Butt_Edit.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Butt_Edit.BackgroundImage")));
            this.Butt_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Butt_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Butt_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Butt_Edit.Location = new System.Drawing.Point(12, 142);
            this.Butt_Edit.Name = "Butt_Edit";
            this.Butt_Edit.Size = new System.Drawing.Size(90, 97);
            this.Butt_Edit.TabIndex = 5;
            this.Edit_Tips.SetToolTip(this.Butt_Edit, "Modifica o intrare din tabel.");
            this.Butt_Edit.UseVisualStyleBackColor = false;
            this.Butt_Edit.Click += new System.EventHandler(this.Butt_Edit_Click);
            // 
            // Butt_Insert
            // 
            this.Butt_Insert.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Insert.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Butt_Insert.BackgroundImage")));
            this.Butt_Insert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Butt_Insert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Insert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Butt_Insert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Butt_Insert.Location = new System.Drawing.Point(12, 21);
            this.Butt_Insert.Name = "Butt_Insert";
            this.Butt_Insert.Size = new System.Drawing.Size(90, 97);
            this.Butt_Insert.TabIndex = 4;
            this.Edit_Tips.SetToolTip(this.Butt_Insert, "Adauga o intrare noua in tabel.");
            this.Butt_Insert.UseVisualStyleBackColor = false;
            this.Butt_Insert.Click += new System.EventHandler(this.Butt_Insert_Click);
            // 
            // Panel_Grid_Buttons
            // 
            this.Panel_Grid_Buttons.Controls.Add(this.Butt_Report);
            this.Panel_Grid_Buttons.Controls.Add(this.Butt_Exit);
            this.Panel_Grid_Buttons.Controls.Add(this.Butt_Load_Data);
            this.Panel_Grid_Buttons.Controls.Add(this.Butt_Courses);
            this.Panel_Grid_Buttons.Controls.Add(this.Butt_Grades);
            this.Panel_Grid_Buttons.Controls.Add(this.Butt_Students);
            this.Panel_Grid_Buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Grid_Buttons.Location = new System.Drawing.Point(0, 0);
            this.Panel_Grid_Buttons.Name = "Panel_Grid_Buttons";
            this.Panel_Grid_Buttons.Padding = new System.Windows.Forms.Padding(3);
            this.Panel_Grid_Buttons.Size = new System.Drawing.Size(801, 67);
            this.Panel_Grid_Buttons.TabIndex = 7;
            // 
            // Butt_Report
            // 
            this.Butt_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Butt_Report.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Report.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Report.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_Report.Location = new System.Drawing.Point(429, 14);
            this.Butt_Report.Name = "Butt_Report";
            this.Butt_Report.Size = new System.Drawing.Size(116, 38);
            this.Butt_Report.TabIndex = 7;
            this.Butt_Report.Text = "Salveaza";
            this.Edit_Tips.SetToolTip(this.Butt_Report, "Creeaza un raport de tip csv si salveaza local datele.");
            this.Butt_Report.UseVisualStyleBackColor = false;
            this.Butt_Report.Click += new System.EventHandler(this.Butt_Report_Click);
            // 
            // Butt_Exit
            // 
            this.Butt_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Butt_Exit.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Butt_Exit.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_Exit.Location = new System.Drawing.Point(673, 14);
            this.Butt_Exit.Name = "Butt_Exit";
            this.Butt_Exit.Size = new System.Drawing.Size(116, 38);
            this.Butt_Exit.TabIndex = 5;
            this.Butt_Exit.Text = "Iesire";
            this.Edit_Tips.SetToolTip(this.Butt_Exit, "Iesire, face ce scrie.");
            this.Butt_Exit.UseVisualStyleBackColor = false;
            this.Butt_Exit.Click += new System.EventHandler(this.Butt_Exit_Click);
            // 
            // Butt_Load_Data
            // 
            this.Butt_Load_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Butt_Load_Data.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Load_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Load_Data.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_Load_Data.Location = new System.Drawing.Point(551, 14);
            this.Butt_Load_Data.Name = "Butt_Load_Data";
            this.Butt_Load_Data.Size = new System.Drawing.Size(116, 38);
            this.Butt_Load_Data.TabIndex = 6;
            this.Butt_Load_Data.Text = "Incarca";
            this.Edit_Tips.SetToolTip(this.Butt_Load_Data, "Incarca datele si afiseaza in interfata tabelele.");
            this.Butt_Load_Data.UseVisualStyleBackColor = false;
            this.Butt_Load_Data.Click += new System.EventHandler(this.Butt_Load_Data_Click);
            // 
            // Butt_Courses
            // 
            this.Butt_Courses.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Courses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Courses.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_Courses.Location = new System.Drawing.Point(134, 13);
            this.Butt_Courses.Name = "Butt_Courses";
            this.Butt_Courses.Size = new System.Drawing.Size(116, 38);
            this.Butt_Courses.TabIndex = 2;
            this.Butt_Courses.Text = "Materile";
            this.Edit_Tips.SetToolTip(this.Butt_Courses, "Schimba focus-ul pe tabelul de Materii.");
            this.Butt_Courses.UseVisualStyleBackColor = false;
            this.Butt_Courses.Click += new System.EventHandler(this.Butt_Courses_Click);
            // 
            // Butt_Grades
            // 
            this.Butt_Grades.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Grades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Grades.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_Grades.Location = new System.Drawing.Point(256, 14);
            this.Butt_Grades.Name = "Butt_Grades";
            this.Butt_Grades.Size = new System.Drawing.Size(116, 38);
            this.Butt_Grades.TabIndex = 3;
            this.Butt_Grades.Text = "Notele";
            this.Edit_Tips.SetToolTip(this.Butt_Grades, "Schimba focus-ul pe tabelul de Note.");
            this.Butt_Grades.UseVisualStyleBackColor = false;
            this.Butt_Grades.Click += new System.EventHandler(this.Butt_Grades_Click);
            // 
            // Butt_Students
            // 
            this.Butt_Students.BackColor = System.Drawing.Color.MintCream;
            this.Butt_Students.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Butt_Students.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Butt_Students.Location = new System.Drawing.Point(12, 12);
            this.Butt_Students.Name = "Butt_Students";
            this.Butt_Students.Size = new System.Drawing.Size(116, 40);
            this.Butt_Students.TabIndex = 1;
            this.Butt_Students.Text = "Studentii";
            this.Edit_Tips.SetToolTip(this.Butt_Students, "Schimba focus-ul pe tabelul de Studenti.");
            this.Butt_Students.UseVisualStyleBackColor = false;
            this.Butt_Students.Click += new System.EventHandler(this.Butt_Students_Click);
            // 
            // Edit_Tips
            // 
            this.Edit_Tips.Tag = "Edit_Tips_Tag";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.CancelButton = this.Butt_Exit;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.Panel_Main);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.Text = "Catalog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.Panel_Students.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Students)).EndInit();
            this.Panel_Courses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Courses)).EndInit();
            this.Panel_Edits.ResumeLayout(false);
            this.Panel_Edit_Courses.ResumeLayout(false);
            this.Panel_Edit_Courses.PerformLayout();
            this.Panel_Edit_Grades.ResumeLayout(false);
            this.Panel_Edit_Grades.PerformLayout();
            this.Panel_Edit_Students.ResumeLayout(false);
            this.Panel_Edit_Students.PerformLayout();
            this.Panel_Grades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Grades)).EndInit();
            this.Panel_Main.ResumeLayout(false);
            this.Panel_Edit_Buttons.ResumeLayout(false);
            this.Panel_Grid_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Generated Variable declaration
        private System.Windows.Forms.Panel Panel_Students;
        private System.Windows.Forms.DataGridView Grid_Students;
        private System.Windows.Forms.Panel Panel_Courses;
        private System.Windows.Forms.DataGridView Grid_Courses;
        private System.Windows.Forms.Panel Panel_Grades;
        private System.Windows.Forms.DataGridView Grid_Grades;
        private System.Windows.Forms.Panel Panel_Main;
        private System.Windows.Forms.Panel Panel_Edit_Buttons;
        private System.Windows.Forms.Button Butt_Delete;
        private System.Windows.Forms.Button Butt_Edit;
        private System.Windows.Forms.Button Butt_Insert;
        private System.Windows.Forms.Panel Panel_Grid_Buttons;
        private System.Windows.Forms.Button Butt_Exit;
        private System.Windows.Forms.Button Butt_Courses;
        private System.Windows.Forms.Button Butt_Grades;
        private System.Windows.Forms.Button Butt_Students;
        private System.Windows.Forms.Panel Panel_Edits;
        private System.Windows.Forms.Panel Panel_Edit_Students;
        private System.Windows.Forms.Label Label_Student_Code;
        private System.Windows.Forms.Button Butt_Edit_Student_Abort;
        private System.Windows.Forms.Button Butt_Edit_Student_Save;
        private System.Windows.Forms.TextBox Text_Student_Surname;
        private System.Windows.Forms.TextBox Text_Student_Name;
        private System.Windows.Forms.TextBox Text_Student_Code;
        private System.Windows.Forms.Label Label_Student_Surname;
        private System.Windows.Forms.Label Label_Student_Name;
        private System.Windows.Forms.Panel Panel_Edit_Courses;
        private System.Windows.Forms.Button Butt_Edit_Courses_Abort;
        private System.Windows.Forms.Button Butt_Edit_Courses_Save;
        private System.Windows.Forms.TextBox Text_Courses_Credits;
        private System.Windows.Forms.TextBox Text_Courses_Name;
        private System.Windows.Forms.TextBox Text_Courses_Code;
        private System.Windows.Forms.Label Label_Courses_Credits;
        private System.Windows.Forms.Label Label_Courses_Name;
        private System.Windows.Forms.Label Label_Courses_Code;
        private System.Windows.Forms.Panel Panel_Edit_Grades;
        private System.Windows.Forms.Button Butt_Edit_Grades_Abort;
        private System.Windows.Forms.Button Butt_Edit_Grades_Save;
        private System.Windows.Forms.TextBox Text_Grades_Grade;
        private System.Windows.Forms.TextBox Text_Grades_Code_C;
        private System.Windows.Forms.TextBox Text_Grades_Code_S;
        private System.Windows.Forms.Label Label_Grades_Grade;
        private System.Windows.Forms.Label Label_Grades_Code_C;
        private System.Windows.Forms.Label Label_Grades_Code_S;
        private System.Windows.Forms.Button Butt_Load_Data;
        private System.Windows.Forms.Button Butt_Report;
        private System.Windows.Forms.ToolTip Edit_Tips;
        #endregion

        #region Custom Variable declaration
        int mClicked_Row = -1;
        bool mLoaded = false;
        int mEditing = 0;  // 0 - Not editing; 1 - Inserting data; 2 - Updating data
        #endregion

    }
}

