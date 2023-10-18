namespace wfaGameTrainerAccount
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.laFalse = new System.Windows.Forms.Label();
            this.laTrue = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buNo = new System.Windows.Forms.Button();
            this.buYes = new System.Windows.Forms.Button();
            this.laCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.laLevel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.laFalse, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.laTrue, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 185);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // laFalse
            // 
            this.laFalse.AutoSize = true;
            this.laFalse.BackColor = System.Drawing.Color.Red;
            this.laFalse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laFalse.Location = new System.Drawing.Point(288, 0);
            this.laFalse.Name = "laFalse";
            this.laFalse.Size = new System.Drawing.Size(280, 185);
            this.laFalse.TabIndex = 1;
            this.laFalse.Text = "Неверно = 0";
            this.laFalse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laTrue
            // 
            this.laTrue.AutoSize = true;
            this.laTrue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.laTrue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laTrue.Location = new System.Drawing.Point(3, 0);
            this.laTrue.Name = "laTrue";
            this.laTrue.Size = new System.Drawing.Size(279, 185);
            this.laTrue.TabIndex = 0;
            this.laTrue.Text = "Верно = 0";
            this.laTrue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buNo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buYes, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 403);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(571, 100);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buNo
            // 
            this.buNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buNo.Location = new System.Drawing.Point(288, 3);
            this.buNo.Name = "buNo";
            this.buNo.Size = new System.Drawing.Size(280, 94);
            this.buNo.TabIndex = 1;
            this.buNo.Text = "Нет";
            this.buNo.UseVisualStyleBackColor = true;
            // 
            // buYes
            // 
            this.buYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buYes.ForeColor = System.Drawing.Color.ForestGreen;
            this.buYes.Location = new System.Drawing.Point(3, 3);
            this.buYes.Name = "buYes";
            this.buYes.Size = new System.Drawing.Size(279, 94);
            this.buYes.TabIndex = 0;
            this.buYes.Text = "Да";
            this.buYes.UseVisualStyleBackColor = true;
            // 
            // laCode
            // 
            this.laCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.laCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laCode.Location = new System.Drawing.Point(12, 236);
            this.laCode.Name = "laCode";
            this.laCode.Size = new System.Drawing.Size(571, 67);
            this.laCode.TabIndex = 2;
            this.laCode.Text = "5 + 6 = 11";
            this.laCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(571, 83);
            this.label4.TabIndex = 3;
            this.label4.Text = "Верно?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laLevel
            // 
            this.laLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.laLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laLevel.Location = new System.Drawing.Point(12, 210);
            this.laLevel.Name = "laLevel";
            this.laLevel.Size = new System.Drawing.Size(568, 26);
            this.laLevel.TabIndex = 4;
            this.laLevel.Text = "Уровень: 1";
            this.laLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 515);
            this.Controls.Add(this.laLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.laCode);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(611, 554);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label laTrue;
        private System.Windows.Forms.Label laFalse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buNo;
        private System.Windows.Forms.Button buYes;
        private System.Windows.Forms.Label laCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label laLevel;
    }
}

