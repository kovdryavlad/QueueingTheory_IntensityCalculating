namespace QueuingTheoryLaba2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зчитатиВыдлікиЧасуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зчитатиІнтервалиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерійКолмогороваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.критерійПірсонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.інтенсивність1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.інтенсивністьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обєднатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.alphatextBox = new System.Windows.Forms.TextBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.критерійКолмогороваToolStripMenuItem,
            this.критерійПірсонаToolStripMenuItem,
            this.інтенсивність1ToolStripMenuItem,
            this.інтенсивністьToolStripMenuItem1,
            this.обєднатиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зчитатиВыдлікиЧасуToolStripMenuItem,
            this.зчитатиІнтервалиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // зчитатиВыдлікиЧасуToolStripMenuItem
            // 
            this.зчитатиВыдлікиЧасуToolStripMenuItem.Name = "зчитатиВыдлікиЧасуToolStripMenuItem";
            this.зчитатиВыдлікиЧасуToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.зчитатиВыдлікиЧасуToolStripMenuItem.Text = "Зчитати відліки часу";
            this.зчитатиВыдлікиЧасуToolStripMenuItem.Click += new System.EventHandler(this.ЗчитатиВыдлікиЧасуToolStripMenuItem_Click);
            // 
            // зчитатиІнтервалиToolStripMenuItem
            // 
            this.зчитатиІнтервалиToolStripMenuItem.Name = "зчитатиІнтервалиToolStripMenuItem";
            this.зчитатиІнтервалиToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.зчитатиІнтервалиToolStripMenuItem.Text = "Зчитати інтервали";
            this.зчитатиІнтервалиToolStripMenuItem.Click += new System.EventHandler(this.ЗчитатиІнтервалиToolStripMenuItem_Click);
            // 
            // критерійКолмогороваToolStripMenuItem
            // 
            this.критерійКолмогороваToolStripMenuItem.Name = "критерійКолмогороваToolStripMenuItem";
            this.критерійКолмогороваToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.критерійКолмогороваToolStripMenuItem.Text = "Критерій Колмогорова";
            this.критерійКолмогороваToolStripMenuItem.Click += new System.EventHandler(this.КритерійКолмогороваToolStripMenuItem_Click);
            // 
            // критерійПірсонаToolStripMenuItem
            // 
            this.критерійПірсонаToolStripMenuItem.Name = "критерійПірсонаToolStripMenuItem";
            this.критерійПірсонаToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.критерійПірсонаToolStripMenuItem.Text = "Критерій Пірсона";
            this.критерійПірсонаToolStripMenuItem.Click += new System.EventHandler(this.КритерійПірсонаToolStripMenuItem_Click);
            // 
            // інтенсивність1ToolStripMenuItem
            // 
            this.інтенсивність1ToolStripMenuItem.Name = "інтенсивність1ToolStripMenuItem";
            this.інтенсивність1ToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.інтенсивність1ToolStripMenuItem.Text = "Інтенсивність 1";
            this.інтенсивність1ToolStripMenuItem.Click += new System.EventHandler(this.Інтенсивність1ToolStripMenuItem_Click);
            // 
            // інтенсивністьToolStripMenuItem1
            // 
            this.інтенсивністьToolStripMenuItem1.Name = "інтенсивністьToolStripMenuItem1";
            this.інтенсивністьToolStripMenuItem1.Size = new System.Drawing.Size(189, 20);
            this.інтенсивністьToolStripMenuItem1.Text = "Інтенсивність 2(кусково-стала)";
            this.інтенсивністьToolStripMenuItem1.Click += new System.EventHandler(this.ІнтенсивністьToolStripMenuItem1_Click);
            // 
            // обєднатиToolStripMenuItem
            // 
            this.обєднатиToolStripMenuItem.Name = "обєднатиToolStripMenuItem";
            this.обєднатиToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.обєднатиToolStripMenuItem.Text = "Об\'єднати";
            this.обєднатиToolStripMenuItem.Click += new System.EventHandler(this.обєднатиToolStripMenuItem_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "tau";
            chartArea1.AxisY.Title = "probability";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 27);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "PointWidth=1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(571, 300);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(589, 27);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(199, 274);
            this.logTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "alpha =";
            // 
            // alphatextBox
            // 
            this.alphatextBox.Location = new System.Drawing.Point(663, 307);
            this.alphatextBox.Name = "alphatextBox";
            this.alphatextBox.Size = new System.Drawing.Size(100, 20);
            this.alphatextBox.TabIndex = 4;
            this.alphatextBox.Text = "0.05";
            // 
            // chart2
            // 
            chartArea2.AxisX.Title = "tau";
            chartArea2.AxisY.Title = "intensity";
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Location = new System.Drawing.Point(12, 333);
            this.chart2.Name = "chart2";
            series2.BorderColor = System.Drawing.Color.Black;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.SteelBlue;
            series2.CustomProperties = "PointWidth=1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(571, 300);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 642);
            this.Controls.Add(this.alphatextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зчитатиВыдлікиЧасуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зчитатиІнтервалиToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox alphatextBox;
        private System.Windows.Forms.ToolStripMenuItem критерійКолмогороваToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem критерійПірсонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem інтенсивність1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem інтенсивністьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обєднатиToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

