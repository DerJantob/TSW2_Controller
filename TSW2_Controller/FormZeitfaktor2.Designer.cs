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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormZeitfaktor2));
            this.lbl_anleitung = new System.Windows.Forms.Label();
            this.btn_weiter = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_ERROR = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_anleitung
            // 
            resources.ApplyResources(this.lbl_anleitung, "lbl_anleitung");
            this.lbl_anleitung.Name = "lbl_anleitung";
            // 
            // btn_weiter
            // 
            resources.ApplyResources(this.btn_weiter, "btn_weiter");
            this.btn_weiter.Name = "btn_weiter";
            this.btn_weiter.UseVisualStyleBackColor = true;
            this.btn_weiter.Click += new System.EventHandler(this.btn_weiter_Click);
            // 
            // btn_start
            // 
            resources.ApplyResources(this.btn_start, "btn_start");
            this.btn_start.Name = "btn_start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_ERROR
            // 
            resources.ApplyResources(this.lbl_ERROR, "lbl_ERROR");
            this.lbl_ERROR.Name = "lbl_ERROR";
            // 
            // FormZeitfaktor2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_ERROR);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_weiter);
            this.Controls.Add(this.lbl_anleitung);
            this.Name = "FormZeitfaktor2";
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