using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TSPSolverGPU
{
    public partial class Form1 : Form
    {
        private TSPSolveResult solveResult;
        private TSPTask tspTask;
        private Coord[] _coords = null;
        public Form1()
        {
            InitializeComponent();
        }

        #region CustomMethods  

        /// <summary>
        /// Update form using new data.
        /// </summary>
        private void UpdateData()
        {
            if (tspTask == null || tspTask.Coords == null || tspTask.Coords.Length == 0)
            {
                loadFileLabel.Text = "Данные не загружены";
                loadFileLabel.ForeColor = Color.Black;
            }
            parallelCountNumeric.Value = 1;
            imageSizeCoef.Text = 1.ToString();
            objectiveFunctionLabel.Text = "Минимальное значение целевой функции: NULL";
            roadTextBox.Text = null;
            taskNameTB.Text = tspTask.TaskName;
            taskTypeTB.Text = tspTask.Type;
            taskCommentTB.Text = tspTask.Comment;
            taskDimensionalTB.Text = tspTask.Dimension.ToString();
            taskEdgeWeightTypeTB.Text = tspTask.EdgeWeightType;
            taskDisplayDataTypeTB.Text = tspTask.DisplayDataType;
            coordsDataGrid.Rows.Clear();
            if (tspTask.Coords != null)
            {
                for (int i = 0; i < tspTask.Coords.Length; i++)
                {
                    float x = tspTask.Coords[i].X;
                    float y = tspTask.Coords[i].Y;
                    coordsDataGrid.Rows.Add($"{x:f10}", $"{y:f10}");
                }
            }

            coordsDataGrid.Refresh();
            oneThreadCPURadioButton.Checked = true;
            cutRadioButton.Checked = true;
            solveResult = new TSPSolveResult();
            if (_coords != null)
            {
                DrawImage();
            }
            else
            {
                Image oldImage = graphPictureBox.Image;
                graphPictureBox.Image = null;
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
        }

        /// <summary>
        /// Draws the image.
        /// </summary>
        private void DrawImage()
        {
            TransformToPositiveCoords(_coords);
            int radius = 5;
            double resize = 1;
            if (!CheckDrawInputData(out resize))
            {
                return;
            }

            float height = 0, width = 0;
            for (int i = 0; i < _coords.Length; i++)
            {
                if (_coords[i].X > height)
                {
                    height = _coords[i].X;
                }

                if (_coords[i].Y > width)
                {
                    width = _coords[i].Y;
                }
            }
            height = (int)(height* resize);
            width = (int)(width*resize);
            height *= 1.1f;
            width *= 1.1f;
            if (Convert.ToInt32(height) >= 65535 || Convert.ToInt32(width) >= 65535)
            {
                MessageBox.Show("Слишком большой размер масштабирования.\nОтрисовка изображения невозможна");
                return;
            }
            Bitmap bm = new Bitmap(Convert.ToInt32(height), Convert.ToInt32(width));
            Graphics gfx = Graphics.FromImage(bm);

            gfx.FillRectangle(new SolidBrush(Color.White), 0, 0, height, width);

            DrawPoints(radius, resize, gfx, new SolidBrush(Color.Black));

            if (solveResult.Route != null)
            {
                DrawLines(resize, gfx, new Pen(Color.Green, 2));
            }

            Image oldImage = graphPictureBox.Image;
            graphPictureBox.Image = bm;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        /// <summary>
        /// Отрисовка узлов графа
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="resize">The resize.</param>
        /// <param name="graph">The graph.</param>
        /// <param name="pointBrush">The point brush.</param>
        private void DrawPoints(int radius, double resize, Graphics graph, SolidBrush pointBrush)
        {
            foreach (var v in _coords)
            {
                PrintCircle(graph, pointBrush, new Coord((int)(v.X * resize), (int)(v.Y * resize)), radius);
            }
        }

        /// <summary>
        /// Рисование круга по координатам центра.
        /// </summary>
        /// <param name="drawingArea">The drawing area.</param>
        /// <param name="brushToUse">The brush to use.</param>
        /// <param name="center">The center.</param>
        /// <param name="radius">The radius.</param>
        private void PrintCircle(Graphics drawingArea, Brush brushToUse, Coord center, int radius)
        {
            Rectangle rect = new Rectangle((int)(center.X - radius), (int)(center.Y - radius), radius * 2, radius * 2);
            drawingArea.FillEllipse(brushToUse, rect);
        }

        /// <summary>
        /// Отрисовка найденного маршрута
        /// </summary>
        /// <param name="resize">The resize.</param>
        /// <param name="graph">The graph.</param>
        /// <param name="penToLines">The pen to lines.</param>
        private void DrawLines(double resize, Graphics graph, Pen penToLines)
        {
            for (int i = 0; i < solveResult.Route.Length - 1; i++)
            {
                int from = solveResult.Route[i];
                int to = Convert.ToInt32(solveResult.Route[i + 1]);
                graph.DrawLine(penToLines, (int)(_coords[from].X * resize), (int)(_coords[from].Y * resize), (int)(_coords[to].X * resize), (int)(_coords[to].Y * resize));
            }
        }

        /// <summary>
        /// Проверка входных данных для отрисовки графа
        /// </summary>
        /// <param name="resize">The resize.</param>
        /// <returns></returns>
        private bool CheckDrawInputData(out double resize)
        {
            bool canDraw = true;
            if (!double.TryParse(imageSizeCoef.Text.Replace(".",","), out resize))
            {
                MessageBox.Show("Некорретное значение коэффициента масштабирования!\nКоэффициент принят как <1>");
                resize = 1;
                imageSizeCoef.Text = 1.ToString();
            }
            else if (resize <= 0)
            {
                MessageBox.Show("Некорретное значение коэффициента масштабирования!\nКоэффициент принят как <1>");
                resize = 1;
                imageSizeCoef.Text = 1.ToString();
            }
            if (_coords == null || _coords.Length == 0)
            {
                MessageBox.Show("Нет данных для отображения!");
                canDraw = false;
            }
            return canDraw;
        }

        /// <summary>
        /// Проверка исходных данных на отрицательные координаты точек. Сдвиг, при необходимости
        /// </summary>
        /// <param name="coords">Points array</param>
        private void TransformToPositiveCoords(Coord[] coords)
        {
            float minX = 0;
            float minY = 0;
            for (int i = 0; i < coords.Length; i++)
            {
                if (coords[i].X < minX)
                {
                    minX = coords[i].X;
                }

                if (coords[i].Y < minY)
                {
                    minY = coords[i].Y;
                }
            }
            if (minX != 0 || minY != 0)
            {
                for (int i = 0; i < coords.Length; i++)
                {
                    coords[i].X += Math.Abs(minX);
                    coords[i].Y += Math.Abs(minY);
                }
            }
        }

        #endregion

        private void loadFile_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                if (File.Exists(path))
                {
                    loadFileLabel.Text = "Файл успешно загружен";
                    loadFileLabel.ForeColor = Color.Green;
                }
                else
                {
                    loadFileLabel.Text = "Загрузка файла не удалась";
                    loadFileLabel.ForeColor = Color.Red;
                }
                tspTask = TSPFileReader.Parse(path);
                _coords = tspTask.Coords;
                UpdateData();
            }
        }

        private void clearFormButton_Click(object sender, EventArgs e)
        {
            tspTask = new TSPTask();
            _coords = null;
            UpdateData();
        }

        private void cutRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            parallelCountNumeric.Enabled = true;
        }

        private void bruteForceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            parallelCountNumeric.Enabled = false;
        }


        private void runSolverButton_Click(object sender, EventArgs e)
        {
            Coord[] coords = ReadCoordsFromDataGrid(coordsDataGrid);
            if (coords == null)
            {
                MessageBox.Show("Не указаны координаты узлов!");
                return;
            }
            if (coords.Length == 0 || coords.Length == 1)
            {
                MessageBox.Show("Нельзя построить решение при одном узле!");
                return;
            }
            TransformToPositiveCoords(coords);
            TSPInitialData initialData = new TSPInitialData(coords);
            if (cutRadioButton.Checked)
            {
                StartCutSolve(initialData);
            }
            else if (bruteForceRadioButton.Checked)
            {
                StartBruteForceSolve(initialData);
            }
            SetResultData(solveResult);
            _coords = coords;
            DrawImage();
        }

        private void StartBruteForceSolve(TSPInitialData initialData)
        {
            if (oneThreadCPURadioButton.Checked)
            {
                solveResult = TSPBruteForceSolver.Solve(initialData, SolveMode.CPU);
            }
            else if (multiThreadCPURadioButton.Checked)
            {
                solveResult = TSPBruteForceSolver.Solve(initialData, SolveMode.ParallelCPU);
            }
            else if (multiThreadGPURadioButton.Checked)
            {
                solveResult = TSPBruteForceSolver.Solve(initialData, SolveMode.ParallelGPU);
            }
        }

        private void StartCutSolve(TSPInitialData initialData)
        {
            if (oneThreadCPURadioButton.Checked)
            {
                solveResult = TSPCutSolver.Solve(initialData, SolveMode.CPU, Convert.ToInt32(parallelCountNumeric.Value));
            }
            else if (multiThreadCPURadioButton.Checked)
            {
                solveResult = TSPCutSolver.Solve(initialData, SolveMode.ParallelCPU, Convert.ToInt32(parallelCountNumeric.Value));
            }
            else if (multiThreadGPURadioButton.Checked)
            {
                solveResult = TSPCutSolver.Solve(initialData, SolveMode.ParallelGPU, Convert.ToInt32(parallelCountNumeric.Value));
            }
        }

        private Coord[] ReadCoordsFromDataGrid(DataGridView grid)
        {
            try
            {
                Coord[] coords = new Coord[grid.Rows.Count - 1];
                for (int i = 0; i < grid.Rows.Count - 1; i++)
                {
                    float x = Convert.ToSingle(grid[0, i].Value);
                    float y = Convert.ToSingle(grid[1, i].Value);
                    coords[i] = new Coord(x, y);
                }
                if (coords.Length < 2)
                {
                    MessageBox.Show("Неккорретно указаны координаты!");
                    return null;
                }
                return coords;
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденная ошибка!\nНе удалось считать координаты узлов.\nПроверьте ввод!");
                return null;
            }
        }

        private void SetResultData(TSPSolveResult res)
        {
            objectiveFunctionLabel.Text = $"Минимальное значение целевой функции: {res.Result:f5}";
            roadTextBox.Text = res.StringRoute;
            timeSolutionLabel.Text = $"Время последнего выполнения: {res.EllapsedTime / 1000.0:f3} с.";
        }

        private void coordsDataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; (i <= (coordsDataGrid.Rows.Count - 1)); i++)
            {
                coordsDataGrid.Rows[i].HeaderCell.Value = (i).ToString();
            }
        }

        private void resizeImageButton_Click(object sender, EventArgs e)
        {
            if(graphPictureBox.Image == null)
            {
                MessageBox.Show("Нечего масштабировать!");
                return;
            }
            DrawImage();
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            if (graphPictureBox.Image == null)
            {
                MessageBox.Show("Нет изображения для сохранения");
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName;
                graphPictureBox.Image.Save(path, ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// Save TSPtask result to .txt file. Get data from current form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveResultButton_Click(object sender, EventArgs e)
        {
            if (solveResult.Result == null)
            {
                MessageBox.Show("Нет результата для сохранения");
                return;
            }
            if (saveResultDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveResultDialog.FileName;
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"NAME: {taskNameTB.Text}\n");
                    sb.Append($"COMMENT: {taskCommentTB.Text}\n");
                    sb.Append($"TYPE: {taskTypeTB.Text}\n");
                    sb.Append($"DIMENSION: {solveResult.Route.Length - 1}\n,");
                    sb.Append($"EDGE_WEIGHT_TYPE: {taskEdgeWeightTypeTB.Text}\n");
                    sb.Append($"DISPLAY_DATA_TYPE: {taskDisplayDataTypeTB.Text}\n");
                    sb.Append("NODE_COORD_SECTION: \n");
                    for(int i = 0; i<coordsDataGrid.Rows.Count; i++)
                        sb.Append($"{i + 1} {coordsDataGrid[0, i].Value} {coordsDataGrid[1, i].Value}\n");
                    sb.Append($"\nTASK_RESULT: {solveResult.Result}\n");
                    sb.Append("RESULT ROUTE: \n");
                    for(int i = 0; i<solveResult.Route.Length;i++)
                    {
                        sb.Append($"{i + 1} {solveResult.Route[i]}\n");
                    }
                    streamWriter.Write(sb);
                }
            }
        }
    }
}
