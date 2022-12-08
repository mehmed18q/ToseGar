using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE_ToseGar;
using BLL_ToseGar;

namespace ToseGar_Help_Source
{
    public partial class Charts_Compile : UserControl
    {
        public Charts_Compile()
        {
            InitializeComponent();
        }
        Chart_Sell_BLL BLL = new Chart_Sell_BLL();


        private void Charts_Compile_Load(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); }
            try
            {
                List<double> money = BLL.Read();
                chart1.Palette = ChartColorPalette.SeaGreen;

                for (int i = 0; i < money.Count; i++)
                {
                    chart1.Series["Sell"].Points.AddXY(1384 + i, money[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }















        private void guna2Button6_Click(object sender, EventArgs e)
        {
            BLL.Create(new Chart_Sell_BE() { Sell = Convert.ToDouble(textBoxX1.Text) });

            foreach (var series in chart1.Series) { series.Points.Clear(); }
            try
            {
                List<double> money = BLL.Read();
                chart1.Palette = ChartColorPalette.SeaGreen;

                for (int i = 0; i < money.Count; i++)
                {
                    chart1.Series["Sell"].Points.AddXY(1384 + i, money[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }






        private void guna2Button2_Click(object sender, EventArgs e)
        {

            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Column; }
            try
            {
                List<double> money = BLL.Read();
                chart1.Palette = ChartColorPalette.SeaGreen;

                for (int i = 0; i < money.Count; i++)
                {
                    chart1.Series["Sell"].Points.AddXY(1384 + i, money[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }

        }





        private void guna2Button4_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Spline; }
            try
            {
                List<double> money = BLL.Read();
                chart1.Palette = ChartColorPalette.SeaGreen;

                for (int i = 0; i < money.Count; i++)
                {
                    chart1.Series["Sell"].Points.AddXY(1384 + i, money[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Point; }
            try
            {
                List<double> money = BLL.Read();
                chart1.Palette = ChartColorPalette.SeaGreen;

                for (int i = 0; i < money.Count; i++)
                {
                    chart1.Series["Sell"].Points.AddXY(1384 + i, money[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series) { series.Points.Clear(); series.ChartType = SeriesChartType.Line; }
            try
            {
                List<double> money = BLL.Read();
                chart1.Palette = ChartColorPalette.SeaGreen;

                for (int i = 0; i < money.Count; i++)
                {
                    chart1.Series["Sell"].Points.AddXY(1384 + i, money[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }

       
    }
}
