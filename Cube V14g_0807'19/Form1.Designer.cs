namespace Cube_V11
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bodyParametrsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixConstructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ромбоподобныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pythomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bodyParametrsToolStripMenuItem,
            this.methodsToolStripMenuItem,
            this.pythomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bodyParametrsToolStripMenuItem
            // 
            this.bodyParametrsToolStripMenuItem.Name = "bodyParametrsToolStripMenuItem";
            this.bodyParametrsToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.bodyParametrsToolStripMenuItem.Text = "Настройки тела";
            this.bodyParametrsToolStripMenuItem.Click += new System.EventHandler(this.bodyParametrsToolStripMenuItem_Click);
            // 
            // methodsToolStripMenuItem
            // 
            this.methodsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matrixConstructionToolStripMenuItem,
            this.newToolStripMenuItem,
            this.nугольникToolStripMenuItem,
            this.ромбоподобныйToolStripMenuItem});
            this.methodsToolStripMenuItem.Name = "methodsToolStripMenuItem";
            this.methodsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.methodsToolStripMenuItem.Text = "Методы";
            // 
            // matrixConstructionToolStripMenuItem
            // 
            this.matrixConstructionToolStripMenuItem.Name = "matrixConstructionToolStripMenuItem";
            this.matrixConstructionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.matrixConstructionToolStripMenuItem.Text = "Прямоугольники";
            this.matrixConstructionToolStripMenuItem.Click += new System.EventHandler(this.matrixConstructionToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.newToolStripMenuItem.Text = "N-угольник";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // nугольникToolStripMenuItem
            // 
            this.nугольникToolStripMenuItem.Name = "nугольникToolStripMenuItem";
            this.nугольникToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nугольникToolStripMenuItem.Text = "N-угольник+";
            this.nугольникToolStripMenuItem.Click += new System.EventHandler(this.nугольникToolStripMenuItem_Click);
            // 
            // ромбоподобныйToolStripMenuItem
            // 
            this.ромбоподобныйToolStripMenuItem.Name = "ромбоподобныйToolStripMenuItem";
            this.ромбоподобныйToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ромбоподобныйToolStripMenuItem.Text = "Ромбоподобный";
            this.ромбоподобныйToolStripMenuItem.Click += new System.EventHandler(this.ромбоподобныйToolStripMenuItem_Click);
            // 
            // pythomToolStripMenuItem
            // 
            this.pythomToolStripMenuItem.Name = "pythomToolStripMenuItem";
            this.pythomToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.pythomToolStripMenuItem.Text = "N-угольник+ p";
            this.pythomToolStripMenuItem.Click += new System.EventHandler(this.pythomToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 524);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Cube";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bodyParametrsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixConstructionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ромбоподобныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pythomToolStripMenuItem;
    }
}

