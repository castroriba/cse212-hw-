using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the multiples
        double[] multiples = new double[length];

        // Step 2: Loop from 0 to length-1 to calculate each multiple
        for (int i = 0; i < length; i++)
        {
            // Each element is the starting number multiplied by (i + 1)
            multiples[i] = number * (i + 1);
        }

        // Step 3: Return the array with the calculated multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// Modifies the list in-place rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Validate input (amount must be between 1 and data.Count)
        if (amount < 1 || amount > data.Count)
            throw new ArgumentOutOfRangeException(nameof(amount));

        // Step 2: Use slicing to get the last 'amount' elements (these will go to the front)
        List<int> endSlice = data.GetRange(data.Count - amount, amount);

        // Step 3: Get the remaining elements (these will go after the endSlice)
        List<int> startSlice = data.GetRange(0, data.Count - amount);

        // Step 4: Clear the original list to prepare for the rotated values
        data.Clear();

        // Step 5: Add the end slice first
        data.AddRange(endSlice);

        // Step 6: Add the start slice after
        data.AddRange(startSlice);

        // Now 'data' has been rotated to the right by 'amount'
    }
}
