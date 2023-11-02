namespace wfaFileExplorer
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            buBack = new ToolStripButton();
            buForward = new ToolStripButton();
            buUp = new ToolStripButton();
            edDir = new ToolStripTextBox();
            buDirSelect = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            miViewLargeIcon = new ToolStripMenuItem();
            miViewSmallIcon = new ToolStripMenuItem();
            miViewList = new ToolStripMenuItem();
            miViewDetails = new ToolStripMenuItem();
            miViewTile = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            laStatus = new ToolStripStatusLabel();
            panel1 = new Panel();
            listView1 = new ListView();
            ilLarge = new ImageList(components);
            ilSmall = new ImageList(components);
            splitter1 = new Splitter();
            treeView1 = new TreeView();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { buBack, buForward, buUp, edDir, buDirSelect, toolStripDropDownButton1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(753, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // buBack
            // 
            buBack.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buBack.Image = (Image)resources.GetObject("buBack.Image");
            buBack.ImageTransparentColor = Color.Magenta;
            buBack.Name = "buBack";
            buBack.Size = new Size(23, 22);
            buBack.Text = "◀";
            // 
            // buForward
            // 
            buForward.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buForward.Image = (Image)resources.GetObject("buForward.Image");
            buForward.ImageTransparentColor = Color.Magenta;
            buForward.Name = "buForward";
            buForward.Size = new Size(23, 22);
            buForward.Text = "▶";
            // 
            // buUp
            // 
            buUp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buUp.Image = (Image)resources.GetObject("buUp.Image");
            buUp.ImageTransparentColor = Color.Magenta;
            buUp.Name = "buUp";
            buUp.Size = new Size(23, 22);
            buUp.Text = "▲";
            // 
            // edDir
            // 
            edDir.Name = "edDir";
            edDir.Size = new Size(351, 25);
            // 
            // buDirSelect
            // 
            buDirSelect.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buDirSelect.Image = (Image)resources.GetObject("buDirSelect.Image");
            buDirSelect.ImageTransparentColor = Color.Magenta;
            buDirSelect.Name = "buDirSelect";
            buDirSelect.Size = new Size(23, 22);
            buDirSelect.Text = "...";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { miViewLargeIcon, miViewSmallIcon, miViewList, miViewDetails, miViewTile });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(40, 22);
            toolStripDropDownButton1.Text = "Вид";
            // 
            // miViewLargeIcon
            // 
            miViewLargeIcon.Name = "miViewLargeIcon";
            miViewLargeIcon.Size = new Size(164, 22);
            miViewLargeIcon.Text = "Крупные значки";
            // 
            // miViewSmallIcon
            // 
            miViewSmallIcon.Name = "miViewSmallIcon";
            miViewSmallIcon.Size = new Size(164, 22);
            miViewSmallIcon.Text = "Мелкие значки";
            // 
            // miViewList
            // 
            miViewList.Name = "miViewList";
            miViewList.Size = new Size(164, 22);
            miViewList.Text = "Список";
            // 
            // miViewDetails
            // 
            miViewDetails.Name = "miViewDetails";
            miViewDetails.Size = new Size(164, 22);
            miViewDetails.Text = "Таблица";
            // 
            // miViewTile
            // 
            miViewTile.Name = "miViewTile";
            miViewTile.Size = new Size(164, 22);
            miViewTile.Text = "Плитки";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { laStatus });
            statusStrip1.Location = new Point(0, 445);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 10, 0);
            statusStrip1.Size = new Size(753, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // laStatus
            // 
            laStatus.Name = "laStatus";
            laStatus.Size = new Size(118, 17);
            laStatus.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(splitter1);
            panel1.Controls.Add(treeView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 25);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(753, 420);
            panel1.TabIndex = 2;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.LargeImageList = ilLarge;
            listView1.Location = new Point(132, 0);
            listView1.Margin = new Padding(2, 2, 2, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(621, 420);
            listView1.SmallImageList = ilSmall;
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ilLarge
            // 
            ilLarge.ColorDepth = ColorDepth.Depth32Bit;
            ilLarge.ImageStream = (ImageListStreamer)resources.GetObject("ilLarge.ImageStream");
            ilLarge.TransparentColor = Color.Transparent;
            ilLarge.Images.SetKeyName(0, "papka.png");
            ilLarge.Images.SetKeyName(1, "fail.png");
            // 
            // ilSmall
            // 
            ilSmall.ColorDepth = ColorDepth.Depth32Bit;
            ilSmall.ImageStream = (ImageListStreamer)resources.GetObject("ilSmall.ImageStream");
            ilSmall.TransparentColor = Color.Transparent;
            ilSmall.Images.SetKeyName(0, "papka.png");
            ilSmall.Images.SetKeyName(1, "fail.png");
            // 
            // splitter1
            // 
            splitter1.Location = new Point(129, 0);
            splitter1.Margin = new Padding(2, 2, 2, 2);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 420);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Left;
            treeView1.ImageIndex = 0;
            treeView1.ImageList = ilSmall;
            treeView1.Location = new Point(0, 0);
            treeView1.Margin = new Padding(2, 2, 2, 2);
            treeView1.Name = "treeView1";
            treeView1.SelectedImageIndex = 0;
            treeView1.Size = new Size(129, 420);
            treeView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 467);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "wfaFileExplorer";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton buBack;
        private ToolStripButton buForward;
        private ToolStripButton buUp;
        private ToolStripTextBox edDir;
        private ToolStripButton buDirSelect;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private StatusStrip statusStrip1;
        private Panel panel1;
        private Splitter splitter1;
        private TreeView treeView1;
        private ListView listView1;
        private ImageList ilLarge;
        private ImageList ilSmall;
        private ToolStripMenuItem miViewLargeIcon;
        private ToolStripMenuItem miViewSmallIcon;
        private ToolStripMenuItem miViewList;
        private ToolStripMenuItem miViewDetails;
        private ToolStripMenuItem miViewTile;
        private ToolStripStatusLabel laStatus;
    }
}