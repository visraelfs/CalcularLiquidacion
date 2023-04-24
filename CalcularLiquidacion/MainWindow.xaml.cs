using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalcularLiquidacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            decimal baseSalarioMinimo = decimal.Parse(txtSalarioMinimo.Text);

            int aniosTrabajados = DateTime.Parse(txtFechaDespido.Text).Year - DateTime.Parse(txtFechaIngreso.Text).Year;

            decimal sueldoMensual = Decimal.Parse(txtSueldoMensual.Text);

            decimal SDI = sueldoMensual / 30;

            decimal aguinaldo = 15 * SDI;

            decimal aguinaldoDiario = aguinaldo / 365;

            decimal primaVacacional = (diasDeVacacionesPorAño(aniosTrabajados) * SDI ) * (decimal)0.25;

            decimal privaVacacionalDiaria = primaVacacional / 365;

            decimal SMI = (SDI + aguinaldoDiario + privaVacacionalDiaria) * 30;

            decimal tresMesesSalario = SMI * 3;

            decimal veinteDiasPorAnio = (20 * aniosTrabajados) * SDI;

            int diasPorPrimaVacacional = 12 * aniosTrabajados;

            decimal primaAntiguedad = (baseSalarioMinimo * 2) < SDI ? (baseSalarioMinimo * 2) * diasPorPrimaVacacional : SDI * diasPorPrimaVacacional;

            decimal total = tresMesesSalario + veinteDiasPorAnio + primaAntiguedad;

            txtTotal.Text = Math.Round(total,2).ToString();

        }


        private int diasDeVacacionesPorAño(int aniosTrabajados)
        {
            int diasCorrespondientes;
            switch (aniosTrabajados)
            {
                case 0:
                case 1:
                    diasCorrespondientes = 12;
                    break;
                case 2:
                    diasCorrespondientes = 14;
                    break;
                case 3:
                    diasCorrespondientes = 16;
                    break;
                case 4:
                    diasCorrespondientes = 18;
                    break;
                case 5:
                    diasCorrespondientes = 20;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    diasCorrespondientes = 22;
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    diasCorrespondientes = 24;
                    break;

                default:
                    throw new Exception("No se pudo calcular el número de días de vacaciones");

            }

            return diasCorrespondientes;
        }

        private void BtnFechaIngreso_Click(object sender, RoutedEventArgs e)
        {
            cdFechaIngreso.Visibility = Visibility.Visible;
        }

        private void CdFechaIngreso_SelectedDatesChanged(object sender, RoutedEventArgs e)
        {
            txtFechaIngreso.Text = DateTime.Parse(e.Source.ToString()).ToString("yyyy-MM-dd");

            cdFechaIngreso.Visibility = Visibility.Hidden;
        }

        private void CdFechaDespido_SelectedDatesChanged(object sender, RoutedEventArgs e)
        {
            txtFechaDespido.Text = DateTime.Parse(e.Source.ToString()).ToString("yyyy-MM-dd");

            cdFechaDespido.Visibility = Visibility.Hidden;
        }

        private void BtnFechaDespido_Click(object sender, RoutedEventArgs e)
        {
            cdFechaDespido.Visibility = Visibility.Visible;
        }
    }
}
