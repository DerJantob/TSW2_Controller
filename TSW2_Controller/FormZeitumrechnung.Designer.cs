namespace TSW2_Controller
{
    partial class FormZeitumrechnung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormZeitumrechnung));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radio_Stufenlos = new System.Windows.Forms.RadioButton();
            this.radio_Stufen = new System.Windows.Forms.RadioButton();
            this.txt_Startwert = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radio_Schub = new System.Windows.Forms.RadioButton();
            this.radio_Bremse = new System.Windows.Forms.RadioButton();
            this.radio_kombihebel = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zeitumrechnungswert finden";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 208);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // radio_Stufenlos
            // 
            this.radio_Stufenlos.AutoSize = true;
            this.radio_Stufenlos.Checked = true;
            this.radio_Stufenlos.Location = new System.Drawing.Point(3, 3);
            this.radio_Stufenlos.Name = "radio_Stufenlos";
            this.radio_Stufenlos.Size = new System.Drawing.Size(69, 17);
            this.radio_Stufenlos.TabIndex = 3;
            this.radio_Stufenlos.TabStop = true;
            this.radio_Stufenlos.Text = "Stufenlos";
            this.radio_Stufenlos.UseVisualStyleBackColor = true;
            // 
            // radio_Stufen
            // 
            this.radio_Stufen.AutoSize = true;
            this.radio_Stufen.Location = new System.Drawing.Point(3, 26);
            this.radio_Stufen.Name = "radio_Stufen";
            this.radio_Stufen.Size = new System.Drawing.Size(56, 17);
            this.radio_Stufen.TabIndex = 4;
            this.radio_Stufen.Text = "Stufen";
            this.radio_Stufen.UseVisualStyleBackColor = true;
            // 
            // txt_Startwert
            // 
            this.txt_Startwert.Location = new System.Drawing.Point(17, 380);
            this.txt_Startwert.Name = "txt_Startwert";
            this.txt_Startwert.Size = new System.Drawing.Size(100, 20);
            this.txt_Startwert.TabIndex = 5;
            this.txt_Startwert.TextChanged += new System.EventHandler(this.txt_Startwert_TextChanged);
            this.txt_Startwert.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Startwert_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Startwert in %";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(123, 380);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(41, 20);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "Start";
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
            this.panel1.Controls.Add(this.radio_kombihebel);
            this.panel1.Controls.Add(this.radio_Stufenlos);
            this.panel1.Controls.Add(this.radio_Stufen);
            this.panel1.Location = new System.Drawing.Point(17, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 73);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radio_Schub);
            this.panel2.Controls.Add(this.radio_Bremse);
            this.panel2.Location = new System.Drawing.Point(109, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(74, 50);
            this.panel2.TabIndex = 10;
            // 
            // radio_Schub
            // 
            this.radio_Schub.AutoSize = true;
            this.radio_Schub.Checked = true;
            this.radio_Schub.Location = new System.Drawing.Point(3, 3);
            this.radio_Schub.Name = "radio_Schub";
            this.radio_Schub.Size = new System.Drawing.Size(56, 17);
            this.radio_Schub.TabIndex = 3;
            this.radio_Schub.TabStop = true;
            this.radio_Schub.Text = "Schub";
            this.radio_Schub.UseVisualStyleBackColor = true;
            // 
            // radio_Bremse
            // 
            this.radio_Bremse.AutoSize = true;
            this.radio_Bremse.Location = new System.Drawing.Point(3, 26);
            this.radio_Bremse.Name = "radio_Bremse";
            this.radio_Bremse.Size = new System.Drawing.Size(60, 17);
            this.radio_Bremse.TabIndex = 4;
            this.radio_Bremse.Text = "Bremse";
            this.radio_Bremse.UseVisualStyleBackColor = true;
            // 
            // radio_kombihebel
            // 
            this.radio_kombihebel.AutoSize = true;
            this.radio_kombihebel.Location = new System.Drawing.Point(3, 49);
            this.radio_kombihebel.Name = "radio_kombihebel";
            this.radio_kombihebel.Size = new System.Drawing.Size(80, 17);
            this.radio_kombihebel.TabIndex = 5;
            this.radio_kombihebel.Text = "Kombihebel";
            this.radio_kombihebel.UseVisualStyleBackColor = true;
            this.radio_kombihebel.CheckedChanged += new System.EventHandler(this.radio_kombihebel_CheckedChanged);
            // 
            // FormZeitumrechnung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 412);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Startwert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormZeitumrechnung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormZeitumrechnung";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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