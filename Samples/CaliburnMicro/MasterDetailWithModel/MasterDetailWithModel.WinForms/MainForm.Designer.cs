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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openStudentList1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openStudentList2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.closeStudentList = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.studentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.closeStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStudentList1,
            this.openStudentList2,
            this.fileMenuSeparator,
            this.closeStudentList,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openStudentList1
            // 
            this.openStudentList1.Name = "openStudentList1";
            this.openStudentList1.Size = new System.Drawing.Size(226, 22);
            this.openStudentList1.Text = "Open student list (method 1)";
            // 
            // openStudentList2
            // 
            this.openStudentList2.Name = "openStudentList2";
            this.openStudentList2.Size = new System.Drawing.Size(226, 22);
            this.openStudentList2.Text = "Open student list (method 2)";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(223, 6);
            // 
            // closeStudentList
            // 
            this.closeStudentList.Name = "closeStudentList";
            this.closeStudentList.Size = new System.Drawing.Size(226, 22);
            this.closeStudentList.Text = "Close student list";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(226, 22);
            this.exit.Text = "Exit";
            // 
            // studentMenu
            // 
            this.studentMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createStudent,
            this.saveStudent,
            this.deleteStudent,
            this.closeStudent});
            this.studentMenu.Name = "studentMenu";
            this.studentMenu.Size = new System.Drawing.Size(60, 20);
            this.studentMenu.Text = "Student";
            // 
            // createStudent
            // 
            this.createStudent.Name = "createStudent";
            this.createStudent.Size = new System.Drawing.Size(175, 22);
            this.createStudent.Text = "New student";
            // 
            // saveStudent
            // 
            this.saveStudent.Name = "saveStudent";
            this.saveStudent.Size = new System.Drawing.Size(175, 22);
            this.saveStudent.Text = "Save student";
            // 
            // deleteStudent
            // 
            this.deleteStudent.Name = "deleteStudent";
            this.deleteStudent.Size = new System.Drawing.Size(175, 22);
            this.deleteStudent.Text = "Delete student";
            // 
            // closeStudent
            // 
            this.closeStudent.Name = "closeStudent";
            this.closeStudent.Size = new System.Drawing.Size(175, 22);
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
            this.activeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1348, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openStudentList1;
        private System.Windows.Forms.ToolStripMenuItem openStudentList2;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem closeStudentList;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem studentMenu;
        private System.Windows.Forms.ToolStripMenuItem createStudent;
        private System.Windows.Forms.ToolStripMenuItem saveStudent;
        private System.Windows.Forms.ToolStripMenuItem deleteStudent;
        private System.Windows.Forms.ToolStripMenuItem closeStudent;
        private System.Windows.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

