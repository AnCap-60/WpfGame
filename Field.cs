using System.Windows;
using System.Collections.Generic;
using System;

namespace WpfGame
{
    internal class Field
    {
        public Field(int _rows, int _cols)
        {
            logicField = new Unit[_rows, _cols];
            Rows = _rows;
            Columns = _cols;
        }

        private int rows;
        public int Rows
        {
            get { return rows; }
            set
            {
                if (value == rows) return;

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
        }

        public void SpawnUnitTo(Unit unit, int row, int col)
        {
            PlaceUnitTo(unit, row, col);
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
                SpawnUnitTo(army1[i], i % Rows, i / Rows);

            for (int i = 0; i < army2.Count; i++)
                SpawnUnitTo(army2[i], i % Rows, Columns - 1 - (i / Rows)); //to last column
        }
    }
}
