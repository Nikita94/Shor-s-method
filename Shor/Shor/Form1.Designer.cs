namespace Shor
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pic = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_M2 = new System.Windows.Forms.Label();
            this.label_M1 = new System.Windows.Forms.Label();
            this.label_N = new System.Windows.Forms.Label();
            this.xmin_t = new System.Windows.Forms.TextBox();
            this.xmax_t = new System.Windows.Forms.TextBox();
            this.ymin_t = new System.Windows.Forms.TextBox();
            this.ymax_t = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DL_M3 = new System.Windows.Forms.TextBox();
            this.DL_M2 = new System.Windows.Forms.TextBox();
            this.DL_M1 = new System.Windows.Forms.TextBox();
            this.DL_N = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.miny = new System.Windows.Forms.TextBox();
            this.minx = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.y0 = new System.Windows.Forms.TextBox();
            this.x0 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.epc = new System.Windows.Forms.TextBox();
            this.alfa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pic.Location = new System.Drawing.Point(12, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(400, 400);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(604, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Число \"под-подуровней\"";
            // 
            // label_M2
            // 
            this.label_M2.AutoSize = true;
            this.label_M2.Location = new System.Drawing.Point(604, 305);
            this.label_M2.Name = "label_M2";
            this.label_M2.Size = new System.Drawing.Size(101, 13);
            this.label_M2.TabIndex = 81;
            this.label_M2.Text = "Число подуровней";
            // 
            // label_M1
            // 
            this.label_M1.AutoSize = true;
            this.label_M1.Location = new System.Drawing.Point(604, 279);
            this.label_M1.Name = "label_M1";
            this.label_M1.Size = new System.Drawing.Size(135, 13);
            this.label_M1.TabIndex = 80;
            this.label_M1.Text = "Число основных уровней";
            // 
            // label_N
            // 
            this.label_N.AutoSize = true;
            this.label_N.Location = new System.Drawing.Point(604, 253);
            this.label_N.Name = "label_N";
            this.label_N.Size = new System.Drawing.Size(128, 13);
            this.label_N.TabIndex = 79;
            this.label_N.Text = "Число разбиений сетки";
            // 
            // xmin_t
            // 
            this.xmin_t.Location = new System.Drawing.Point(505, 250);
            this.xmin_t.Name = "xmin_t";
            this.xmin_t.Size = new System.Drawing.Size(59, 20);
            this.xmin_t.TabIndex = 71;
            this.xmin_t.Text = "-1";
            // 
            // xmax_t
            // 
            this.xmax_t.Location = new System.Drawing.Point(504, 305);
            this.xmax_t.Name = "xmax_t";
            this.xmax_t.Size = new System.Drawing.Size(60, 20);
            this.xmax_t.TabIndex = 72;
            this.xmax_t.Text = "1";
            // 
            // ymin_t
            // 
            this.ymin_t.Location = new System.Drawing.Point(505, 276);
            this.ymin_t.Name = "ymin_t";
            this.ymin_t.Size = new System.Drawing.Size(59, 20);
            this.ymin_t.TabIndex = 73;
            this.ymin_t.Text = "-1";
            // 
            // ymax_t
            // 
            this.ymax_t.Location = new System.Drawing.Point(504, 331);
            this.ymax_t.Name = "ymax_t";
            this.ymax_t.Size = new System.Drawing.Size(60, 20);
            this.ymax_t.TabIndex = 74;
            this.ymax_t.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "XMin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "XMax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "YMin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(451, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 78;
            this.label6.Text = "YMax";
            // 
            // DL_M3
            // 
            this.DL_M3.Location = new System.Drawing.Point(757, 328);
            this.DL_M3.Name = "DL_M3";
            this.DL_M3.Size = new System.Drawing.Size(60, 20);
            this.DL_M3.TabIndex = 70;
            this.DL_M3.Text = "3";
            // 
            // DL_M2
            // 
            this.DL_M2.Location = new System.Drawing.Point(757, 302);
            this.DL_M2.Name = "DL_M2";
            this.DL_M2.Size = new System.Drawing.Size(60, 20);
            this.DL_M2.TabIndex = 69;
            this.DL_M2.Text = "5";
            // 
            // DL_M1
            // 
            this.DL_M1.Location = new System.Drawing.Point(756, 276);
            this.DL_M1.Name = "DL_M1";
            this.DL_M1.Size = new System.Drawing.Size(61, 20);
            this.DL_M1.TabIndex = 68;
            this.DL_M1.Text = "10";
            // 
            // DL_N
            // 
            this.DL_N.Location = new System.Drawing.Point(756, 250);
            this.DL_N.Name = "DL_N";
            this.DL_N.Size = new System.Drawing.Size(61, 20);
            this.DL_N.TabIndex = 67;
            this.DL_N.Text = "50";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 83;
            this.button1.Text = "Draw Contour Line";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.miny);
            this.groupBox2.Controls.Add(this.minx);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.y0);
            this.groupBox2.Controls.Add(this.x0);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.epc);
            this.groupBox2.Controls.Add(this.alfa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(431, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 197);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Functions";
            // 
            // miny
            // 
            this.miny.Location = new System.Drawing.Point(176, 125);
            this.miny.Name = "miny";
            this.miny.Size = new System.Drawing.Size(98, 20);
            this.miny.TabIndex = 91;
            // 
            // minx
            // 
            this.minx.Location = new System.Drawing.Point(176, 89);
            this.minx.Name = "minx";
            this.minx.Size = new System.Drawing.Size(98, 20);
            this.minx.TabIndex = 90;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 89;
            this.label11.Text = "Ymin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Xmin";
            // 
            // y0
            // 
            this.y0.Location = new System.Drawing.Point(324, 55);
            this.y0.Name = "y0";
            this.y0.Size = new System.Drawing.Size(60, 20);
            this.y0.TabIndex = 84;
            this.y0.Text = "1";
            // 
            // x0
            // 
            this.x0.Location = new System.Drawing.Point(325, 26);
            this.x0.Name = "x0";
            this.x0.Size = new System.Drawing.Size(59, 20);
            this.x0.TabIndex = 85;
            this.x0.Text = "-1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 86;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "X";
            // 
            // epc
            // 
            this.epc.Location = new System.Drawing.Point(74, 26);
            this.epc.Name = "epc";
            this.epc.Size = new System.Drawing.Size(59, 20);
            this.epc.TabIndex = 78;
            this.epc.Text = "0,0001";
            // 
            // alfa
            // 
            this.alfa.Location = new System.Drawing.Point(74, 52);
            this.alfa.Name = "alfa";
            this.alfa.Size = new System.Drawing.Size(59, 20);
            this.alfa.TabIndex = 80;
            this.alfa.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Epcilon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 83;
            this.label8.Text = "Alfa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 490);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_M2);
            this.Controls.Add(this.label_M1);
            this.Controls.Add(this.label_N);
            this.Controls.Add(this.xmin_t);
            this.Controls.Add(this.xmax_t);
            this.Controls.Add(this.ymin_t);
            this.Controls.Add(this.ymax_t);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DL_M3);
            this.Controls.Add(this.DL_M2);
            this.Controls.Add(this.DL_M1);
            this.Controls.Add(this.DL_N);
            this.Controls.Add(this.pic);
            this.Name = "Form1";
            this.Text = "Отрисовка линий уровня";
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_M2;
        private System.Windows.Forms.Label label_M1;
        private System.Windows.Forms.Label label_N;
        private System.Windows.Forms.TextBox xmin_t;
        private System.Windows.Forms.TextBox xmax_t;
        private System.Windows.Forms.TextBox ymin_t;
        private System.Windows.Forms.TextBox ymax_t;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DL_M3;
        private System.Windows.Forms.TextBox DL_M2;
        private System.Windows.Forms.TextBox DL_M1;
        private System.Windows.Forms.TextBox DL_N;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox y0;
        private System.Windows.Forms.TextBox x0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox epc;
        private System.Windows.Forms.TextBox alfa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox miny;
        private System.Windows.Forms.TextBox minx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
    }
}

