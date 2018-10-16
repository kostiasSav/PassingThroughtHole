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
    public class SizesInput
    {
        public void Input(string holeType, string passingObjectType, ref Grid objectGrid, ref Grid holeGrig)
        {
            if(holeType == "Round")
            {
                RoundHole roundHole = new RoundHole();
                //roundHole.RoundHoleDiameter=
            }
        }
    }
    public class ChekerPassingPossibility
    {
        public bool CheckPassingPossibility(string holeType, string passingObjectType, ref Grid objectGrid, ref Grid holeGrig)
        {
            if (holeType == "Round")
            {
                return CheckPassingPossibilityOfObjectThroughRoundHole();
            }
            else if (holeType == "Square")
            {
                return CheckPassingPossibilityOfObjectThroughSquareHole();
            }
            else
            {
                return false;
            }
        }

        private bool CheckPassingPossibilityOfObjectThroughRoundHole(double[] objectSizes, double roundHoleDiameter)
        {
            Array.Sort(objectSizes);
            if (objectSizes[0] <= roundHoleDiameter && objectSizes[1] <= roundHoleDiameter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckPassingPossibilityOfObjectThroughSquareHole(double[] objectSizes, double[] squareHoleSizes)
        {
            Array.Sort(objectSizes);
            Array.Sort(squareHoleSizes);
            if (objectSizes[0] <= squareHoleSizes[0] && objectSizes[1] <= squareHoleSizes[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class RoundHole
    {
        internal double RoundHoleDiameter;
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
        private double[] BallObjectSizes = new double[2];
    }

    public class GeneratorOfInputFields
    {
        public void GenerateInputFieldsForObject(string passingObjectType, ref Grid objectGrid)
        {
            objectGrid.Children.Clear();
            if (passingObjectType == "Cubic")
            {
                GenerateInputFieldsForCubicObject(objectGrid);
            }
            else if (passingObjectType == "Cylindrical")
            {
                GenerateInputFieldsForCylindricalObject(objectGrid);
            }
            else if (passingObjectType == "Ball")
            {
                GenerateInputFieldsForBallObject(objectGrid);
            }
        }
        public void GenerateInputFieldsForHole(string holeType, ref Grid holeGrid)
        {
            holeGrid.Children.Clear();
            if (holeType == "Round")
            {
                GenerateInputFieldsForRoundHole(holeGrid);
            }
            else if (holeType == "Square")
            {
                GenerateInputFieldsForSquareHole(holeGrid);
            }
        }

        private void GenerateInputFieldsForCubicObject(Grid objectGrid)
        {
            TextBox heightTextBox = new TextBox();
            objectGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 1);
            Grid.SetRow(heightTextBox, 0);
            TextBox widthTextBox = new TextBox();
            objectGrid.Children.Add(widthTextBox);
            Grid.SetColumn(widthTextBox, 1);
            Grid.SetRow(widthTextBox, 1);
            TextBox lenghtTextBox = new TextBox();
            objectGrid.Children.Add(lenghtTextBox);
            Grid.SetColumn(lenghtTextBox, 1);
            Grid.SetRow(lenghtTextBox, 2);
            Label heightLabel = new Label
            {
                Content = "Enter height"
            };
            objectGrid.Children.Add(heightLabel);
            Grid.SetColumn(heightLabel, 0);
            Grid.SetRow(heightLabel, 0);
            Label widthLabel = new Label
            {
                Content = "Enter width"
            };
            objectGrid.Children.Add(widthLabel);
            Grid.SetColumn(widthLabel, 0);
            Grid.SetRow(widthLabel, 1);
            Label lenghtLabel = new Label
            {
                Content = "Enter lenght"
            };
            objectGrid.Children.Add(lenghtLabel);
            Grid.SetColumn(lenghtLabel, 0);
            Grid.SetRow(lenghtLabel, 2);
        }

        private void GenerateInputFieldsForCylindricalObject(Grid objectGrid)
        {
            TextBox heightTextBox = new TextBox();
            objectGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 1);
            Grid.SetRow(heightTextBox, 0);
            TextBox diameterTextBox = new TextBox();
            objectGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 1);
            Grid.SetRow(diameterTextBox, 1);
            Label heightLabel = new Label
            {
                Content = "Enter height"
            };
            objectGrid.Children.Add(heightLabel);
            Grid.SetColumn(heightLabel, 0);
            Grid.SetRow(heightLabel, 0);
            Label diameterLabel = new Label
            {
                Content = "Enter diameter"
            };
            objectGrid.Children.Add(diameterLabel);
            Grid.SetColumn(diameterLabel, 0);
            Grid.SetRow(diameterLabel, 1);
        }

        private void GenerateInputFieldsForBallObject(Grid objectGrid)
        {
            TextBox diameterTextBox = new TextBox();
            objectGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 1);
            Grid.SetRow(diameterTextBox, 0);
            Label diameterLabel = new Label
            {
                Content = "Enter diameter"
            };
            objectGrid.Children.Add(diameterLabel);
            Grid.SetColumn(diameterLabel, 0);
            Grid.SetRow(diameterLabel, 0);
        }

        private void GenerateInputFieldsForRoundHole(Grid holeGrid)
        {
            TextBox diameterTextBox = new TextBox();
            holeGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 1);
            Grid.SetRow(diameterTextBox, 0);
            Label diameterLabel = new Label
            {
                Content = "Enter diameter"
            };
            holeGrid.Children.Add(diameterLabel);
            Grid.SetColumn(diameterLabel, 0);
            Grid.SetRow(diameterLabel, 0);
        }

        private void GenerateInputFieldsForSquareHole(Grid holeGrid)
        {
            TextBox heightTextBox = new TextBox();
            holeGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 1);
            Grid.SetRow(heightTextBox, 0);
            TextBox widthTextBox = new TextBox();
            holeGrid.Children.Add(widthTextBox);
            Grid.SetColumn(widthTextBox, 1);
            Grid.SetRow(widthTextBox, 1);
            Label heightLabel = new Label
            {
                Content = "Enter height"
            };
            holeGrid.Children.Add(heightLabel);
            Grid.SetColumn(heightLabel, 0);
            Grid.SetRow(heightLabel, 0);
            Label widthLabel = new Label
            {
                Content = "Enter width"
            };
            holeGrid.Children.Add(widthLabel);
            Grid.SetColumn(widthLabel, 0);
            Grid.SetRow(widthLabel, 1);
        }
    }
}
