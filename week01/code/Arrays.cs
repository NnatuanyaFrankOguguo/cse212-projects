public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Create a result array with the requested length.
        // Step 2: Loop through each index from 0 to length - 1.
        // Step 3: For each index i, compute the multiple as number * (i + 1).
        // Step 4: Store that value in the matching array position.
        // Step 5: Return the completed array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Find where the list should be split so the last 'amount' items move to the front.
        // Step 2: Copy the right portion (items that will move to the front) into a temporary list.
        // Step 3: Copy the left portion (items that stay after the moved items) into another temporary list.
        // Step 4: Clear the original list so we can rebuild it in rotated order.
        // Step 5: Add the right portion first, then add the left portion.

        int splitIndex = data.Count - amount;
        List<int> rightPortion = data.GetRange(splitIndex, amount);
        List<int> leftPortion = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPortion);
        data.AddRange(leftPortion);
    }
}
