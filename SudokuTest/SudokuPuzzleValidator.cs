using System;
using System.Diagnostics;

namespace SudokuTest
{
    class SudokuPuzzleValidator
    {
        public static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };

            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };

            Debug.Assert(ValidateSudoku(goodSudoku1), "This is supposed to validate! It's a good sudoku!");
            Debug.Assert(ValidateSudoku(goodSudoku2), "This is supposed to validate! It's a good sudoku!");
            Debug.Assert(!ValidateSudoku(badSudoku1), "This isn't supposed to validate! It's a bad sudoku!");
            Debug.Assert(!ValidateSudoku(badSudoku2), "This isn't supposed to validate! It's a bad sudoku!");
        }
        static bool ValidateSudoku(int[][] data)
        {
            try
            {
                int size = data.Length;
                int slot = (int)Math.Sqrt(size);
                if (data == null)
                {
                    return false;
                }
                if (data.Length <= 0)
                {
                    return false;
                }
                if (data[0].Length != data.Length)
                {
                    return false;
                }
                if (slot * slot != data.Length)
                {
                    return false;
                }
                // check rows
                for (int i = 0; i < data.Length; i++)
                {
                    int[] subarray = new int[data.Length];
                    for (int j = 0; j < data.Length; j++)
                    {
                        subarray[j] = data[i][j];
                    }
                    if (checkSubarray(subarray) == false)
                    {
                        return false;
                    }
                }
                // check columns
                for (int i = 0; i < data.Length; i++)
                {
                    int[] subarray = new int[data.Length];
                    for (int j = 0; j < data.Length; j++)
                    {
                        subarray[j] = data[i][j];
                    }
                    if (checkSubarray(subarray) == false)
                    {
                        return false;
                    }
                }
                // check N*N
                for (int i = 0; i < data.Length; i++)
                {
                    int[] subarray = new int[data.Length];
                    int cOffset = slot * (i % slot);
                    int rOffset = slot * (i / slot);
                    int j = 0;
                    for (int r = 0; r < data.Length / slot; r++)
                    {
                        for (int c = 0; c < data.Length / slot; c++)
                        {
                            subarray[j] = data[rOffset + r][cOffset + c];
                            j++;
                        }
                    }
                    if (checkSubarray(subarray) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        static bool checkSubarray(int[] array)
        {
            try
            {
                Boolean[] temp = new Boolean[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if ((array[i] > 0) && (array[i] < (1 + array.Length)))
                    {
                        int iPos = (array[i] - 1);
                        if (temp[iPos] == false)
                        {
                            temp[iPos] = true;
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
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
