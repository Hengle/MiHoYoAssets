namespace MiHoYoAssets
{
    public partial class MiHoYoForm : Form
    {
        private string inputPathBackup = string.Empty;
        private string outputPathBackup = string.Empty;
        private List<Task> Tasks = new();

        public string InputFolder;
        public List<string> InputFiles = new();
        private Format Format => assetTypeComboBox.SelectedValue as Format;
        private bool IsEncrypt => isEncryptCheckBox.Checked;
        private bool IsFolder => isFolderCheckBox.Checked;
        public MiHoYoForm()
        {
            InitializeComponent();
            assetTypeComboBox.DataSource = FormatManager.GetFormats();
        }
        private bool CheckPaths()
        {
            return Invoke(() =>
            {
                if (InputFiles.Count > 0 && Format.Name == "GI" && IsEncrypt)
                {
                    MessageBox.Show("Only input type folder is allowed for encrypting blk type !!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (!(Format.Name == "EC2B" || IsEncrypt))
                {
                    if (InputFiles.Count > 0)
                    {
                        foreach (var file in InputFiles)
                        {
                            if (!File.Exists(file))
                            {
                                MessageBox.Show($"Invalid input file {file}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(InputFolder))
                        {
                            MessageBox.Show($"Invalid Input Folder !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }

                if (!Directory.Exists(outputTextBox.Text))
                {
                    MessageBox.Show($"Invalid Output Folder !!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            });
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!CheckPaths())
                return;

            Process();

            Result();
        }
        
        private void Result()
        {
            Task.WhenAll(Tasks.ToArray()).ContinueWith(x =>
            {
                var errorMsg = x.IsFaulted ? string.Join("\n", x.Exception.InnerExceptions.Select(x => x.Message).ToArray()) : "";
                File.WriteAllText("ga.log", errorMsg);
                if (x.IsFaulted)
                    Invoke(() => MessageBox.Show(this, "Error occured, check ga.log for more info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                else
                    Invoke(() => MessageBox.Show(this, "Done !!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information));
                Invoke(() =>
                {
                    startButton.Text = "Start";
                    Enabled = true;
                });
            });
        }
        private void Process()
        {
            startButton.Text = "Processing...";
            Enabled = false;

            Tasks.Clear();
            var input = "";
            var isEncrypt = IsEncrypt;
            var outputFolder = outputTextBox.Text;
            if (Format.Name == "EC2B" && isEncrypt)
            {
                using var inputForm = new InputForm();
                var result = inputForm.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;
                input = inputForm.Input;
                Format.Process(input, outputFolder, isEncrypt);
            }
            else
            {
                foreach(var file in InputFiles)
                {
                    Format.Process(file, outputFolder, isEncrypt);
                }
            }
        }

        private async Task ExecuteAction(Action<string, string> action, string input, string output)
        {
            try
            {
               await Task.Run(() => action(input, output));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void inputPathButton_Click(object sender, EventArgs e)
        {
            InputFolder = "";
            InputFiles.Clear();
            if (Format.Name == "EC2B" && IsEncrypt)
            {
                MessageBox.Show("Start to enter seed !!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Format.Name == "GI" && IsEncrypt && !IsFolder)
            {
                MessageBox.Show("Only input type folder is allowed for encrypting blk type !!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!IsFolder)
            {
                var filter = $"{Format.DisplayName}|{(IsEncrypt ? Format.Pattern.Item2 : Format.Pattern.Item1)}";
                var ofd = new OpenFileDialog() { InitialDirectory = inputPathBackup, Filter = filter,  Multiselect = true };
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    InputFiles.AddRange(ofd.FileNames);
                    inputPathBackup = Path.GetDirectoryName(ofd.FileNames[^1]);
                    inputLabel.Text = $"{ofd.FileNames.Length} file(s) selected.";
                }
            }
            else if (IsFolder)
            {
                var fsd = new FolderBrowserDialog() { SelectedPath = inputPathBackup };
                if (fsd.ShowDialog(this) == DialogResult.OK)
                {
                    InputFolder = fsd.SelectedPath;
                    inputPathBackup = fsd.SelectedPath;
                    inputLabel.Text = "Folder selected.";
                }
            }
        }

        private void outputPathButton_Click(object sender, EventArgs e)
        {
            var fsd = new FolderBrowserDialog() { SelectedPath = outputPathBackup };
            if (fsd.ShowDialog(this) == DialogResult.OK)
            {
                outputPathBackup = fsd.SelectedPath;
                outputTextBox.Text = fsd.SelectedPath;
            }
        }

        private void opTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isEncryptCheckBox.Text = isEncryptCheckBox.Checked ? "Encrypt" : "Decrypt";
        }

        private void inputTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isFolderCheckBox.Text = isFolderCheckBox.Checked ? "Folder" : "File(s)";
        }
    }
}