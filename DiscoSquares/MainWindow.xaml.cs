using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

namespace DiscoSquares
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Validator _validator;
        public MainWindow()
        {
            _validator = new Validator();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var rows = int.Parse(RowsTextBox.Text);
                var cols = int.Parse(ColumnsTextBox.Text);
                var probability = int.Parse(ProbabilityTextBox.Text);
                var delay = int.Parse(DelayTextBox.Text);
                try
                {
                    _validator.ValidateData(rows, cols, probability, delay);
                    var sim = new Simulation(rows, cols, probability, delay);
                    sim.Show();
                }
                catch (FormatException ex)
                {
                    ErrorTextBlock.Text = ex.Message;
                }
                
            }
            catch (FormatException ex)
            {
                ErrorTextBlock.Text = "Incorrect format - input data must be of integer type.";
            }
        }
    }
}
