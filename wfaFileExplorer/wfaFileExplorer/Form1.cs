namespace wfaFileExplorer
{
    public partial class Form1 : Form
    {
        private string curDir;

        public string CurDir
        {
            get => curDir; private set
            {
                curDir = value;
                edDir.Text = curDir;
            }
        }

        public string SelectItem { get; private set; }

        public Form1()
        {
            InitializeComponent();

            //CurDir = "D:\\";
            CurDir = Directory.GetCurrentDirectory();

            //buBack.Click;
            //buForward.Click;
            buUp.Click += (s, e) => LoadDir(Directory.GetParent(CurDir).ToString());
            edDir.KeyDown += EdDir_KeyDown;
            //buDirSelect.Click;

            miViewLargeIcon.Click += (s, e) => listView1.View = View.LargeIcon;
            miViewSmallIcon.Click += (s, e) => listView1.View = View.SmallIcon;
            miViewList.Click += (s, e) => listView1.View = View.List;
            miViewDetails.Click += (s, e) => listView1.View = View.Details;
            miViewTile.Click += (s, e) => listView1.View = View.Tile;
            buDirSelect.Click += BuDirSelect_Click;

            //(1)
            //ColumnHeader c1 = new();
            //c1.Text = "Имя";
            //c1.Width = 350;
            //listView1.Columns.Add(c1);

            //(2)
            //listView1.Columns.Add(new ColumnHeader() { Text = "Имя", Width = 350 });

            //(3)
            listView1.Columns.Add("Имя", 350);
            listView1.Columns.Add("Дата изменения", 150);
            listView1.Columns.Add("Тип", 100);
            listView1.Columns.Add("Размер", 150);

            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
            listView1.DoubleClick += ListView1_DoubleClick;

            this.Text += $":{string.Join(" ", Directory.GetLogicalDrives())}";
            foreach (var drive in Directory.GetLogicalDrives())
            {
                treeView1.Nodes.Add(drive);
            }
            treeView1.DoubleClick += TreeView1_DoubleClick;
            LoadDir(CurDir);
        }

        private void TreeView1_DoubleClick(object? sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new(treeView1.SelectedNode.FullPath);
            treeView1.BeginUpdate();
            treeView1.SelectedNode.Nodes.Clear();
            foreach (var item in directoryInfo.GetDirectories())
            {
                treeView1.SelectedNode.Nodes.Add(treeView1.SelectedNode.FullPath, item.Name, 0);
            }
            treeView1.SelectedNode.Expand();
            treeView1.EndUpdate();
        }

        private void ListView1_DoubleClick(object? sender, EventArgs e)
        {

            LoadDir(SelectItem);
        }

        private void BuDirSelect_Click(object? sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadDir(dialog.SelectedPath);
            }
        }

        private void ListView1_ItemSelectionChanged(object? sender, ListViewItemSelectionChangedEventArgs e)
        {
            SelectItem = Path.Combine(CurDir, e.Item.Text);
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            laStatus.Text = $"Элементов: {listView1.Items.Count}, Выбрано: {listView1.SelectedItems.Count}";
        }

        private void EdDir_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDir(edDir.Text);
            }
        }

        private void LoadDir(string newDir)
        {
            DirectoryInfo directoryInfo = new(newDir);

            listView1.Items.Clear();
            foreach (var item in directoryInfo.GetDirectories())
            {
                //(1)
                //listView1.Items.Add(item.Name, 0);
                listView1.Items.Add(new ListViewItem(
                    new string[] { item.Name, item.LastWriteTime.ToString(), "Папка ", "" },
                    0));
            }
            foreach (var item in directoryInfo.GetFiles())
            {
                //(1)
                //listView1.Items.Add(item.Name, 1);
                //(2)
                listView1.Items.Add(new ListViewItem(
                    new string[] { item.Name, item.LastWriteTime.ToString(), "Файл " + item.Extension, item.Length.ToString() + "байт" },
                    1));
            }
            listView1.EndUpdate();

            RefreshStatus();

            CurDir = newDir;
        }
    }
}