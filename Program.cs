﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();

        }


        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Create a list to store the missing ranges
                IList<IList<int>> result = new List<IList<int>>();

                // Initialize a variable to keep track of the previous number
                long prev = (long)lower - 1;

                // Iterate through the sorted array of numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    long num = nums[i];

                    // Check if there is a gap between the current number and the previous number
                    if (num - prev > 1)
                    {
                        // Add the missing range to the result list
                        result.Add(new List<int> { (int)(prev + 1), (int)(num - 1) });
                    }

                    // Update the previous number
                    prev = num;
                }

                // Check for a missing range from the last number to the upper bound
                if ((long)upper - prev > 0)
                {
                    result.Add(new List<int> { (int)(prev + 1), (int)(upper) });
                }

                // Return the list of missing ranges
                return result;
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it
                throw;
            }
        }


        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Check if the string length is odd; if so, it can't be valid
                if (s.Length % 2 != 0)
                {
                    return false;
                }

                // Create a stack to keep track of opening brackets
                Stack<char> stack = new Stack<char>();

                // Iterate through each character in the input string
                foreach (char c in s)
                {
                    // If the character is an opening bracket, push it onto the stack
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        // If the character is a closing bracket
                        if (stack.Count == 0)
                        {
                            // There is no matching opening bracket, so it's not valid
                            return false;
                        }

                        // Pop the top character from the stack
                        char top = stack.Pop();

                        // Check for matching opening and closing brackets
                        if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                        {
                            // Mismatched brackets, so it's not valid
                            return false;
                        }
                    }
                }

                // If there are any unmatched opening brackets left in the stack, it's not valid
                return stack.Count == 0;
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it
                throw;
            }
        }


        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                int minPrice = int.MaxValue; // Initialize minPrice to a large value.
                int maxProfit = 0;

                // Iterate through the array of stock prices
                for (int i = 0; i < prices.Length; i++)
                {
                    // Check if the current price is lower than the previously seen minimum price
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i]; // Update the minimum price if a lower price is found
                    }
                    else if (prices[i] - minPrice > maxProfit)
                    {
                        // Calculate the profit by selling at the current price minus the minimum price
                        maxProfit = prices[i] - minPrice;
                    }
                }

                return maxProfit; // Return the maximum profit obtained
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it
                throw;
            }
        }


        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                int left = 0; // Initialize a pointer for the left end of the string.
                int right = s.Length - 1; // Initialize a pointer for the right end of the string.
                string strobogrammaticPairs = "69 96 00 88 11"; // Define valid pairs of strobogrammatic digits.

                while (left <= right)
                {
                    // Check if the pair of characters at the left and right positions exists in the strobogrammatic pairs.
                    if (!strobogrammaticPairs.Contains(s[left].ToString() + s[right]))
                    {
                        return false; // If not, the string is not strobogrammatic, so return false.
                    }

                    left++; // Move the left pointer to the right.
                    right--; // Move the right pointer to the left.
                }

                return true; // If the loop completes without finding any non-strobogrammatic pair, return true.
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it.
                throw;
            }
        }



        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> countMap = new Dictionary<int, int>(); // Create a dictionary to store counts of each number.
                int goodPairs = 0; // Initialize a variable to count the number of good pairs.

                foreach (int num in nums)
                {
                    if (countMap.ContainsKey(num))
                    {
                        goodPairs += countMap[num]; // If the number already exists in the dictionary, increment goodPairs by its count.
                        countMap[num]++; // Increment the count of this number in the dictionary.
                    }
                    else
                    {
                        countMap[num] = 1; // If the number is encountered for the first time, initialize its count in the dictionary as 1.
                    }
                }

                return goodPairs; // Return the total count of good pairs.
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it.
                throw;
            }
        }


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Sort the array in descending order
                nums = nums.OrderByDescending(x => x).ToArray();

                int distinctCount = 0;
                int prevMax = int.MaxValue;

                // Iterate through the sorted array to find the third distinct maximum
                foreach (int num in nums)
                {
                    if (num != prevMax)
                    {
                        distinctCount++;
                        prevMax = num;

                        if (distinctCount == 3)
                        {
                            return num; // Third distinct maximum found
                        }
                    }
                }

                // If the third distinct maximum doesn't exist, return the maximum element
                return nums[0];
            }

            catch (Exception)
            {
                // If an exception occurs, re-throw it
                throw;
            }
        }
        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                List<string> result = new List<string>(); // Initialize a list to store possible next states.

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // If we find "++" in the current state, we can make a move.
                        // Create a new state by replacing "++" with "--".
                        string nextState = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);

                        result.Add(nextState); // Add the new state to the list of possible next states.
                    }
                }

                return result; // Return the list of possible next states.
            }
            catch (Exception)
            {
                // If an exception occurs, re-throw it.
                throw;
            }
        }


        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Initialize a StringBuilder to build the resulting string without vowels.
            StringBuilder result = new StringBuilder();

            // Iterate through each character in the input string 's'.
            foreach (char c in s)
            {
                // Check if the current character 'c' is not a vowel.
                if ("aeiouAEIOU".IndexOf(c) == -1)
                {
                    // If 'c' is not a vowel, append it to the result.
                    result.Append(c);
                }
            }

            // Convert the StringBuilder to a string and return the result without vowels.
            return result.ToString();
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
