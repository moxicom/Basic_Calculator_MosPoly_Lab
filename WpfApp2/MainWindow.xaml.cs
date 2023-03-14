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

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        double value = 0;
        string operation = "";
        bool operationSelected = false;
        private bool isToggled = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (operationSelected)
            {
                TransitionTextBox.Text = ResultTextBox.Text + operation;
                ResultTextBox.Text = "";
                operationSelected = false;
                

            }

            Button button = (Button)sender;
            ResultTextBox.Text += button.Content.ToString();
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (ResultTextBox.Text != "") { // if there is a number in the textbox
                if (value != 0 && TransitionTextBox.Text != "")
                {
                    EqualsButton_Click(sender, e);
                }
                
                operation = button.Content.ToString();
                TransitionTextBox.Text = ResultTextBox.Text + operation;
                value = double.Parse(ResultTextBox.Text);
                operationSelected = true;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double secondValue = double.Parse(ResultTextBox.Text);

            switch (operation)
            {
                case "+":
                    ResultTextBox.Text = (value + secondValue).ToString();
                    if(SwitchHistoryCheckBox.IsChecked==true)
                        HistoryListBox.Items.Add(value.ToString() + " + " + secondValue.ToString() + "\n = " + ResultTextBox.Text);
                    break;
                case "-":
                    ResultTextBox.Text = (value - secondValue).ToString();
                    if (SwitchHistoryCheckBox.IsChecked == true)
                        HistoryListBox.Items.Add(value.ToString() + " - " + secondValue.ToString() + "\n = " + ResultTextBox.Text);
                    break;
                case "*":
                    ResultTextBox.Text = (value * secondValue).ToString();
                    if (SwitchHistoryCheckBox.IsChecked == true)
                        HistoryListBox.Items.Add(value.ToString() + " * " + secondValue.ToString() + "\n = " + ResultTextBox.Text);
                    break;
                case "/":
                    if (secondValue == 0)
                    {
                        MessageBox.Show("Infinity");
                    }
                    else
                    {
                        ResultTextBox.Text = (value / secondValue).ToString();
                        if (SwitchHistoryCheckBox.IsChecked == true)
                            HistoryListBox.Items.Add(value.ToString() + " / " + secondValue.ToString() + "\n = " + ResultTextBox.Text);
                    }
                    break;
                default:
                    break;
            }
            TransitionTextBox.Text = "";
            value = double.Parse(ResultTextBox.Text);
            operation = "";
            operationSelected = false;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "";
            TransitionTextBox.Text = "";
            value = 0;
            operation = "";
            operationSelected = false;
        }

        private void CEButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "";
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultTextBox.Text.Length > 0)
            {
                ResultTextBox.Text = ResultTextBox.Text.Remove(ResultTextBox.Text.Length - 1);
            }
        }

        private void DotButton_CLick(object sender, RoutedEventArgs e)
        {
            if (!ResultTextBox.Text.Contains(","))
            {
                ResultTextBox.Text += ",";
            }
        }


        private void HistoryRadioButton_Click(object sender, RoutedEventArgs e)
        {
            if(isToggled) // если выключили
            {
                HistoryListBox.Visibility = Visibility.Hidden;
                BlackBGRectangle.Visibility = Visibility.Hidden;
                HistoryBtnsGrid.Visibility = Visibility.Hidden;
                HistoryBtnsGrid.IsEnabled= false;
                //SwitchHistoryCheckBox.Visibility = Visibility.Hidden;
                //DeleteRecentlyHistButton.Visibility = Visibility.Hidden;
                //ClearHistoryButton.Visibility = Visibility.Hidden;
                HistoryRadioButton.IsChecked = false;
                isToggled = false;
            }
            else    // если включили
            {
                HistoryListBox.Visibility = Visibility.Visible;
                HistoryListBox.IsEnabled = true;
                BlackBGRectangle.Visibility = Visibility.Visible;
                HistoryBtnsGrid.Visibility = Visibility.Visible;
                HistoryBtnsGrid.IsEnabled = true;

                isToggled = true;
            }
        }




        private void DeleteRecentlyHistButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HistoryListBox.Items.Remove(HistoryListBox.Items[HistoryListBox.Items.Count - 1]);
            }
            catch { }
        }

        private void ClearHistoryButton_Click(Object sender, RoutedEventArgs e)
        {
            HistoryListBox.Items.Clear();
        }

    }
}
