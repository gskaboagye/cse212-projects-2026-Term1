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
        // PLAN FOR MULTIPLESOF FUNCTION:
        //
        // 1. Create a new array of type double with a size equal to 'length'.
        //    This array will hold all of the multiples.
        //
        // 2. Use a loop that runs from index 0 up to (length - 1).
        //
        // 3. For each index i in the loop, calculate the multiple by multiplying
        //    the given number by (i + 1). We add 1 because array indexing starts
        //    at 0, but multiples should start counting from 1.
        //
        // 4. Store the calculated value into the array at position i.
        //
        // 5. After the loop finishes, return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 
    /// then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list
    /// rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN FOR ROTATELISTRIGHT FUNCTION:
        //
        // 1. Determine where the list should be split so that the last 'amount'
        //    values can be moved to the front of the list.
        //
        // 2. Calculate the split index as (data.Count - amount).
        //
        // 3. Use GetRange to copy the last 'amount' values into a temporary list
        //    called rightPart.
        //
        // 4. Use GetRange again to copy the remaining values from the beginning
        //    of the list into another temporary list called leftPart.
        //
        // 5. Clear the original list so we can rebuild it in the correct order.
        //
        // 6. Add all values from rightPart back into the list first.
        //
        // 7. Add all values from leftPart afterward to complete the rotation.

        int splitIndex = data.Count - amount;

        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
