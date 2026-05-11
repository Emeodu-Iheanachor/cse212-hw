using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'. For
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start

        /*
        =========================================================
        PROBLEM:
        Create and return an array containing multiples
        of the supplied number.

        Example:
        MultiplesOf(7, 5)

        Expected Result:
        {7, 14, 21, 28, 35}
        =========================================================

        IMPLEMENTATION PLAN

        STEP 1:
        Create a new array of type double.

        The size of the array should equal the value
        stored in length because the function must
        return exactly that many multiples.

        ---------------------------------------------------------

        STEP 2:
        Use a loop to move through every index position
        in the array.

        The loop should:
        - Start at index 0
        - Continue while index < length
        - Move one step at a time

        ---------------------------------------------------------

        STEP 3:
        During each loop iteration, calculate the next
        multiple of the supplied number.

        Formula:
        number * (index + 1)

        Arrays begin at index 0, but multiplication
        should begin at 1, which is why 1 is added
        to the index.

        ---------------------------------------------------------

        STEP 4:
        Store the calculated multiple into the current
        array position.

        Example:

        number = 7

        Index 0:
        7 * (0 + 1) = 7

        Index 1:
        7 * (1 + 1) = 14

        Index 2:
        7 * (2 + 1) = 21

        ---------------------------------------------------------

        STEP 5:
        After all multiples have been stored in the array,
        return the completed array.

        =========================================================
        */

        // Create array to store multiples
        double[] multiples = new double[length];

        // Loop through each array position
        for (int i = 0; i < length; i++)
        {
            // Calculate and store the multiple
            multiples[i] = number * (i + 1);
        }

        // Return completed array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start

        /*
        =========================================================
        PROBLEM:
        Rotate the values in the list to the right
        by the specified amount.

        Example:

        Original List:
        {1,2,3,4,5,6,7,8,9}

        amount = 3

        Expected Result:
        {7,8,9,1,2,3,4,5,6}
        =========================================================

        IMPLEMENTATION PLAN

        STEP 1:
        Determine where the list should be divided.

        The last "amount" values should move to the
        beginning of the list.

        Formula:
        splitPosition = data.Count - amount

        Example:

        data.Count = 9
        amount = 3

        splitPosition = 9 - 3 = 6

        ---------------------------------------------------------

        STEP 2:
        Use GetRange() to divide the list into two sections.

        First Part:
        Contains all values before the split position.

        Second Part:
        Contains all values from the split position
        to the end of the list.

        Example:

        First Part:
        {1,2,3,4,5,6}

        Second Part:
        {7,8,9}

        ---------------------------------------------------------

        STEP 3:
        Clear the original list.

        This removes all current values so they can
        be inserted back in rotated order.

        ---------------------------------------------------------

        STEP 4:
        Add the second part first.

        These values move from the end of the original
        list to the beginning of the rotated list.

        ---------------------------------------------------------

        STEP 5:
        Add the first part after the second part.

        This completes the right rotation process.

        ---------------------------------------------------------

        STEP 6:
        The original list is now fully rotated.

        Final Result:
        {7,8,9,1,2,3,4,5,6}

        =========================================================
        */

        // Find where the list should split
        int splitPosition = data.Count - amount;

        // Store values before the split position
        List<int> firstPart = data.GetRange(0, splitPosition);

        // Store values from the split position to the end
        List<int> secondPart = data.GetRange(splitPosition, amount);

        // Remove all existing values from the original list
        data.Clear();

        // Add the second part first
        data.AddRange(secondPart);

        // Add the first part after it
        data.AddRange(firstPart);
    }
}