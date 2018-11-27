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
using PossibilityOfPassingLibrary;

namespace CheckingPassingPossibilityOfObjectThroughHole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TypesOfObjectsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeneratorOfInputFields inputFields = new GeneratorOfInputFields ();
            string passingObjectType = ((ComboBoxItem)(TypesOfObjectsComboBox.SelectedItem)).Content.ToString();
            inputFields.GenerateInputFieldsForObject(passingObjectType, ref ObjectGrid);
        }

        private void TypesOfHolesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeneratorOfInputFields inputFields = new GeneratorOfInputFields();
            string holeType = ((ComboBoxItem)(TypesOfHolesComboBox.SelectedItem)).Content.ToString();
            inputFields.GenerateInputFieldsForHole(holeType, ref HoleGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AnswerOutput answerOutput = new AnswerOutput();
                answerOutput.OutputAnswer(((ComboBoxItem)(TypesOfHolesComboBox.SelectedItem)).Content.ToString(), ((ComboBoxItem)(TypesOfObjectsComboBox.SelectedItem)).Content.ToString(), Label1);
            }
            catch(SizeException exception)
            {
                Label1.Content = exception.Message;
            }
        }
    }
}
