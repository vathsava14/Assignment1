using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine("\n");

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }
            Console.WriteLine();

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            Console.WriteLine();

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);
            Console.WriteLine();

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
            Console.WriteLine();

        }

        /// <summary>
        ///Print a pattern with n rows given n as input
        ///n – number of rows for the pattern, integer (int)
        ///This method prints a triangle pattern.
        ///For example n = 5 will display the output as: 
        ///     *
        ///    ***
        ///   *****
        ///  *******
        /// *********
        ///returns      : N/A
        ///return type  : void
        /// </summary>
        /// <param name="n"></param>
        private static void printTriangle(int n)
        {
            try
            {
                for (int r = 1; r <= n; r++)    // Created this for loop for creating the number of rows as the input number by the user
                {
                    for (int c = 1; c <= n - r; c++) // This for loop is used in columns for filling up the spaces in places other than '*'
                    {
                        Console.Write(" "); // Whenever the loop reaches the column 'c1' other than the one's having the star 'n-r' columns are filled with space
                    }
                    for (int c = 1; c <= 2 * r - 1; c++) // This for loop prints the '2r-1' odd number of stars based on the row number
                    {
                        Console.Write("*"); // With respect to the row number 'r' that corresponding '2r-1' number of stars are printed in each row
                    }
                    Console.WriteLine();    // Once each row is completed the next row is printed on the next line
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        ///<para>
        ///In mathematics, the Pell numbers are an infinite sequence of integers.
        ///The sequence of Pell numbers starts with 0 and 1, and then each Pell number is the sum of twice of the previous Pell number and 
        ///the Pell number before that.:thus, 70 is the companion to 29, and 70 = 2 × 29 + 12 = 58 + 12. The first few terms of the sequence are :
        ///0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860,… 
        ///Write a method that prints first n numbers of the Pell series
        /// Returns : N/A
        /// Return type: void
        ///</para>
        /// </summary>
        /// <param name="n2"></param>
        private static void printPellSeries(int n2)
        {
            try
            {
                int i = 1, j = 0, res = 0, sum = 0;
                if (n2 == 0) // If the user asks for 0 terms from the Pell series then it returns 'N/A'
                {
                    Console.WriteLine("N/A");
                }
                else if (n2 == 1) // If the user asks for the first term from the pell series it returns the value of 'j'
                {
                    Console.WriteLine(j);       // The value of 'j' is initialized with '0'
                }
                else if (n2 == 2) // If the inputs the value 2 to get the first two terms of the pell series, then the function returns the 'j' and 'i' values
                {
                    Console.Write(j + "\t");    // The value of 'j' is initialized with '0'
                    Console.Write(i + "\t");    // The value of 'i' is initialized with '1'
                }
                else    // In all other cases the below loop runs if the user asks for the first 3 or more terms from the pell series
                {
                    Console.Write(j + "\t");    // The value of 'j' is initialized with '0' 
                    Console.Write(i + "\t");    // The value of 'i' is initialized with '1'
                    res = (2 * i) + j;      // This formula is used for calculating the next term of the pell series
                    Console.Write(res + "\t");  // The third term value is calculated and stored in the variable 'res' whose value is '2'
                    for (int k = 0; k < (n2 - 3); k++)
                    {
                        sum = (2 * res) + i;    // The pell series is calculated by doubling the previous number and adding the number before it to that 
                        i = res;    // Once the next term is calculated the previous number is assigned to the variable 'i' that stores the number before that
                        Console.Write(sum + "\t");  // The next term is printed in the series
                        res = sum;  // Then the current next term of the series is assigned to the 'res' variable which stores the previous value of the series  
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: A = 3 will return the output : false
        ///Input: A = 4 will return the output: true
        ///Input: A = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.
        /// </summary>
        /// <param name="n3"></param>
        /// <returns>True or False</returns>

        private static bool squareSums(int n3)
        {
            try
            {
                for (int s1 = 0; s1 <= n3; s1++) // This for loop is used to incerement the first integer value
                {
                    for (int s2 = 0; s2 <= n3; s2++)    // The second for loop is used to raise the second integer value
                    {
                        // if((s1 * s1) + (s2 * s2) == n3) // If the integers a and b can be same
                        if (((s1 * s1) + (s2 * s2) == n3) && (s1 != s2)) // If the integers a and b are unique integers
                        {
                            return true; // If the given integer can be expressed as sum of squares of two numbers then the true values will be returned by the function
                        }
                    }
                }
                return false; // In all other cases the function returns false saying that the given integer cannot be expressed as sum of squares of two integers

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Given an array of integers and an integer n, you need to find the number of unique
        /// n-diff pairs in the array.Here a n-diff pair is defined as an integer pair (i, j),
        ///where i and j are both numbers in the array and their absolute difference is n.
        ///Example 1:
        ///Input: [3, 1, 4, 1, 5], k = 2
        ///Output: 2
        ///Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        ///Although we have two 1s in the input, we should only return the number of unique   
        ///pairs.
        ///Example 2:
        ///Input:[1, 2, 3, 4, 5], k = 1
        ///Output: 4
        ///Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and
        ///(4, 5).
        ///Example 3:
        ///Input: [1, 3, 1, 5, 4], k = 0
        ///Output: 1
        ///Explanation: There is one 0-diff pair in the array, (1, 1).
        ///Note : The pairs(i, j) and(j, i) count as same.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns>Number of pairs in the array with the given number as difference</returns>
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                int count = 0;      // This variable is used for positioning the unique numbers in the second array
                int finalCount = 0; // This variable gives the count of pairs with the difference of value 'k' between them
                int element = 0;    // Created this variable to filter out the duplicate repetition of numbers from the original array
                int[] dummy = new int[nums.Length]; // Creating a new array for saving the unique numbers from the original array
                Array.Sort(nums);   // Sorted out the arrays in ascending order for easy elimination of duplicates
                element = nums[0];  // Added the first element of the original array to the variable element to send unique variables to second array
                dummy[count++] = element;   // The second array is assigned with the value of the variable element
                for (int i = 1; i < nums.Length; i++) // The loop continues to take out the unique values to the second array by using the values in the first array
                {
                    if (nums[i] == element) // If the original sorted array has a repetition of the first element then the loop continues iterating 
                    {
                        continue;
                    }
                    else // If there is no duplicate of first number in the original sorted array, then it is added to the variable element and to second array as well
                    {
                        element = nums[i];
                        dummy[count++] = element;
                    }
                }
                if (k == 0) // If the difference between the pairs is 0, then it is asking for the duplicate pairs
                {
                    int l1 = nums.Length;
                    int l2 = count + 1;
                    finalCount = l1 - l2; // That duplicate pairs can be given by using the difference between the first array and the second array, as that gives the duplicate pairs count
                }
                else
                {
                    for (int z3 = 0; z3 < dummy.Length; z3++)
                    {
                        for (int z4 = 0; z4 < dummy.Length; z4++)
                        {
                            if ((dummy[z3] - dummy[z4] == k) && (dummy[z3] > dummy[z4]) && (z3 != z4) && (dummy[z4] >0)) // In other cases, it calculates the exact number of pairs by traversing through the second array which has only unique numbers
                            {
                                finalCount++; // Whenever a pair has the difference that is equal to the number specified it adds the final count of the pairs
                            }
                        }
                    }
                    if (k > (dummy[dummy.Length - 1] - dummy[0]) && (finalCount == 0)) // If the number provided is larger than the highest number in the original array then the function returns '0' pairs are having that difference between them
                    {
                        finalCount = 0;
                    }
                }
                return finalCount; // The total pairs with the exact required difference are returned by the function 
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns>The number of unique emails in the given list</returns>

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                List<string> newEmails = new List<string>();
                for (int num1 = 0; num1 < emails.Count; num1++)
                {
                    string str = emails[num1];  // Each email is copied to a string to perform some string operations
                    int p = str.IndexOf("@");   // Identified the '@' index location of the email to slit the primary and domain parts of the email ID
                    int e = str.Length;         // Found the total length of the email for trimming the string perfectly
                    string loc = str.Substring(0, p);   // Took out the local name part of the email ID
                    p++;
                    string dom = str.Substring(p);      // Copied the domain part to add to the modified local name part of email ID
                    int plus = loc.IndexOf("+");        // Identified the '+' in the local name of the email ID
                    loc = loc.Substring(0, plus);       // Chopped off all the text including and after the '+' symbol
                    string res = loc;
                    int d = loc.IndexOf(".");           // Find the index position of '.' in the modified local name part
                    while (d > -1)                      // I have set condition to run this while loop until there are no more '.' in the modified local name
                    {
                        res = res.Remove(d, 1);         // Inside it will remove the '.' character alone in the local name and merges the remaining string
                        d = res.IndexOf(".");           // Once the first dot '.' is removed, then the d value is initilaised again with the next dot '.' value of the string and if there are no '.' dots in the string, then the value of d will be -1
                    }
                    int space = res.IndexOf(" ");       // In some cases there are spaces before '+' so I chose to remove them as well
                    while (space > -1)
                    {
                        res = res.Remove(space, 1);     // Used the same logic for ' ' space as used for '.' before to remove the space character alone in the modified local name part of email ID
                        space = res.IndexOf(" ");       // Once the first space is removed the value is assigned with the position of the next subsequent spaces until there are no more spaces, for which it's values will be -1
                    }
                    string final_res = res + "@" + dom;     // Finally after modifying the local name part, add back the @ and domain part without making any changes to them, which were separated intially
                    newEmails.Add(final_res);               // Once all the required changes are done, the entire new email ID string is added to the new List created
                }
                List<string> uniqueEmails = newEmails.Distinct().ToList(); // Finding the unique emails by using the distict method to filter out the duplicates in the linq collection
                int counter = 0;    // Creating a counter variable of int type to calculate the number of unique strings in the List
                foreach (string emailID in uniqueEmails)
                {
                    counter++;      // For each unique string in the List the counter is incremented
                }
                return counter;     // At the end of the List, the total number of unique emails in the List is returned by the function
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>The destination city string</returns>
        private static string DestCity(string[,] paths)
        {
            try
            {
                int rows = paths.GetLength(0);      // Identified the number of rows in the 2D string
                int columns = paths.GetLength(1);   // Identified the number of columns in the 2D string
                string destination = null;          // Created a string variable to store the identified final destination city name
                for (int a = 0; a < rows; a++)       // Since the destinations are all in column '1' and the start points are in column '0', we just traverse through the rows
                {
                    for (int b = 0; b < rows; b++)
                    {
                        if (paths[b, 1] != paths[a, 0] && a != b)  //Identified the destination city in the 2D array that do not a connection path to another destination city by travesring through each arrival city in the 2D array
                        {
                            destination = paths[b, 1];  // When such a unique end destination is identified, it is stored in the variable and is returned by the function
                        }
                    }
                }
                return destination;


            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}