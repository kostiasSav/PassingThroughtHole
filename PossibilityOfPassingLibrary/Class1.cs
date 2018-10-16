using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PossibilityOfPassingLibrary
{
    public class ChekerPassingPossibility
    {
        public bool CheckPassingPossibility(Object hole, Object passingObject)
        {
            if (hole is RoundHole)
            {

            }
            return true;
        }
    }

    public class RoundHole
    {
        private double[] RoundHoleDiameter = new double[1];
    }

    public class SquareHole
    {
        private double[] SquareHoleSizes = new double[2];
    }
    
    public class CubicObject
    {
        private double[] CubeObjectSizes = new double[3];
    }

    public class CylindricalObject
    {
        private double[] CylindricalObjectSizes = new double[2];
    }

    public class BallObject
    {
        private double[] BallObjectDiameter = new double[1];
    }

    public class InputFields
    {
        public void GenerateInputFields(string passingObject, ref Grid mainWindowGrid)
        {
            if (passingObject == "Cubic")
            {
                GenerateInputFieldsForCubicObject(mainWindowGrid);
            }
            else if(passingObject == "Cylindrical")
            {
                GenerateInputFieldsForCylindricalObject(mainWindowGrid);
            }
            else if(passingObject == "Ball")
            {
                GenerateInputFieldsForBallObject(mainWindowGrid);
            }
            if(passingObject == "Round")
            {
                GenerateInputFieldsForRoundHole(mainWindowGrid);
            }
            else if(passingObject == "Square")
            {
                GenerateInputFieldsForSquareHole(mainWindowGrid);
            }
        }

        private void GenerateInputFieldsForCubicObject(Grid mainWindowGrid)
        {
            TextBox heightTextBox = new TextBox();
            mainWindowGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 2);
            Grid.SetRow(heightTextBox, 0);
            TextBox widthTextBox = new TextBox();
            mainWindowGrid.Children.Add(widthTextBox);
            Grid.SetColumn(widthTextBox, 2);
            Grid.SetRow(widthTextBox, 1);
            TextBox lenghtTextBox = new TextBox();
            mainWindowGrid.Children.Add(lenghtTextBox);
            Grid.SetColumn(lenghtTextBox, 2);
            Grid.SetRow(lenghtTextBox, 2);
            Label heightLabel = new Label
            {
                Content = "Enter height"
            };
            mainWindowGrid.Children.Add(heightLabel);
            Grid.SetColumn(heightLabel, 1);
            Grid.SetRow(heightLabel, 0);
            Label widthLabel = new Label
            {
                Content = "Enter width"
            };
            mainWindowGrid.Children.Add(widthLabel);
            Grid.SetColumn(widthLabel, 1);
            Grid.SetRow(widthLabel, 1);
            Label lenghtLabel = new Label
            {
                Content = "Enter lenght"
            };
            mainWindowGrid.Children.Add(lenghtLabel);
            Grid.SetColumn(lenghtLabel, 1);
            Grid.SetRow(lenghtLabel, 2);
        }

        private void GenerateInputFieldsForCylindricalObject(Grid mainWindowGrid)
        {
            TextBox heightTextBox = new TextBox();
            mainWindowGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 2);
            Grid.SetRow(heightTextBox, 0);
            TextBox diameterTextBox = new TextBox();
            mainWindowGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 2);
            Grid.SetRow(diameterTextBox, 1);
            Label heightLabel = new Label
            {
                Content = "Enter height"
            };
            mainWindowGrid.Children.Add(heightLabel);
            Grid.SetColumn(heightLabel, 1);
            Grid.SetRow(heightLabel, 0);
            Label diameterLabel = new Label
            {
                Content = "Enter diameter"
            };
            mainWindowGrid.Children.Add(diameterLabel);
            Grid.SetColumn(diameterLabel, 1);
            Grid.SetRow(diameterLabel, 1);
        }

        private void GenerateInputFieldsForBallObject(Grid mainWindowGrid)
        {
            TextBox diameterTextBox = new TextBox();
            mainWindowGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 2);
            Grid.SetRow(diameterTextBox, 0);
            Label diameterLabel = new Label
            {
                Content = "Enter diameter"
            };
            mainWindowGrid.Children.Add(diameterLabel);
            Grid.SetColumn(diameterLabel, 1);
            Grid.SetRow(diameterLabel, 0);
        }

        private void GenerateInputFieldsForRoundHole(Grid mainWindowGrid)
        {
            TextBox diameterTextBox = new TextBox();
            mainWindowGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 2);
            Grid.SetRow(diameterTextBox, 3);
            Label diameterLabel = new Label
            {
                Content = "Enter diameter"
            };
            mainWindowGrid.Children.Add(diameterLabel);
            Grid.SetColumn(diameterLabel, 1);
            Grid.SetRow(diameterLabel, 3);
        }

        private void GenerateInputFieldsForSquareHole(Grid mainWindowGrid)
        {
            TextBox heightTextBox = new TextBox();
            mainWindowGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 2);
            Grid.SetRow(heightTextBox, 3);
            TextBox widthTextBox = new TextBox();
            mainWindowGrid.Children.Add(widthTextBox);
            Grid.SetColumn(widthTextBox, 2);
            Grid.SetRow(widthTextBox, 4);
            Label heightLabel = new Label
            {
                Content = "Enter height"
            };
            mainWindowGrid.Children.Add(heightLabel);
            Grid.SetColumn(heightLabel, 1);
            Grid.SetRow(heightLabel, 3);
            Label widthLabel = new Label
            {
                Content = "Enter width"
            };
            mainWindowGrid.Children.Add(widthLabel);
            Grid.SetColumn(widthLabel, 1);
            Grid.SetRow(widthLabel, 4);
        }
    }
}
