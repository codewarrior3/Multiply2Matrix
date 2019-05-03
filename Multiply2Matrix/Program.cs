using System;
using System.Text;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MatrixMultiplicationDemo
{
    internal class Example
    {
        private static void Main(string[] args)
        {
            Matrix<double> a = DenseMatrix.OfArray(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix<double> b = DenseMatrix.OfArray(new double[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } });
            Matrix<double> result = a * b;
            string md5 = CreateMD5(result.ToMatrixString());
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}