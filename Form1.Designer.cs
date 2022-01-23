
namespace HC2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaStructuri = new System.Windows.Forms.ComboBox();
            this.straturiSelectate = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // listaStructuri
            // 
            this.listaStructuri.FormattingEnabled = true;
            this.listaStructuri.Location = new System.Drawing.Point(306, 52);
            this.listaStructuri.Name = "listaStructuri";
            this.listaStructuri.Size = new System.Drawing.Size(121, 21);
            this.listaStructuri.TabIndex = 2;
            this.listaStructuri.Text = "Selectati un strat";
            // 
            // straturiSelectate
            // 
            this.straturiSelectate.FormattingEnabled = true;
            this.straturiSelectate.Location = new System.Drawing.Point(30, 52);
            this.straturiSelectate.Name = "straturiSelectate";
            this.straturiSelectate.Size = new System.Drawing.Size(209, 342);
            this.straturiSelectate.TabIndex = 3;
            this.straturiSelectate.DoubleClick += new System.EventHandler(this.straturiSelectate_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Adauga Strat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(289, 114);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1050, 522);
            this.formsPlot1.TabIndex = 5;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 699);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.straturiSelectate);
            this.Controls.Add(this.listaStructuri);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox listaStructuri;
        private System.Windows.Forms.ListBox straturiSelectate;
        private System.Windows.Forms.Button button1;
        private ScottPlot.FormsPlot formsPlot1;
    }
}

