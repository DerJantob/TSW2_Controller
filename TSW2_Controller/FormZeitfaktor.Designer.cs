namespace TSW2_Controller
{
    partial class FormZeitfaktor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormZeitfaktor));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_anleitung = new System.Windows.Forms.Label();
            this.radio_Stufenlos = new System.Windows.Forms.RadioButton();
            this.radio_Stufen = new System.Windows.Forms.RadioButton();
            this.txt_Startwert = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.radio_kombihebel = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radio_Schub = new System.Windows.Forms.RadioButton();
            this.radio_Bremse = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbl_anleitung
            // 
            resources.ApplyResources(this.lbl_anleitung, "lbl_anleitung");
            this.lbl_anleitung.Name = "lbl_anleitung";
            // 
            // radio_Stufenlos
            // 
            resources.ApplyResources(this.radio_Stufenlos, "radio_Stufenlos");
            this.radio_Stufenlos.Checked = true;
            this.radio_Stufenlos.Name = "radio_Stufenlos";
            this.radio_Stufenlos.TabStop = true;
            this.radio_Stufenlos.UseVisualStyleBackColor = true;
            this.radio_Stufenlos.CheckedChanged += new System.EventHandler(this.radio_Stufenlos_CheckedChanged);
            // 
            // radio_Stufen
            // 
            resources.ApplyResources(this.radio_Stufen, "radio_Stufen");
            this.radio_Stufen.Name = "radio_Stufen";
            this.radio_Stufen.UseVisualStyleBackColor = true;
            this.radio_Stufen.CheckedChanged += new System.EventHandler(this.radio_Stufen_CheckedChanged);
            // 
            // txt_Startwert
            // 
            resources.ApplyResources(this.txt_Startwert, "txt_Startwert");
            this.txt_Startwert.Name = "txt_Startwert";
            this.txt_Startwert.TextChanged += new System.EventHandler(this.txt_Startwert_TextChanged);
            this.txt_Startwert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Startwert_KeyPress);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.radio_kombihebel);
            this.panel1.Controls.Add(this.radio_Stufenlos);
            this.panel1.Controls.Add(this.radio_Stufen);
            this.panel1.Name = "panel1";
            // 
            // radio_kombihebel
            // 
            resources.ApplyResources(this.radio_kombihebel, "radio_kombihebel");
            this.radio_kombihebel.Name = "radio_kombihebel";
            this.radio_kombihebel.UseVisualStyleBackColor = true;
            this.radio_kombihebel.CheckedChanged += new System.EventHandler(this.radio_kombihebel_CheckedChanged);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.radio_Schub);
            this.panel2.Controls.Add(this.radio_Bremse);
            this.panel2.Name = "panel2";
            // 
            // radio_Schub
            // 
            resources.ApplyResources(this.radio_Schub, "radio_Schub");
            this.radio_Schub.Checked = true;
            this.radio_Schub.Name = "radio_Schub";
            this.radio_Schub.TabStop = true;
            this.radio_Schub.UseVisualStyleBackColor = true;
            // 
            // radio_Bremse
            // 
            resources.ApplyResources(this.radio_Bremse, "radio_Bremse");
            this.radio_Bremse.Name = "radio_Bremse";
            this.radio_Bremse.UseVisualStyleBackColor = true;
            // 
            // FormZeitfaktor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Startwert);
            this.Controls.Add(this.lbl_anleitung);
            this.Controls.Add(this.label1);
            this.Name = "FormZeitfaktor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_anleitung;
        private System.Windows.Forms.RadioButton radio_Stufenlos;
        private System.Windows.Forms.RadioButton radio_Stufen;
        private System.Windows.Forms.TextBox txt_Startwert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radio_Schub;
        private System.Windows.Forms.RadioButton radio_Bremse;
        private System.Windows.Forms.RadioButton radio_kombihebel;
    }
}