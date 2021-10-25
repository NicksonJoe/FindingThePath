
namespace BRIO_MRS_testTask.Controls
{
    partial class SaveAs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAs));
            this.InputSaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputSaveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputSaveBtn
            // 
            this.InputSaveBtn.Location = new System.Drawing.Point(369, 16);
            this.InputSaveBtn.Name = "InputSaveBtn";
            this.InputSaveBtn.Size = new System.Drawing.Size(106, 58);
            this.InputSaveBtn.TabIndex = 0;
            this.InputSaveBtn.Text = "Input.txt";
            this.InputSaveBtn.UseVisualStyleBackColor = true;
            this.InputSaveBtn.Click += new System.EventHandler(this.InputSaveBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 58);
            this.label1.TabIndex = 2;
            this.label1.Text = "x1,y1,x2,y2,x3,y3 \t\t: координаты статичных приемников\r\ndt1,dt2,dt3\t\t\t: время прох" +
    "ождения сигнала до трех точек, 1 измерение\r\n…\r\nd1,d2,d3\t\t\t: время прохождения си" +
    "гнала до трех точек, n измерение\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.InputSaveBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.OutputSaveBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 58);
            this.label3.TabIndex = 2;
            this.label3.Text = "x,y\t\t\t\t: точка начала движения\r\n...\r\nx,y\t\t\t\t: точка окончания движения\r\n\r\n";
            // 
            // OutputSaveBtn
            // 
            this.OutputSaveBtn.Location = new System.Drawing.Point(369, 16);
            this.OutputSaveBtn.Name = "OutputSaveBtn";
            this.OutputSaveBtn.Size = new System.Drawing.Size(106, 58);
            this.OutputSaveBtn.TabIndex = 0;
            this.OutputSaveBtn.Text = "Output.txt";
            this.OutputSaveBtn.UseVisualStyleBackColor = true;
            this.OutputSaveBtn.Click += new System.EventHandler(this.OutputSaveBtn_Click);
            // 
            // SaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 191);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveAs";
            this.Text = "SaveAs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InputSaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OutputSaveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}