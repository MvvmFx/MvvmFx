namespace MasterDetailWithModel
{
    partial class MainForm
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
            this.mainMenu = new Wisej.Web.MenuBar();
            this.fileMenu = new Wisej.Web.MenuItem();
            this.openStudentList1 = new Wisej.Web.MenuItem();
            this.openStudentList2 = new Wisej.Web.MenuItem();
            this.fileMenuSeparator = new Wisej.Web.MenuItem();
            this.closeStudentList = new Wisej.Web.MenuItem();
            this.exit = new Wisej.Web.MenuItem();
            this.studentMenu = new Wisej.Web.MenuItem();
            this.createNewStudent = new Wisej.Web.MenuItem();
            this.saveStudent = new Wisej.Web.MenuItem();
            this.deleteStudent = new Wisej.Web.MenuItem();
            this.closeStudent = new Wisej.Web.MenuItem();
            this.statusBar = new Wisej.Web.StatusBar();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.fileMenu,
            this.studentMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1348, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileMenu
            // 
            this.fileMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.openStudentList1,
            this.openStudentList2,
            this.fileMenuSeparator,
            this.closeStudentList,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Text = "File";
            // 
            // openStudentList1
            // 
            this.openStudentList1.Name = "openStudentList1";
            this.openStudentList1.Text = "Open student list (method 1)";
            // 
            // openStudentList2
            // 
            this.openStudentList2.Name = "openStudentList2";
            this.openStudentList2.Text = "Open student list (method 2)";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            // 
            // closeStudentList
            // 
            this.closeStudentList.Name = "closeStudentList";
            this.closeStudentList.Text = "Close student list";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            // 
            // studentMenu
            // 
            this.studentMenu.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.createNewStudent,
            this.saveStudent,
            this.deleteStudent,
            this.closeStudent});
            this.studentMenu.Name = "studentMenu";
            this.studentMenu.Text = "Student";
            // 
            // createNewStudent
            // 
            this.createNewStudent.Name = "createNewStudent";
            this.createNewStudent.Text = "New student";
            // 
            // saveStudent
            // 
            this.saveStudent.Name = "saveStudent";
            this.saveStudent.Text = "Save student";
            // 
            // deleteStudent
            // 
            this.deleteStudent.Name = "deleteStudent";
            this.deleteStudent.Text = "Delete student";
            // 
            // closeStudent
            // 
            this.closeStudent.Name = "closeStudent";
            this.closeStudent.Text = "Close student form";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 678);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1348, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Wisej.Web.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1348, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.MenuBar mainMenu;
        private Wisej.Web.MenuItem fileMenu;
        private Wisej.Web.MenuItem openStudentList1;
        private Wisej.Web.MenuItem openStudentList2;
        private Wisej.Web.MenuItem fileMenuSeparator;
        private Wisej.Web.MenuItem closeStudentList;
        private Wisej.Web.MenuItem exit;
        private Wisej.Web.MenuItem studentMenu;
        private Wisej.Web.MenuItem createNewStudent;
        private Wisej.Web.MenuItem saveStudent;
        private Wisej.Web.MenuItem deleteStudent;
        private Wisej.Web.MenuItem closeStudent;
        private Wisej.Web.StatusBar statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

