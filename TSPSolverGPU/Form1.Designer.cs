namespace TSPSolverGPU
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.loadFile_button = new System.Windows.Forms.Button();
            this.loadFileLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cutRadioButton = new System.Windows.Forms.RadioButton();
            this.bruteForceRadioButton = new System.Windows.Forms.RadioButton();
            this.solutionTypeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.oneThreadCPURadioButton = new System.Windows.Forms.RadioButton();
            this.multiThreadCPURadioButton = new System.Windows.Forms.RadioButton();
            this.multiThreadGPURadioButton = new System.Windows.Forms.RadioButton();
            this.parallelCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.clearFormButton = new System.Windows.Forms.Button();
            this.runSolverButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.imageSizeCoef = new System.Windows.Forms.TextBox();
            this.resizeImageButton = new System.Windows.Forms.Button();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.coordsDataGrid = new System.Windows.Forms.DataGridView();
            this.xCoord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCoord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskNameTB = new System.Windows.Forms.TextBox();
            this.taskTypeTB = new System.Windows.Forms.TextBox();
            this.taskCommentTB = new System.Windows.Forms.TextBox();
            this.taskDimensionalTB = new System.Windows.Forms.TextBox();
            this.taskEdgeWeightTypeTB = new System.Windows.Forms.TextBox();
            this.taskDisplayDataTypeTB = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.objectiveFunctionLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.timeSolutionLabel = new System.Windows.Forms.Label();
            this.roadTextBox = new System.Windows.Forms.TextBox();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveResultDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parallelCountNumeric)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordsDataGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.loadFile_button, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.loadFileLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.solutionTypeLabel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.parallelCountNumeric, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.clearFormButton, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.runSolverButton, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.coordsDataGrid, 0, 20);
            this.tableLayoutPanel1.Controls.Add(this.taskNameTB, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.taskTypeTB, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.taskCommentTB, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.taskDimensionalTB, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.taskEdgeWeightTypeTB, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.taskDisplayDataTypeTB, 1, 18);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.objectiveFunctionLabel, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 15);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 16);
            this.tableLayoutPanel1.Controls.Add(this.saveResultButton, 2, 21);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 22;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1103, 830);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // loadFile_button
            // 
            this.loadFile_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadFile_button.Location = new System.Drawing.Point(806, 3);
            this.loadFile_button.Name = "loadFile_button";
            this.loadFile_button.Size = new System.Drawing.Size(294, 34);
            this.loadFile_button.TabIndex = 0;
            this.loadFile_button.Text = "Загрузить из файла (.tsp)";
            this.loadFile_button.UseVisualStyleBackColor = true;
            this.loadFile_button.Click += new System.EventHandler(this.loadFile_button_Click);
            // 
            // loadFileLabel
            // 
            this.loadFileLabel.AutoSize = true;
            this.loadFileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadFileLabel.Location = new System.Drawing.Point(806, 40);
            this.loadFileLabel.Name = "loadFileLabel";
            this.loadFileLabel.Size = new System.Drawing.Size(294, 25);
            this.loadFileLabel.TabIndex = 1;
            this.loadFileLabel.Text = "Данные не загружены";
            this.loadFileLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(806, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите способ решения";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cutRadioButton);
            this.flowLayoutPanel1.Controls.Add(this.bruteForceRadioButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(806, 88);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(294, 54);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // cutRadioButton
            // 
            this.cutRadioButton.AutoSize = true;
            this.cutRadioButton.Checked = true;
            this.cutRadioButton.Location = new System.Drawing.Point(3, 3);
            this.cutRadioButton.Name = "cutRadioButton";
            this.cutRadioButton.Size = new System.Drawing.Size(177, 20);
            this.cutRadioButton.TabIndex = 0;
            this.cutRadioButton.TabStop = true;
            this.cutRadioButton.Text = "Отбор лучших                    ";
            this.cutRadioButton.UseVisualStyleBackColor = true;
            this.cutRadioButton.CheckedChanged += new System.EventHandler(this.cutRadioButton_CheckedChanged);
            // 
            // bruteForceRadioButton
            // 
            this.bruteForceRadioButton.AutoSize = true;
            this.bruteForceRadioButton.Location = new System.Drawing.Point(3, 29);
            this.bruteForceRadioButton.Name = "bruteForceRadioButton";
            this.bruteForceRadioButton.Size = new System.Drawing.Size(136, 20);
            this.bruteForceRadioButton.TabIndex = 1;
            this.bruteForceRadioButton.Text = "Полный перебор";
            this.bruteForceRadioButton.UseVisualStyleBackColor = true;
            this.bruteForceRadioButton.CheckedChanged += new System.EventHandler(this.bruteForceRadioButton_CheckedChanged);
            // 
            // solutionTypeLabel
            // 
            this.solutionTypeLabel.AutoSize = true;
            this.solutionTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionTypeLabel.Location = new System.Drawing.Point(806, 145);
            this.solutionTypeLabel.Name = "solutionTypeLabel";
            this.solutionTypeLabel.Size = new System.Drawing.Size(294, 20);
            this.solutionTypeLabel.TabIndex = 4;
            this.solutionTypeLabel.Text = "Количество сохраняемых вариантов";
            this.solutionTypeLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(806, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Режим вычисления";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.oneThreadCPURadioButton);
            this.flowLayoutPanel2.Controls.Add(this.multiThreadCPURadioButton);
            this.flowLayoutPanel2.Controls.Add(this.multiThreadGPURadioButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(806, 216);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(294, 84);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // oneThreadCPURadioButton
            // 
            this.oneThreadCPURadioButton.AutoSize = true;
            this.oneThreadCPURadioButton.Checked = true;
            this.oneThreadCPURadioButton.Location = new System.Drawing.Point(3, 3);
            this.oneThreadCPURadioButton.Name = "oneThreadCPURadioButton";
            this.oneThreadCPURadioButton.Size = new System.Drawing.Size(174, 20);
            this.oneThreadCPURadioButton.TabIndex = 0;
            this.oneThreadCPURadioButton.TabStop = true;
            this.oneThreadCPURadioButton.Text = "Однопоточный на CPU";
            this.oneThreadCPURadioButton.UseVisualStyleBackColor = true;
            // 
            // multiThreadCPURadioButton
            // 
            this.multiThreadCPURadioButton.AutoSize = true;
            this.multiThreadCPURadioButton.Location = new System.Drawing.Point(3, 29);
            this.multiThreadCPURadioButton.Name = "multiThreadCPURadioButton";
            this.multiThreadCPURadioButton.Size = new System.Drawing.Size(181, 20);
            this.multiThreadCPURadioButton.TabIndex = 1;
            this.multiThreadCPURadioButton.Text = "Многопоточный на CPU";
            this.multiThreadCPURadioButton.UseVisualStyleBackColor = true;
            // 
            // multiThreadGPURadioButton
            // 
            this.multiThreadGPURadioButton.AutoSize = true;
            this.multiThreadGPURadioButton.Location = new System.Drawing.Point(3, 55);
            this.multiThreadGPURadioButton.Name = "multiThreadGPURadioButton";
            this.multiThreadGPURadioButton.Size = new System.Drawing.Size(182, 20);
            this.multiThreadGPURadioButton.TabIndex = 2;
            this.multiThreadGPURadioButton.Text = "Многопоточный на GPU";
            this.multiThreadGPURadioButton.UseVisualStyleBackColor = true;
            // 
            // parallelCountNumeric
            // 
            this.parallelCountNumeric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parallelCountNumeric.Location = new System.Drawing.Point(806, 168);
            this.parallelCountNumeric.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.parallelCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.parallelCountNumeric.Name = "parallelCountNumeric";
            this.parallelCountNumeric.Size = new System.Drawing.Size(294, 22);
            this.parallelCountNumeric.TabIndex = 7;
            this.parallelCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clearFormButton
            // 
            this.clearFormButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearFormButton.ForeColor = System.Drawing.Color.Red;
            this.clearFormButton.Location = new System.Drawing.Point(806, 308);
            this.clearFormButton.Name = "clearFormButton";
            this.clearFormButton.Size = new System.Drawing.Size(294, 24);
            this.clearFormButton.TabIndex = 8;
            this.clearFormButton.Text = "Очистить";
            this.clearFormButton.UseVisualStyleBackColor = true;
            this.clearFormButton.Click += new System.EventHandler(this.clearFormButton_Click);
            // 
            // runSolverButton
            // 
            this.runSolverButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runSolverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runSolverButton.Location = new System.Drawing.Point(806, 338);
            this.runSolverButton.Name = "runSolverButton";
            this.runSolverButton.Size = new System.Drawing.Size(294, 34);
            this.runSolverButton.TabIndex = 9;
            this.runSolverButton.Text = "ЗАПУСТИТЬ";
            this.runSolverButton.UseVisualStyleBackColor = true;
            this.runSolverButton.Click += new System.EventHandler(this.runSolverButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.graphPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 11);
            this.panel1.Size = new System.Drawing.Size(797, 369);
            this.panel1.TabIndex = 10;
            // 
            // graphPictureBox
            // 
            this.graphPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.graphPictureBox.InitialImage = null;
            this.graphPictureBox.Location = new System.Drawing.Point(0, 0);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(3168, 1859);
            this.graphPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.graphPictureBox.TabIndex = 0;
            this.graphPictureBox.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel3, 2);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.imageSizeCoef);
            this.flowLayoutPanel3.Controls.Add(this.resizeImageButton);
            this.flowLayoutPanel3.Controls.Add(this.saveImageButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 378);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(797, 29);
            this.flowLayoutPanel3.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(317, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Коэффициент масштабирования изображения:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageSizeCoef
            // 
            this.imageSizeCoef.Location = new System.Drawing.Point(326, 3);
            this.imageSizeCoef.Name = "imageSizeCoef";
            this.imageSizeCoef.Size = new System.Drawing.Size(100, 22);
            this.imageSizeCoef.TabIndex = 1;
            this.imageSizeCoef.Text = "1";
            // 
            // resizeImageButton
            // 
            this.resizeImageButton.Location = new System.Drawing.Point(444, 3);
            this.resizeImageButton.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.resizeImageButton.Name = "resizeImageButton";
            this.resizeImageButton.Size = new System.Drawing.Size(135, 23);
            this.resizeImageButton.TabIndex = 2;
            this.resizeImageButton.Text = "Масштабировать";
            this.resizeImageButton.UseVisualStyleBackColor = true;
            this.resizeImageButton.Click += new System.EventHandler(this.resizeImageButton_Click);
            // 
            // saveImageButton
            // 
            this.saveImageButton.Location = new System.Drawing.Point(597, 3);
            this.saveImageButton.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(188, 23);
            this.saveImageButton.TabIndex = 3;
            this.saveImageButton.Text = "Сохранить изображение";
            this.saveImageButton.UseVisualStyleBackColor = true;
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 2);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(797, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "ДАННЫЕ ЗАДАЧИ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 435);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "TASK NAME:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "TYPE:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 50);
            this.label9.TabIndex = 15;
            this.label9.Text = "COMMENT:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "DIMENSION:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 560);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "EDGE_WEIGHT_TYPE:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 585);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 25);
            this.label12.TabIndex = 18;
            this.label12.Text = "DISPLAY_DATA_TYPE:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label13, 2);
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 610);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(797, 30);
            this.label13.TabIndex = 19;
            this.label13.Text = "NODE_COORD_SECTION";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // coordsDataGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.coordsDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.coordsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.coordsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.coordsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xCoord,
            this.yCoord});
            this.tableLayoutPanel1.SetColumnSpan(this.coordsDataGrid, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.coordsDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.coordsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordsDataGrid.Location = new System.Drawing.Point(3, 643);
            this.coordsDataGrid.Name = "coordsDataGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.coordsDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.coordsDataGrid.RowHeadersWidth = 150;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.coordsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.tableLayoutPanel1.SetRowSpan(this.coordsDataGrid, 2);
            this.coordsDataGrid.Size = new System.Drawing.Size(797, 184);
            this.coordsDataGrid.TabIndex = 20;
            this.coordsDataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.coordsDataGrid_RowsAdded);
            // 
            // xCoord
            // 
            this.xCoord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.xCoord.HeaderText = "X";
            this.xCoord.Name = "xCoord";
            this.xCoord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // yCoord
            // 
            this.yCoord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yCoord.HeaderText = "Y";
            this.yCoord.Name = "yCoord";
            this.yCoord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // taskNameTB
            // 
            this.taskNameTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskNameTB.Location = new System.Drawing.Point(173, 438);
            this.taskNameTB.Name = "taskNameTB";
            this.taskNameTB.Size = new System.Drawing.Size(627, 22);
            this.taskNameTB.TabIndex = 21;
            // 
            // taskTypeTB
            // 
            this.taskTypeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTypeTB.Location = new System.Drawing.Point(173, 463);
            this.taskTypeTB.Name = "taskTypeTB";
            this.taskTypeTB.Size = new System.Drawing.Size(627, 22);
            this.taskTypeTB.TabIndex = 21;
            // 
            // taskCommentTB
            // 
            this.taskCommentTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskCommentTB.Location = new System.Drawing.Point(173, 488);
            this.taskCommentTB.Multiline = true;
            this.taskCommentTB.Name = "taskCommentTB";
            this.taskCommentTB.Size = new System.Drawing.Size(627, 44);
            this.taskCommentTB.TabIndex = 21;
            // 
            // taskDimensionalTB
            // 
            this.taskDimensionalTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDimensionalTB.Location = new System.Drawing.Point(173, 538);
            this.taskDimensionalTB.Name = "taskDimensionalTB";
            this.taskDimensionalTB.Size = new System.Drawing.Size(627, 22);
            this.taskDimensionalTB.TabIndex = 21;
            // 
            // taskEdgeWeightTypeTB
            // 
            this.taskEdgeWeightTypeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskEdgeWeightTypeTB.Location = new System.Drawing.Point(173, 563);
            this.taskEdgeWeightTypeTB.Name = "taskEdgeWeightTypeTB";
            this.taskEdgeWeightTypeTB.Size = new System.Drawing.Size(627, 22);
            this.taskEdgeWeightTypeTB.TabIndex = 21;
            // 
            // taskDisplayDataTypeTB
            // 
            this.taskDisplayDataTypeTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskDisplayDataTypeTB.Location = new System.Drawing.Point(173, 588);
            this.taskDisplayDataTypeTB.Name = "taskDisplayDataTypeTB";
            this.taskDisplayDataTypeTB.Size = new System.Drawing.Size(627, 22);
            this.taskDisplayDataTypeTB.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(806, 410);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(294, 25);
            this.label14.TabIndex = 22;
            this.label14.Text = "ВЫЧИСЛЕННЫЕ ПАРАМЕТРЫ:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objectiveFunctionLabel
            // 
            this.objectiveFunctionLabel.AutoSize = true;
            this.objectiveFunctionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectiveFunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.objectiveFunctionLabel.Location = new System.Drawing.Point(806, 435);
            this.objectiveFunctionLabel.Name = "objectiveFunctionLabel";
            this.tableLayoutPanel1.SetRowSpan(this.objectiveFunctionLabel, 2);
            this.objectiveFunctionLabel.Size = new System.Drawing.Size(294, 50);
            this.objectiveFunctionLabel.TabIndex = 23;
            this.objectiveFunctionLabel.Text = "Минимальное значение целевой функции: NULL";
            this.objectiveFunctionLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(806, 485);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(294, 50);
            this.label17.TabIndex = 25;
            this.label17.Text = "Оптимальный маршрут:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.timeSolutionLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.roadTextBox, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(806, 538);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 5);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 249);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // timeSolutionLabel
            // 
            this.timeSolutionLabel.AutoSize = true;
            this.timeSolutionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeSolutionLabel.Location = new System.Drawing.Point(3, 199);
            this.timeSolutionLabel.Name = "timeSolutionLabel";
            this.timeSolutionLabel.Size = new System.Drawing.Size(288, 50);
            this.timeSolutionLabel.TabIndex = 0;
            this.timeSolutionLabel.Text = "Время последнего выполнения: 0 с.";
            this.timeSolutionLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // roadTextBox
            // 
            this.roadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roadTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roadTextBox.Location = new System.Drawing.Point(3, 3);
            this.roadTextBox.Multiline = true;
            this.roadTextBox.Name = "roadTextBox";
            this.roadTextBox.ReadOnly = true;
            this.roadTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.roadTextBox.Size = new System.Drawing.Size(288, 193);
            this.roadTextBox.TabIndex = 1;
            // 
            // saveResultButton
            // 
            this.saveResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveResultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveResultButton.Location = new System.Drawing.Point(806, 793);
            this.saveResultButton.Name = "saveResultButton";
            this.saveResultButton.Size = new System.Drawing.Size(294, 34);
            this.saveResultButton.TabIndex = 30;
            this.saveResultButton.Text = "Сохранить результат";
            this.saveResultButton.UseVisualStyleBackColor = true;
            this.saveResultButton.Click += new System.EventHandler(this.saveResultButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "TSP files (*.tsp)|*.tsp|All files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "graph";
            this.saveFileDialog.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            // 
            // saveResultDialog
            // 
            this.saveResultDialog.FileName = "TSPResult";
            this.saveResultDialog.Filter = "TSP files (*.tsp)|*.tsp|All files (*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 830);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1119, 869);
            this.Name = "Form1";
            this.Text = "TSP parallel solver";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parallelCountNumeric)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordsDataGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button loadFile_button;
        private System.Windows.Forms.Label loadFileLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton cutRadioButton;
        private System.Windows.Forms.RadioButton bruteForceRadioButton;
        private System.Windows.Forms.Label solutionTypeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton oneThreadCPURadioButton;
        private System.Windows.Forms.RadioButton multiThreadCPURadioButton;
        private System.Windows.Forms.RadioButton multiThreadGPURadioButton;
        private System.Windows.Forms.NumericUpDown parallelCountNumeric;
        private System.Windows.Forms.Button clearFormButton;
        private System.Windows.Forms.Button runSolverButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox graphPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox imageSizeCoef;
        private System.Windows.Forms.Button resizeImageButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView coordsDataGrid;
        private System.Windows.Forms.TextBox taskNameTB;
        private System.Windows.Forms.TextBox taskTypeTB;
        private System.Windows.Forms.TextBox taskCommentTB;
        private System.Windows.Forms.TextBox taskDimensionalTB;
        private System.Windows.Forms.TextBox taskEdgeWeightTypeTB;
        private System.Windows.Forms.TextBox taskDisplayDataTypeTB;
        private System.Windows.Forms.Button saveImageButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label objectiveFunctionLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCoord;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCoord;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label timeSolutionLabel;
        private System.Windows.Forms.TextBox roadTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveResultButton;
        private System.Windows.Forms.SaveFileDialog saveResultDialog;
    }
}

