using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows.Media;

namespace WpfGame
{
    internal class Field
    {
        public Field(Grid _grid, int _rows, int _cols)
        {
            grid = _grid;
            logicField = new Unit[_rows, _cols];
            Rows = _rows;
            Columns = _cols;
        }

        readonly Grid grid;

        private int rows;
        public int Rows
        {
            get { return rows; }
            set
            {
                if (value == rows) return;

                else if (value > rows)
                    for (int i = grid.RowDefinitions.Count; i < value; i++)
                        grid.RowDefinitions.Add(new());

                else
                    for (int i = grid.RowDefinitions.Count; i > value; i--)
                        grid.RowDefinitions.RemoveAt(i - 1);

                rows = value;

                logicField = ResizeArray(logicField, rows, cols);
            }
        }

        private int cols;
        public int Columns
        {
            get { return cols; }
            set
            {
                if (value == cols) return;

                else if (value > cols)
                    for (int i = grid.ColumnDefinitions.Count; i < value; i++)
                        grid.ColumnDefinitions.Add(new());

                else
                    for (int i = grid.ColumnDefinitions.Count; i > value; i--)
                        grid.ColumnDefinitions.RemoveAt(i - 1);

                cols = value;

                logicField = ResizeArray(logicField, rows, cols);                
            }
        }

        Unit[,] logicField;

        Unit[,] ResizeArray(Unit[,] original, int rows, int cols)
        {
            var newArray = new Unit[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }

        void PlaceUnitTo(Unit unit, int row, int col)
        {
            logicField[row, col] = unit;
            unit.Row = row;
            unit.Column = col;
            Grid.SetRow(unit.texture, row);
            Grid.SetColumn(unit.texture, col);
        }

        public void MoveUnitTo(Unit unit, int row, int col)
        {
            if (logicField[row, col] != null)
                MessageBox.Show("Занято!");

            logicField[unit.Row, unit.Column] = null;
            PlaceUnitTo(unit, row, col);
        }

        public void RemoveUnit(Unit unit)
        {
            logicField[unit.Row, unit.Column] = null;
            grid.Children.Remove(unit.texture);
        }

        public void SpawnUnitTo(string type, int row, int col)
        {
            Unit unit = null;

            switch (type)
            {
                case "Red":
                    unit = new MeleeUnit(type);
                    break;
                case "Orange":
                    unit = new MeleeUnit(type);
                    break;
                case "Yellow":
                    unit = new RangeUnit(type);
                    break;
                default:
                    break;
            }

            PlaceUnitTo(unit, row, col);
            grid.Children.Add(unit.texture);
        }

        public void SpawnUnitTo(Unit unit, int row, int col)
        {
            PlaceUnitTo(unit, row, col);
            grid.Children.Add(unit.texture);
        }

        public void IlluminateCells(bool[,] cellsCanGoTo)
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    if (cellsCanGoTo[row, col])
                    {
                        
                        //Border br = new() { Background = (SolidColorBrush)Resources["greenCell"] };

                        //Grid.SetRow(br, row);
                        //Grid.SetColumn(br, col);
                        //grid.Children.Add(br);
                    }
        }

        public void FillField(List<Unit> army1, List<Unit> army2)
        {
            for (int i = 0; i < army1.Count; i++)
                SpawnUnitTo(army1[i], i, 0);

            for (int i = 0; i < army2.Count; i++)
                SpawnUnitTo(army2[i], i, Columns - 1); //to last column
        }
    }
}
