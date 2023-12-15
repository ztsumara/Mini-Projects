namespace Contour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.buSave = new System.Windows.Forms.ToolStripMenuItem();
            this.областьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buExportToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.buImportFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buFindObjects = new System.Windows.Forms.ToolStripButton();
            this.buCreateRect = new System.Windows.Forms.ToolStripButton();
            this.buSaveObl = new System.Windows.Forms.ToolStripButton();
            this.buSaveActiveObl = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.областьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buOpen,
            this.buSave});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // buOpen
            // 
            this.buOpen.Name = "buOpen";
            this.buOpen.Size = new System.Drawing.Size(133, 22);
            this.buOpen.Text = "Открыть";
            this.buOpen.Click += new System.EventHandler(this.buOpen_Click);
            // 
            // buSave
            // 
            this.buSave.Name = "buSave";
            this.buSave.Size = new System.Drawing.Size(133, 22);
            this.buSave.Text = "Сохранить";
            // 
            // областьToolStripMenuItem
            // 
            this.областьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buExportToFile,
            this.buImportFromFile});
            this.областьToolStripMenuItem.Name = "областьToolStripMenuItem";
            this.областьToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.областьToolStripMenuItem.Text = "Область";
            // 
            // buExportToFile
            // 
            this.buExportToFile.Name = "buExportToFile";
            this.buExportToFile.Size = new System.Drawing.Size(171, 22);
            this.buExportToFile.Text = "Экспорт в файл";
            // 
            // buImportFromFile
            // 
            this.buImportFromFile.Name = "buImportFromFile";
            this.buImportFromFile.Size = new System.Drawing.Size(171, 22);
            this.buImportFromFile.Text = "Импорт из файла";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buFindObjects,
            this.buCreateRect,
            this.buSaveObl,
            this.buSaveActiveObl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buFindObjects
            // 
            this.buFindObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buFindObjects.Image = ((System.Drawing.Image)(resources.GetObject("buFindObjects.Image")));
            this.buFindObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buFindObjects.Name = "buFindObjects";
            this.buFindObjects.Size = new System.Drawing.Size(123, 22);
            this.buFindObjects.Text = "Распознать объекты";
            this.buFindObjects.Click += new System.EventHandler(this.buFindObjects_Click);
            // 
            // buCreateRect
            // 
            this.buCreateRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buCreateRect.Image = ((System.Drawing.Image)(resources.GetObject("buCreateRect.Image")));
            this.buCreateRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buCreateRect.Name = "buCreateRect";
            this.buCreateRect.Size = new System.Drawing.Size(101, 22);
            this.buCreateRect.Text = "Создать область";
            // 
            // buSaveObl
            // 
            this.buSaveObl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buSaveObl.Image = ((System.Drawing.Image)(resources.GetObject("buSaveObl.Image")));
            this.buSaveObl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buSaveObl.Name = "buSaveObl";
            this.buSaveObl.Size = new System.Drawing.Size(118, 22);
            this.buSaveObl.Text = "Сохранить области";
            // 
            // buSaveActiveObl
            // 
            this.buSaveActiveObl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buSaveActiveObl.Image = ((System.Drawing.Image)(resources.GetObject("buSaveActiveObl.Image")));
            this.buSaveActiveObl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buSaveActiveObl.Name = "buSaveActiveObl";
            this.buSaveActiveObl.Size = new System.Drawing.Size(173, 22);
            this.buSaveActiveObl.Text = "Сохранить активную область";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG|*.jpg|PNG|*.png";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 401);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 374);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(641, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(159, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Автообновление контуров";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buOpen;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buFindObjects;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem buSave;
        private System.Windows.Forms.ToolStripButton buCreateRect;
        private System.Windows.Forms.ToolStripButton buSaveObl;
        private System.Windows.Forms.ToolStripButton buSaveActiveObl;
        private System.Windows.Forms.ToolStripMenuItem областьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buExportToFile;
        private System.Windows.Forms.ToolStripMenuItem buImportFromFile;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

