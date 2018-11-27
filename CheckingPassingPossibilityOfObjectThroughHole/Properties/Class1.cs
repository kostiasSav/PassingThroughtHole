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
    internal class SizesInput
    {
        internal double[] Input(string holeType, string passingObjectType)
        {
            foreach(var holeSizeTextBox in GeneratorOfInputFields.HoleSizesTextBoxes)
            {
                if (Convert.ToDouble(holeSizeTextBox.Text) <= 0)
                {
                    throw new SizeException("Wrong format.");
                }
            }
            foreach (var ObjectSizeTextBox in GeneratorOfInputFields.ObjectSizesTextBoxes)
            {
                if (Convert.ToDouble(ObjectSizeTextBox.Text) <= 0)
                {
                    throw new SizeException("Wrong format. Size must be biger than 0");
                }
            }
            if (holeType == "Round")
            {
                RoundHole.RoundHoleDiameter = Convert.ToDouble(GeneratorOfInputFields.HoleSizesTextBoxes[0].Text);
            }
            else if (holeType == "Square")
            {
                SquareHole.SquareHoleSizes[0] = Convert.ToDouble(GeneratorOfInputFields.HoleSizesTextBoxes[0].Text);
                SquareHole.SquareHoleSizes[1] = Convert.ToDouble(GeneratorOfInputFields.HoleSizesTextBoxes[1].Text);

            }
            if (passingObjectType == "Cubic")
            {
                Array.Clear(CubicObject.CubeObjectSizes, 0, 2);
                CubicObject.CubeObjectSizes[0] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[0].Text);
                CubicObject.CubeObjectSizes[1] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[1].Text);
                CubicObject.CubeObjectSizes[2] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[2].Text);
                return CubicObject.CubeObjectSizes;
            }
            else if(passingObjectType == "Cylindrical")
            {
                Array.Clear(CylindricalObject.CylindricalObjectSizes, 0, 1);
                CylindricalObject.CylindricalObjectSizes[0] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[0].Text);
                CylindricalObject.CylindricalObjectSizes[1] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[1].Text);
                return CylindricalObject.CylindricalObjectSizes;
            }
            else
            {
                Array.Clear(BallObject.BallObjectSizes, 0, 1);
                BallObject.BallObjectSizes[0] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[0].Text);
                BallObject.BallObjectSizes[1] = Convert.ToDouble(GeneratorOfInputFields.ObjectSizesTextBoxes[0].Text);
                return BallObject.BallObjectSizes;
            }
        }
    }
    internal class CheckerPassingPossibility
    {
        internal bool CheckPassingPossibility(string holeType, string passingObjectType)
        {
            SizesInput sizesInput = new SizesInput();
            if (holeType == "Round")
            {
                return CheckPassingPossibilityOfObjectThroughRoundHole(sizesInput.Input(holeType, passingObjectType), RoundHole.RoundHoleDiameter, passingObjectType);
            }
            else if (holeType == "Square")
            {
                return CheckPassingPossibilityOfObjectThroughSquareHole(sizesInput.Input(holeType, passingObjectType), SquareHole.SquareHoleSizes, passingObjectType);
            }
            else
            {
                return false;
            }
        }

        private bool CheckPassingPossibilityOfObjectThroughRoundHole(double[] objectSizes, double roundHoleDiameter, string objectType)
        {
            if (objectType == "Cubic")
            {
                Array.Sort(objectSizes);
                double diagonal = Math.Sqrt(Math.Pow(objectSizes[0], 2) + Math.Pow(objectSizes[1], 2));
                if (diagonal <= roundHoleDiameter)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (objectType == "Cylindrical")
            {
                double diagonal = Math.Sqrt(Math.Pow(objectSizes[0], 2) + Math.Pow(objectSizes[1], 2));
                if (objectSizes[1] <= roundHoleDiameter || diagonal <= roundHoleDiameter)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(objectType=="Ball")
            {
                if (objectSizes[0] <= roundHoleDiameter)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckPassingPossibilityOfObjectThroughSquareHole(double[] objectSizes, double[] squareHoleSizes, string objectType)
        {
            if((objectType == "Cylindrical") && (objectSizes[0] > objectSizes[1]))
            {
                objectSizes[0] = objectSizes[1];
            }
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
    public class AnswerOutput
    {
        internal void OutputAnswer(string holeType, string passingObjectType, Label label)
        {
            CheckerPassingPossibility checkerPassingPossibility = new CheckerPassingPossibility();
            if (checkerPassingPossibility.CheckPassingPossibility(holeType, passingObjectType))
            {
                label.Content = "It is possible to move object through hole";
            }
            else
            {
                label.Content = "It is NOT possible to move object through hole";
            }
        }
    }

    internal class RoundHole
    {
        internal static double RoundHoleDiameter;
    }

    internal class SquareHole
    {
        internal static double[] SquareHoleSizes = new double[2];
    }

    internal class CubicObject
    {
        internal static double[] CubeObjectSizes = new double[3];
    }

    internal class CylindricalObject
    {
        internal static double[] CylindricalObjectSizes = new double[2];
    }

    internal class BallObject
    {
        internal static double[] BallObjectSizes = new double[2];
    }

    internal class GeneratorOfInputFields
    {
        internal static List<TextBox> ObjectSizesTextBoxes = new List<TextBox>();
        internal static List<TextBox> HoleSizesTextBoxes = new List<TextBox>();

        internal void GenerateInputFieldsForObject(string passingObjectType, ref Grid objectGrid)
        {
            objectGrid.Children.Clear();
            ObjectSizesTextBoxes.Clear();
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
        internal void GenerateInputFieldsForHole(string holeType, ref Grid holeGrid)
        {
            holeGrid.Children.Clear();
            HoleSizesTextBoxes.Clear();
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
            ObjectSizesTextBoxes.Add(heightTextBox);
            TextBox widthTextBox = new TextBox();
            objectGrid.Children.Add(widthTextBox);
            Grid.SetColumn(widthTextBox, 1);
            Grid.SetRow(widthTextBox, 1);
            ObjectSizesTextBoxes.Add(widthTextBox);
            TextBox lenghtTextBox = new TextBox();
            objectGrid.Children.Add(lenghtTextBox);
            Grid.SetColumn(lenghtTextBox, 1);
            Grid.SetRow(lenghtTextBox, 2);
            ObjectSizesTextBoxes.Add(lenghtTextBox);
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
            ObjectSizesTextBoxes.Add(heightTextBox);
            TextBox diameterTextBox = new TextBox();
            objectGrid.Children.Add(diameterTextBox);
            Grid.SetColumn(diameterTextBox, 1);
            Grid.SetRow(diameterTextBox, 1);
            ObjectSizesTextBoxes.Add(diameterTextBox);
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
            ObjectSizesTextBoxes.Add(diameterTextBox);
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
            HoleSizesTextBoxes.Add(diameterTextBox);
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
            //cheakout
            holeGrid.Children.Add(heightTextBox);
            Grid.SetColumn(heightTextBox, 1);
            Grid.SetRow(heightTextBox, 0);
            HoleSizesTextBoxes.Add(heightTextBox);
            TextBox widthTextBox = new TextBox();
            holeGrid.Children.Add(widthTextBox);
            Grid.SetColumn(widthTextBox, 1);
            Grid.SetRow(widthTextBox, 1);
            HoleSizesTextBoxes.Add(widthTextBox);
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
    class SizeException : Exception
    {
        public SizeException(string message) : base(message)
        {

        }
    }
}
