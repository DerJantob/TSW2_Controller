namespace TSW2_Controller
{
    partial class FormZeitfaktor2
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
            this.lbl_anleitung = new System.Windows.Forms.Label();
            this.btn_weiter = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_ERROR = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_anleitung
            // 
            this.lbl_anleitung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lbl_anleitung.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_anleitung.Location = new System.Drawing.Point(12, 9);
            this.lbl_anleitung.Name = "lbl_anleitung";
            this.lbl_anleitung.Size = new System.Drawing.Size(370, 230);
            this.lbl_anleitung.TabIndex = 3;
            this.lbl_anleitung.Text = "-Text-";
            // 
            // btn_weiter
            // 
            this.btn_weiter.Location = new System.Drawing.Point(15, 242);
            this.btn_weiter.Name = "btn_weiter";
            this.btn_weiter.Size = new System.Drawing.Size(105, 23);
            this.btn_weiter.TabIndex = 4;
            this.btn_weiter.Text = "Weiter";
            this.btn_weiter.UseVisualStyleBackColor = true;
            this.btn_weiter.Click += new System.EventHandler(this.btn_weiter_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(15, 271);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(105, 23);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Visible = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_ERROR
            // 
            this.lbl_ERROR.AutoSize = true;
            this.lbl_ERROR.Location = new System.Drawing.Point(126, 276);
            this.lbl_ERROR.Name = "lbl_ERROR";
            this.lbl_ERROR.Size = new System.Drawing.Size(46, 13);
            this.lbl_ERROR.TabIndex = 6;
            this.lbl_ERROR.Text = "ERROR";
            // 
            // FormZeitfaktor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 398);
            this.Controls.Add(this.lbl_ERROR);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_weiter);
            this.Controls.Add(this.lbl_anleitung);
            this.Name = "FormZeitfaktor2";
            this.Text = "FormZeitfaktor2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_anleitung;
        private System.Windows.Forms.Button btn_weiter;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_ERROR;
    }
}