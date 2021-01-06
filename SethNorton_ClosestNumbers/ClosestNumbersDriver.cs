//////////////////////////////////////////////////////////////////////////////////////
//
//  Project: Lab 1a - ClosestNumbers
//  File Name: ClosestNumbersDriver.cs
//  Description: Gets the closest pairs of numbers
//  Course: CSCI 3230-001 - Algorithms
//  Author: Seth Norton, nortonsp@etsu.edu
//  Created: Wednesday, January 22, 2020
//  Copyright: Seth Norton, 2020
//
//////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The name space containing the functions to find the closest numbers
/// </summary>
namespace SethNorton_ClosestNumbers
{
    /// <summary>
    /// The driver class for the program which contains a method to find the closest pairs of numbers
    /// </summary>
    class ClosestNumbersDriver
    {
        /// <summary>
        /// The main method of the program which configures the output of the program and makes a function call to find the closest numbers
        /// </summary>
        /// <param name="args">the program arguments</param>
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);  //the text writer which helps with I/O


            Console.WriteLine("Please enter the number of how many numbers you are entering to figure out which two numbers are closest: ");
          

            int n = Convert.ToInt32(Console.ReadLine());    //n is the number of numbers there are (it is always determined by the first number)


            Console.WriteLine("Please enter the array of numbers to find out which two numbers are the closest: ");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));    //parse input into an array
            
            int[] result = ClosestNumbers(arr); //the array with the closest numbers
            Console.WriteLine($"The closest two numbers are: {result[0]} and {result[1]}");
            //textWriter.WriteLine(string.Join(" ", result));

            //textWriter.Flush();
            //textWriter.Close();
        }//end static void Main(string[] args)

        /// <summary>
        /// Finds the closest numbers in an array and returns the closest numbers (with an array)
        /// </summary>
        /// <param name="arr">the inputed array</param>
        /// <returns>the closest numbers</returns>
        static int[] ClosestNumbers(int[] arr)
        {
            Array.Sort(arr);
            int[] closestNumbers = new int[arr.Length]; //the array to store the closest numbers
            int difference = 0;                         //the difference between two numbers
            bool firstpair = true;                      //determines if it is the first pair being compared 
            int counter = 0;                            //used as an indexer for how many numbers are in the closest numbers array
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int pairDifference = arr[i + 1] - arr[i];   //get difference of two numbers
                if (pairDifference <= difference || firstpair == true)
                {
                    if (pairDifference < difference)
                    {
                        Array.Clear(closestNumbers, 0, closestNumbers.Length);
                        counter = 0;    //reset counter to 0
                    }//end if (pairDifference < difference)
                    closestNumbers[counter++] = arr[i];
                    closestNumbers[counter++] = arr[i + 1];
                    difference = pairDifference;
                }//end if (pairDifference <= difference || firstpair == true)
                firstpair = false;
            }//end for (int i = 0; i < arr.Length - 1; i++)
            int[] closestNumbersActualSize = new int[counter]; //copy array into new array to get rid of any zeros not needed 
            for (int i = 0; i < counter; i++)
                closestNumbersActualSize[i] = closestNumbers[i];

            return closestNumbersActualSize;

        }//end static int[] ClosestNumbers(int[] arr)
    }//end class ClosestNumbersDriver
}//end name space SethNorton_ClosestNumbers
