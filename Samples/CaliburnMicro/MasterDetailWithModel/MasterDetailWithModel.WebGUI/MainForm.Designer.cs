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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new Gizmox.WebGUI.Forms.MenuStrip();
            this.fileMenu = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.openStudentList1 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.openStudentList2 = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new Gizmox.WebGUI.Forms.ToolStripSeparator();
            this.closeStudentList = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.exit = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.studentMenu = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.createNewStudent = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.saveStudent = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.deleteStudent = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.closeStudent = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.statusBar = new Gizmox.WebGUI.Forms.StatusStrip();
            this.activeItem = new MvvmFx.CaliburnMicro.ContentContainer();
            //this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.DockPadding.Bottom = 2;
            this.mainMenu.DockPadding.Left = 6;
            this.mainMenu.DockPadding.Top = 2;
            this.mainMenu.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.mainMenu.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
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
            this.fileMenu.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.openStudentList1,
            this.openStudentList2,
            this.fileMenuSeparator,
            this.closeStudentList,
            this.exit});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // openStudentList1
            // 
            this.openStudentList1.Name = "openStudentList1";
            this.openStudentList1.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.openStudentList1.Size = new System.Drawing.Size(226, 22);
            this.openStudentList1.Text = "Open student list (method 1)";
            // 
            // openStudentList2
            // 
            this.openStudentList2.Name = "openStudentList2";
            this.openStudentList2.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.openStudentList2.Size = new System.Drawing.Size(226, 22);
            this.openStudentList2.Text = "Open student list (method 2)";
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(161, 6);
            // 
            // closeStudentList
            // 
            this.closeStudentList.Name = "closeStudentList";
            this.closeStudentList.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.closeStudentList.Size = new System.Drawing.Size(226, 22);
            this.closeStudentList.Text = "Close student list";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.exit.Size = new System.Drawing.Size(226, 22);
            this.exit.Text = "Exit";
            // 
            // studentMenu
            // 
            this.studentMenu.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.createNewStudent,
            this.saveStudent,
            this.deleteStudent,
            this.closeStudent});
            this.studentMenu.Name = "studentMenu";
            this.studentMenu.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.studentMenu.Size = new System.Drawing.Size(60, 20);
            this.studentMenu.Text = "Student";
            // 
            // createNewStudent
            // 
            this.createNewStudent.Name = "createNewStudent";
            this.createNewStudent.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.createNewStudent.Size = new System.Drawing.Size(175, 22);
            this.createNewStudent.Text = "New student";
            // 
            // saveStudent
            // 
            this.saveStudent.Name = "saveStudent";
            this.saveStudent.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.saveStudent.Size = new System.Drawing.Size(175, 22);
            this.saveStudent.Text = "Save student";
            // 
            // deleteStudent
            // 
            this.deleteStudent.Name = "deleteStudent";
            this.deleteStudent.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.deleteStudent.Size = new System.Drawing.Size(175, 22);
            this.deleteStudent.Text = "Delete student";
            // 
            // closeStudent
            // 
            this.closeStudent.Name = "closeStudent";
            this.closeStudent.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.closeStudent.Size = new System.Drawing.Size(175, 22);
            this.closeStudent.Text = "Close student form";
            // 
            // statusBar
            // 
            this.statusBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.statusBar.DockPadding.Left = 1;
            this.statusBar.DockPadding.Right = 14;
            this.statusBar.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.statusBar.Location = new System.Drawing.Point(0, 678);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1348, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // activeItem
            // 
            this.activeItem.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.activeItem.Location = new System.Drawing.Point(0, 24);
            this.activeItem.Name = "activeItem";
            this.activeItem.Size = new System.Drawing.Size(1348, 654);
            this.activeItem.TabIndex = 2;
            // 
            // MainForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(1348, 700);
            this.Controls.Add(this.activeItem);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            //this.Name = "MainForm";
            this.Size = new System.Drawing.Size(1348, 700);
            this.Text = "MainForm";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.MenuStrip mainMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem fileMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem openStudentList1;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem openStudentList2;
        private Gizmox.WebGUI.Forms.ToolStripSeparator fileMenuSeparator;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem closeStudentList;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem exit;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem studentMenu;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem createNewStudent;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem saveStudent;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem deleteStudent;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem closeStudent;
        private Gizmox.WebGUI.Forms.StatusStrip statusBar;
        private MvvmFx.CaliburnMicro.ContentContainer activeItem;
    }
}

