namespace ProyectoOFI.Reportes
{
    partial class Dashboard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.PlDatos = new System.Windows.Forms.Panel();
            this.PlTotal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblSN = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblSM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblAnalisis = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chartKilos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.PlGrafico = new System.Windows.Forms.Panel();
            this.LblGrafico = new System.Windows.Forms.Label();
            this.PlDatos.SuspendLayout();
            this.PlTotal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKilos)).BeginInit();
            this.PlGrafico.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlDatos
            // 
            this.PlDatos.Controls.Add(this.panel3);
            this.PlDatos.Controls.Add(this.panel2);
            this.PlDatos.Controls.Add(this.panel1);
            this.PlDatos.Controls.Add(this.PlTotal);
            this.PlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlDatos.Location = new System.Drawing.Point(0, 0);
            this.PlDatos.Name = "PlDatos";
            this.PlDatos.Size = new System.Drawing.Size(1777, 105);
            this.PlDatos.TabIndex = 0;
            // 
            // PlTotal
            // 
            this.PlTotal.BackColor = System.Drawing.Color.White;
            this.PlTotal.Controls.Add(this.LblTotal);
            this.PlTotal.Controls.Add(this.label1);
            this.PlTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlTotal.Location = new System.Drawing.Point(0, 0);
            this.PlTotal.Name = "PlTotal";
            this.PlTotal.Size = new System.Drawing.Size(264, 105);
            this.PlTotal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total de Kilos:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTotal
            // 
            this.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(0, 36);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(264, 69);
            this.LblTotal.TabIndex = 0;
            this.LblTotal.Text = "--";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LblSN);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(264, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 105);
            this.panel1.TabIndex = 1;
            // 
            // LblSN
            // 
            this.LblSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblSN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSN.Location = new System.Drawing.Point(0, 36);
            this.LblSN.Name = "LblSN";
            this.LblSN.Size = new System.Drawing.Size(264, 69);
            this.LblSN.TabIndex = 0;
            this.LblSN.Text = "--";
            this.LblSN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total de Kilos Secado Natural:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LblSM);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(528, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 105);
            this.panel2.TabIndex = 2;
            // 
            // LblSM
            // 
            this.LblSM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblSM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSM.Location = new System.Drawing.Point(0, 36);
            this.LblSM.Name = "LblSM";
            this.LblSM.Size = new System.Drawing.Size(264, 69);
            this.LblSM.TabIndex = 0;
            this.LblSM.Text = "--";
            this.LblSM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 36);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total de Kilos Secado Mecánico:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.LblAnalisis);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(792, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 105);
            this.panel3.TabIndex = 3;
            // 
            // LblAnalisis
            // 
            this.LblAnalisis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAnalisis.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAnalisis.Location = new System.Drawing.Point(0, 36);
            this.LblAnalisis.Name = "LblAnalisis";
            this.LblAnalisis.Size = new System.Drawing.Size(264, 69);
            this.LblAnalisis.TabIndex = 0;
            this.LblAnalisis.Text = "--";
            this.LblAnalisis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(264, 36);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total de Kilos Analizados:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartKilos
            // 
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            chartArea1.Name = "ChartArea1";
            this.chartKilos.ChartAreas.Add(chartArea1);
            this.chartKilos.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartKilos.Legends.Add(legend1);
            this.chartKilos.Location = new System.Drawing.Point(0, 28);
            this.chartKilos.Name = "chartKilos";
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            series1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartKilos.Series.Add(series1);
            this.chartKilos.Size = new System.Drawing.Size(525, 393);
            this.chartKilos.TabIndex = 1;
            this.chartKilos.Text = "QQs por Área";
            title1.DockedToChartArea = "ChartArea1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            title1.Name = "QQs por área";
            this.chartKilos.Titles.Add(title1);
            // 
            // PlGrafico
            // 
            this.PlGrafico.Controls.Add(this.chartKilos);
            this.PlGrafico.Controls.Add(this.LblGrafico);
            this.PlGrafico.Location = new System.Drawing.Point(3, 111);
            this.PlGrafico.Name = "PlGrafico";
            this.PlGrafico.Size = new System.Drawing.Size(525, 421);
            this.PlGrafico.TabIndex = 2;
            // 
            // LblGrafico
            // 
            this.LblGrafico.BackColor = System.Drawing.Color.White;
            this.LblGrafico.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrafico.Location = new System.Drawing.Point(0, 0);
            this.LblGrafico.Name = "LblGrafico";
            this.LblGrafico.Size = new System.Drawing.Size(525, 28);
            this.LblGrafico.TabIndex = 0;
            this.LblGrafico.Text = "Gráfico de kilos por área";
            this.LblGrafico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlGrafico);
            this.Controls.Add(this.PlDatos);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1777, 819);
            this.PlDatos.ResumeLayout(false);
            this.PlTotal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartKilos)).EndInit();
            this.PlGrafico.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlDatos;
        private System.Windows.Forms.Panel PlTotal;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblAnalisis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblSM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKilos;
        private System.Windows.Forms.Panel PlGrafico;
        private System.Windows.Forms.Label LblGrafico;
    }
}
