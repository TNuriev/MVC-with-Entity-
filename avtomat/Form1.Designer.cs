namespace avtomat
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
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.группуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свойствоToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxRedactionProperty = new System.Windows.Forms.GroupBox();
            this.asd = new System.Windows.Forms.Label();
            this.RedactionPropertyValue = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.IdRedactionProperty = new System.Windows.Forms.TextBox();
            this.NameRedactionProperty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxRedactionGroup = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SaveRedactionGroup = new System.Windows.Forms.Button();
            this.IdRedactionGroup = new System.Windows.Forms.TextBox();
            this.NameRedactionGroup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBoxRedactionProperty.SuspendLayout();
            this.groupBoxRedactionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.группуToolStripMenuItem,
            this.свойствоToolStripMenuItem1});
            this.добавитьToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // группуToolStripMenuItem
            // 
            this.группуToolStripMenuItem.Name = "группуToolStripMenuItem";
            this.группуToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.группуToolStripMenuItem.Text = "Группу";
            this.группуToolStripMenuItem.Click += new System.EventHandler(this.группуToolStripMenuItem_Click);
            // 
            // свойствоToolStripMenuItem1
            // 
            this.свойствоToolStripMenuItem1.Name = "свойствоToolStripMenuItem1";
            this.свойствоToolStripMenuItem1.Size = new System.Drawing.Size(157, 26);
            this.свойствоToolStripMenuItem1.Text = "Свойство";
            this.свойствоToolStripMenuItem1.Click += new System.EventHandler(this.свойствоToolStripMenuItem1_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.редактироватьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // groupBoxRedactionProperty
            // 
            this.groupBoxRedactionProperty.Controls.Add(this.asd);
            this.groupBoxRedactionProperty.Controls.Add(this.RedactionPropertyValue);
            this.groupBoxRedactionProperty.Controls.Add(this.button3);
            this.groupBoxRedactionProperty.Controls.Add(this.button4);
            this.groupBoxRedactionProperty.Controls.Add(this.IdRedactionProperty);
            this.groupBoxRedactionProperty.Controls.Add(this.NameRedactionProperty);
            this.groupBoxRedactionProperty.Controls.Add(this.label3);
            this.groupBoxRedactionProperty.Controls.Add(this.label4);
            this.groupBoxRedactionProperty.Enabled = false;
            this.groupBoxRedactionProperty.Location = new System.Drawing.Point(226, 227);
            this.groupBoxRedactionProperty.Name = "groupBoxRedactionProperty";
            this.groupBoxRedactionProperty.Size = new System.Drawing.Size(545, 195);
            this.groupBoxRedactionProperty.TabIndex = 9;
            this.groupBoxRedactionProperty.TabStop = false;
            this.groupBoxRedactionProperty.Text = "Форма редактирования свойства";
            // 
            // asd
            // 
            this.asd.AutoSize = true;
            this.asd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.asd.Location = new System.Drawing.Point(16, 81);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(72, 16);
            this.asd.TabIndex = 7;
            this.asd.Text = "Значение";
            // 
            // RedactionPropertyValue
            // 
            this.RedactionPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RedactionPropertyValue.Location = new System.Drawing.Point(142, 75);
            this.RedactionPropertyValue.Name = "RedactionPropertyValue";
            this.RedactionPropertyValue.Size = new System.Drawing.Size(397, 22);
            this.RedactionPropertyValue.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(415, 154);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(303, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "Сохранить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // IdRedactionProperty
            // 
            this.IdRedactionProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdRedactionProperty.Location = new System.Drawing.Point(142, 114);
            this.IdRedactionProperty.Name = "IdRedactionProperty";
            this.IdRedactionProperty.Size = new System.Drawing.Size(397, 22);
            this.IdRedactionProperty.TabIndex = 3;
            // 
            // NameRedactionProperty
            // 
            this.NameRedactionProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameRedactionProperty.Location = new System.Drawing.Point(142, 36);
            this.NameRedactionProperty.Name = "NameRedactionProperty";
            this.NameRedactionProperty.Size = new System.Drawing.Size(397, 22);
            this.NameRedactionProperty.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(16, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Наименование";
            // 
            // groupBoxRedactionGroup
            // 
            this.groupBoxRedactionGroup.Controls.Add(this.button2);
            this.groupBoxRedactionGroup.Controls.Add(this.SaveRedactionGroup);
            this.groupBoxRedactionGroup.Controls.Add(this.IdRedactionGroup);
            this.groupBoxRedactionGroup.Controls.Add(this.NameRedactionGroup);
            this.groupBoxRedactionGroup.Controls.Add(this.label2);
            this.groupBoxRedactionGroup.Controls.Add(this.label1);
            this.groupBoxRedactionGroup.Enabled = false;
            this.groupBoxRedactionGroup.Location = new System.Drawing.Point(226, 47);
            this.groupBoxRedactionGroup.Name = "groupBoxRedactionGroup";
            this.groupBoxRedactionGroup.Size = new System.Drawing.Size(545, 146);
            this.groupBoxRedactionGroup.TabIndex = 8;
            this.groupBoxRedactionGroup.TabStop = false;
            this.groupBoxRedactionGroup.Text = "Форма редактирования группы";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(415, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SaveRedactionGroup
            // 
            this.SaveRedactionGroup.AutoSize = true;
            this.SaveRedactionGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveRedactionGroup.Location = new System.Drawing.Point(303, 110);
            this.SaveRedactionGroup.Name = "SaveRedactionGroup";
            this.SaveRedactionGroup.Size = new System.Drawing.Size(86, 26);
            this.SaveRedactionGroup.TabIndex = 4;
            this.SaveRedactionGroup.Text = "Сохранить";
            this.SaveRedactionGroup.UseVisualStyleBackColor = true;
            this.SaveRedactionGroup.Click += new System.EventHandler(this.SaveRedactionGroup_Click_1);
            // 
            // IdRedactionGroup
            // 
            this.IdRedactionGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdRedactionGroup.Location = new System.Drawing.Point(142, 82);
            this.IdRedactionGroup.Name = "IdRedactionGroup";
            this.IdRedactionGroup.Size = new System.Drawing.Size(397, 22);
            this.IdRedactionGroup.TabIndex = 3;
            // 
            // NameRedactionGroup
            // 
            this.NameRedactionGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameRedactionGroup.Location = new System.Drawing.Point(142, 36);
            this.NameRedactionGroup.Name = "NameRedactionGroup";
            this.NameRedactionGroup.Size = new System.Drawing.Size(397, 22);
            this.NameRedactionGroup.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(29, 29);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(173, 393);
            this.treeView2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxRedactionProperty);
            this.Controls.Add(this.groupBoxRedactionGroup);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxRedactionProperty.ResumeLayout(false);
            this.groupBoxRedactionProperty.PerformLayout();
            this.groupBoxRedactionGroup.ResumeLayout(false);
            this.groupBoxRedactionGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBoxRedactionProperty;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox IdRedactionProperty;
        private System.Windows.Forms.TextBox NameRedactionProperty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxRedactionGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SaveRedactionGroup;
        private System.Windows.Forms.TextBox IdRedactionGroup;
        private System.Windows.Forms.TextBox NameRedactionGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem группуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свойствоToolStripMenuItem1;
        private System.Windows.Forms.Label asd;
        private System.Windows.Forms.TextBox RedactionPropertyValue;
    }
}

