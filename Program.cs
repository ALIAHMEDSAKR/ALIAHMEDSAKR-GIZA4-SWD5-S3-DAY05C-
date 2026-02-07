using System;

namespace AssignmentDay05
{
    class Program
    {
        public static void Main(string[] args)
        {
            
        #region Question 1

         /* Problem: Write a program that: 
          o Reads two integers from the user and divides them.
          o Catches DivideByZeroException and displays an appropriate message.
          o Uses a finally block to print "Operation complete" regardless of success or failure. */

        try
        {
            Console.Write("Enter the first integer: ");
            int fnum1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int snum2 = int.Parse(Console.ReadLine());

            int re = fnum1 / snum2;
            Console.WriteLine($"Result: {re}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid integers.");
        }
        finally
        {
            Console.WriteLine("Operation complete");
        }

        //  Question: What is the purpose of the finally block? 
        /*
        The finally block is used to execute a block of code regardless of whether 
        an exception is thrown or not. It ensures that essential cleanup code 
        (like closing files, database connections, or releasing resources) runs 
        even if the operation fails.
        */
        #endregion


        #region Question 3

        int? x = null;

        int res = x ?? 100;


        //Hasvalue and value 

        if(x.HasValue)
        {
            Console.WriteLine($"HasValue is true, Value is: {x.Value}");

        }   
        else
        {
            Console.WriteLine("HasValue is false (variable is null)");
        }

        // Reset to null to demonstrate the risk of accessing .Value
        x = null;

        //  Question: What exception occurs when trying to access Value on a null Nullable? 
        /*
        InvalidOperationException
        
        Accessing the .Value property of a nullable type that is currently null 
        will throw an InvalidOperationException. It is always safer to check .HasValue 
        or use GetValueOrDefault() before accessing .Value.
        */
        
        // Example of the exception (commented out to prevent crash):
        // int crash = x.Value; // Throws InvalidOperationException
        #endregion

        #region Question 4 
         /* Problem: Create a program to: o Declare a 1D array of size 5.
          o Try accessing an index out of bounds and handle the IndexOutOfRangeException. */

        try
        {
            // Declare a 1D array of size 5
            int[] numbers = new int[5] { 10, 20, 30, 40, 50 };

            // Valid indices are 0 to 4. 
            // Trying to access index 10 will trigger the exception.
            Console.WriteLine("Attempting to access index 10...");
            int invalidValue = numbers[10]; 

            Console.WriteLine($"Value: {invalidValue}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Error: You tried to access an index that does not exist in the array.");
            Console.WriteLine($"System Message: {ex.Message}");
        }

        //  Question: Why is it necessary to check array bounds before accessing elements? 
        /*
        Checking array bounds is necessary to prevent the program from crashing 
        due to an IndexOutOfRangeException. 
        
        Arrays have a fixed size in memory. Accessing an index outside the valid range 
        (0 to Length-1) attempts to read or write memory that doesn't belong to that 
        specific array element, which the runtime blocks to ensure memory safety 
        and program stability.
        */
        #endregion


        #region Problem 5: 
        //Rectangular Array (3x3)
          /* Problem: Write a program that: o Creates a 3x3 array with user-provided values.
           o Calculates and prints the sum of elements in each row and column. */

        int[,] matrix = new int[3, 3];

        // 1. Input: Populate the 3x3 array
        Console.WriteLine("Enter values for a 3x3 matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++) // Iterate Rows
        {
            for (int j = 0; j < matrix.GetLength(1); j++) // Iterate Columns
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // 2. Output: Sum of Rows
        Console.WriteLine("\n--- Row Sums ---");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowSum += matrix[i, j];
            }
            Console.WriteLine($"Row {i} Sum: {rowSum}");
        }

        // 3. Output: Sum of Columns
        Console.WriteLine("\n--- Column Sums ---");
        for (int j = 0; j < matrix.GetLength(1); j++) // Fix column (j), iterate rows (i)
        {
            int colSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                colSum += matrix[i, j];
            }
            Console.WriteLine($"Column {j} Sum: {colSum}");
        }

        //  Question: How is the GetLength(dimension) method used in multi-dimensional arrays? 
        /*
        GetLength(int dimension) returns the number of elements in a specific dimension 
        of the array.
        - dimension 0 represents the Rows (first dimension).
        - dimension 1 represents the Columns (second dimension).
        
        This is crucial because the .Length property returns the *total* number of 
        elements in the entire array (9 for a 3x3), not the size of a specific row or column.
        */
        #endregion


        #region Problem 6
        // Jagged Array 
        /* Problem: Write a program that:
        o Creates a jagged array with three rows of varying sizes.
         o Populates each row with user input.
          o Prints all values row by row. */

        // 1. Declaration: 3 rows, but column sizes are not defined yet
        int[][] jagged = new int[3][];

        // Define varying sizes for each row
        jagged[0] = new int[2]; // Row 0 has 2 columns
        jagged[1] = new int[3]; // Row 1 has 3 columns
        jagged[2] = new int[4]; // Row 2 has 4 columns

        // 2. Populate the array
        Console.WriteLine("\n--- Populate Jagged Array ---");
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.WriteLine($"Enter {jagged[i].Length} numbers for Row {i}:");
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write($"Row {i}, Col {j}: ");
                jagged[i][j] = int.Parse(Console.ReadLine());
            }
        }

        // 3. Print the array
        Console.WriteLine("\n--- Jagged Array Output ---");
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write($"{jagged[i][j]} ");
            }
            Console.WriteLine();
        }

        //  Question: How does the memory allocation differ between jagged arrays and rectangular arrays? 
        /*
        
        
        1. Rectangular Arrays (int[,]):
           Allocated as a single contiguous block of memory. All rows must have the 
           same length. It is a single object on the heap.
           
        2. Jagged Arrays (int[][]):
           An "array of arrays." The main array holds references to other array objects. 
           Each inner array is allocated separately on the heap and can be of different 
           sizes. This creates non-contiguous memory blocks.
        */
        #endregion



        #region Problem 7:
        //Nullable Reference Types
        /* Problem: Demonstrate the use of nullable reference types by:
         o Declaring a nullable string.
          o Assigning it a value conditionally based on user input.
           o Using the null-forgiveness operator (!) to suppress warnings. */


        
        Console.Write("Enter a message (or press Enter to skip): ");
       
        string? input = Console.ReadLine(); 

        // 2. Conditional Logic
        if (string.IsNullOrWhiteSpace(input))
        {
            input = null; // Explicitly set to null if empty
        }

        // 3. Use null-forgiveness operator (!)
        // We are suppressing the compiler warning because we are "sure" we want to 
        // treat it as non-null here, or to forcefully assign it to a non-nullable type.
        // Warning: If input IS null at runtime, this will still throw a NullReferenceException.
        try
        {
            Console.WriteLine($"Message length: {input!.Length}"); 
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Error: The message was null, but we suppressed the warning!");
        }

        //  Question: What is the purpose of nullable reference types in C#? 
        /*
        The main purpose is to prevent NullReferenceExceptions at runtime. 
        
        By distinguishing between types that CAN be null (string?) and types that CANNOT 
        be null (string), the compiler can perform static analysis. It warns you during 
        coding if you try to dereference a possible null value without checking it first, 
        shifting errors from runtime (crashes) to compile-time (warnings).
        */
        #endregion

        #region Problem 8: 
        //Boxing and Unboxing 
        /* Problem: Write a program that: o Demonstrates boxing by assigning a value type to an object.
         o Demonstrates unboxing and checks for invalid cast exceptions. */

        // 1. Boxing
        int number = 123;
        object boxedNumber = number; // Implicit conversion (Boxing)
        
        Console.WriteLine($"Boxed value: {boxedNumber}");

        // 2. Unboxing
        try
        {
            int unboxedNumber = (int)boxedNumber; // Explicit conversion (Unboxing)
            Console.WriteLine($"Unboxed value: {unboxedNumber}");

            // 3. Invalid Cast Exception demonstration
            // Attempting to unbox an 'int' directly into a 'double' or 'long' fails.
            // You must unbox to the exact original type first.
            Console.WriteLine("Attempting to unbox int object to double...");
            double invalidUnbox = (double)boxedNumber; 
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("Error: Invalid Cast!");
            Console.WriteLine($"Explanation: {ex.Message}");
        }

        //  Question: What is the performance impact of boxing and unboxing in C#? 
        /*
        Boxing and Unboxing are computationally expensive operations:
        
        1. Allocation (Boxing): Boxing requires allocating a new object on the Heap 
           and copying the value from the Stack into it. This increases memory pressure 
           and gives the Garbage Collector more work to do.
           
        2. Type Checking (Unboxing): Unboxing requires the runtime to check the 
           object's type to ensure it is safe to cast back to the value type, followed 
           by copying the data back to the Stack.
           
        Avoid frequent boxing/unboxing in performance-critical loops ( using 
        non-generic ArrayList vs generic List<T>).
        */
        #endregion


        #region Problem 9:
        // Out Parameters 
        /* Problem: Write a method SumAndMultiply that:
         o Accepts two integers and calculates their sum and product using out parameters.
          o Calls the method and prints the results. */

        static void SumAndMultiply(int a, int b, out int sum, out int product)
        {
            sum = a + b;
            product = a * b;
        }

        // In Main method:
        int num1 = 10;
        int num2 = 5;
        
        // Call the method using inline out variable declaration
        SumAndMultiply(num1, num2, out int calculatedSum, out int calculatedProduct);

        Console.WriteLine($"Numbers: {num1}, {num2}");
        Console.WriteLine($"Sum: {calculatedSum}");
        Console.WriteLine($"Product: {calculatedProduct}");

        //  Question: Why must out parameters be initialized inside the method? 
        /*
        The 'out' keyword guarantees to the caller that the variable will have a value 
        after the method returns. 
        
        Since the compiler does not require 'out' variables to be initialized *before* being passed in, the method *must* assign a value to them before returning. 
        If it didn't, the caller might end up using an uninitialized variable, which 
        C# forbids for safety.
        */
        #endregion

        #region Problem 10:
        // Optional & Named Parameters 
        /* Problem: Create a method that: 
        o Accepts a string and an optional integer (default value: 5). 
        o Prints the string the specified number of times. 
        o Demonstrates the use of named parameters. */

        static void PrintMessage(string message, int count = 5)
        {
            Console.WriteLine($"\nPrinting '{message}' {count} times:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {message}");
            }
        }

        // In Main method:

        // 1. Using default value (count will be 5)
        PrintMessage("Hello Default");

        // 2. Overriding default value
        PrintMessage("Hello Custom", 2);

        // 3. Using Named Parameters (can change order)
        PrintMessage(count: 3, message: "Hello Named");

        //  Question: Why must optional parameters always appear at the end of a method's parameter list? 
        /*
        This rule exists to avoid ambiguity in positional arguments. 
        
        When the compiler processes a method call like Method(10, 20), it maps arguments 
        to parameters from left to right. If optional parameters were allowed in the middle 
        or beginning, the compiler wouldn't know if an argument was meant for the optional 
        parameter or the next required one (unless named arguments were strictly enforced, 
        which is not the default behavior).
        */
        #endregion

        #region Problem 11:
        // Null Propagation
          /* Problem: Write a program that: 
         o Declares a nullable integer array.
         o Uses the null propagation operator (?.) to safely access its properties. */

        // 1. Declare a nullable integer array
        int[]? nullableArray = null;

        // 2. Unsafe access (would throw NullReferenceException)
        // int length = nullableArray.Length; 

        // 3. Safe access using Null Propagation (?.)
        // If nullableArray is null, 'length' becomes null. 
        // If it is not null, it accesses .Length.
        int? length = nullableArray?.Length;

        Console.WriteLine($"Array is null, so Length is: {length ?? 0} (defaulted)");

        // Re-initialize to demonstrate success case
        nullableArray = new int[] { 1, 2, 3 };
        length = nullableArray?.Length;
        
        Console.WriteLine($"Array initialized. Length is: {length}");

        //  Question: How does the null propagation operator prevent NullReferenceException? 
        /*
        The null propagation operator (?.) works by short-circuiting the operation. 
        
        

        Before accessing the member (property, method, or indexer), the runtime evaluates 
        the variable to the left of the `?.`. 
        1. If the variable is `null`, the expression immediately stops and evaluates to `null`.
        2. If the variable is NOT `null`, the member access proceeds as normal.
        
        This "check-first" logic prevents the runtime from ever attempting to dereference 
        a null address.
        */
        #endregion

        #region Problem 12:
        // Switch Expression 
        /* Problem: Write a program that: o Asks the user to enter a day of the week.
         o Uses a switch expression to map the day to its corresponding number. */

        Console.Write("Enter a day of the week: ");
        string dayInput = Console.ReadLine();

        // Using Switch Expression (C# 8.0+)
        int dayNumber = dayInput.Trim() switch
        {
            "Monday" => 1,
            "Tuesday" => 2,
            "Wednesday" => 3,
            "Thursday" => 4,
            "Friday" => 5,
            "Saturday" => 6,
            "Sunday" => 7,
            _ => -1 //discard
        };

        Console.WriteLine(dayNumber != -1 
            ? $"Day number: {dayNumber}" 
            : "Invalid day entered.");

        //  Question: When is a switch expression preferred over a traditional if statement? 
        /*
        Switch expressions are preferred when:
        1. Mapping: You need to map a single input value directly to a single output value 
           (functional style).
        2. Conciseness: You want to avoid the verbose syntax of `case`, `break`, and `return` 
           found in traditional switch statements.
        3. Pattern Matching: You need to match based on types or property values rather 
           than just constants.
        */
        #endregion

        #region Problem 13:
        // Params Keyword
        /* Problem: Write a method SumArray that:
         o Accepts a variable number of integers using the params keyword.
          o Returns the sum of the provided integers.
           o Demonstrates calling the method with both an array and individual values. */

        static int SumArray(params int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers)
            {
                sum += n;
            }
            return sum;
        }

        // In Main Method:
        
        // 1. Calling with individual values (comma-separated)
        int sum1 = SumArray(10, 20, 30, 40);
        Console.WriteLine($"Sum of individual values: {sum1}");

        // 2. Calling with an explicit array
        int[] myArray = { 1, 2, 3, 4, 5 };
        int sum2 = SumArray(myArray);
        Console.WriteLine($"Sum of array: {sum2}");

        //  Question: What are the limitations of the params keyword in method definitions? 
        /*
        1. Position: The `params` parameter must be the *last* parameter in the method's 
           parameter list.
           
        

        2. Count: You can have only *one* `params` keyword per method declaration.
        
        This is because the compiler needs to know that "everything after this point" 
        belongs to the array. If there were parameters after `params`, the compiler 
        wouldn't know where the variable arguments end and the next argument begins.
        */
        #endregion


        //Part 2
        #region 1. Print Numbers in a Range /* Problem: Write a program that allows the user to insert a positive integer, then print all numbers from 1 to that number. */
         Console.Write("Enter a positive integer: ");
          if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
           { 
            Console.Write("Output: ");
             for (int i = 1; i <= n; i++)
              {
                 Console.Write(i + (i < n ? ", " : ""));
               } 
               Console.WriteLine(); 
               } 
               else 
               {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                 } 
        #endregion

#region 2. Multiplication Table /* Problem: Write a program that allows the user to insert an integer, then print the multiplication table for that number up to 12 times. */ 
Console.Write("\nEnter an integer for multiplication table: ");
 if (int.TryParse(Console.ReadLine(), out int tableNum))
  {
    Console.Write("Output: "); 
  for (int i = 1; i <= 12; i++) 
  { 
    Console.Write((tableNum * i) + (i < 12 ? ", " : ""));
     }
     Console.WriteLine(); 
     }
      #endregion

#region 3. List Even Numbers /* Problem: Write a program that allows the user to insert a number, then print all even numbers between 1 and that number. */ 
Console.Write("\nEnter a number to find evens up to: ");
 if (int.TryParse(Console.ReadLine(), out int limit)) 
 { 
    Console.Write("Output: ");
  for (int i = 2; i <= limit; i += 2) 
  {
     Console.Write(i + (i + 2 <= limit ? ", " : ""));
   } 
   Console.WriteLine();
    } 
   #endregion

#region 4. Compute Exponentiation /* Problem: Write a program that takes two integers, then prints the result of raising the first number to the power of the second number. */ 
Console.Write("\nEnter the base number: "); int baseNum = int.Parse(Console.ReadLine());

    Console.Write("Enter the exponent: ");
    int exponent = int.Parse(Console.ReadLine());

    long result = 1;
    for (int i = 0; i < exponent; i++)
    {
        result *= baseNum;
    }

    Console.WriteLine($"Output: {result}");
#endregion

#region 5. Reverse a Text String /* Problem: Write a program that allows the user to enter a string and then prints the string in reverse order. */
 Console.Write("\nEnter a string to reverse: "); 
 string inputString = Console.ReadLine();

    // Convert to char array, reverse, and create new string
    char[] charArray = inputString.ToCharArray();
    Array.Reverse(charArray);
    string reversedString = new string(charArray);

    Console.WriteLine($"Output: \"{reversedString}\"");
#endregion

#region 6. Reverse an Integer Value /* Problem: Write a program that allows the user to enter an integer and then prints the integer with its digits in reverse order. */ 
Console.Write("\nEnter an integer to reverse: ");
 int numberToReverse = int.Parse(Console.ReadLine());

    int reversedNumber = 0;
    while (numberToReverse > 0)
    {
        int remainder = numberToReverse % 10;
        reversedNumber = (reversedNumber * 10) + remainder;
        numberToReverse /= 10;
    }
    Console.WriteLine($"Output: {reversedNumber}");
#endregion

#region 7. Longest Distance Between Matching Elements /* Problem: Write a program to find the longest distance between two identical elements in the array. The distance is the count of cells between the two elements. Example: 7 ... 7 (indices 0 and 10) -> distance = 10 - 0 - 1 = 9. */

    Console.Write("\nEnter the size of the array: ");
    int size = int.Parse(Console.ReadLine());
    int[] arr = new int[size];

    // Fill array
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Element {i}: ");
        arr[i] = int.Parse(Console.ReadLine());
    }

    int maxDistance = 0;

    // Logic to find max distance
    // We compare every element with every subsequent element
    for (int i = 0; i < size; i++)
    {
        for (int j = i + 1; j < size; j++)
        {
            if (arr[i] == arr[j])
            {
                // Distance formula based on example: IndexDifference - 1
                // If indices are 0 and 10, distance is 9.
                int distance = j - i - 1;
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
        }
    }

    Console.WriteLine($"Max distance between matching elements: {maxDistance}");
#endregion

    #region 8. Reverse Words in a Sentence
     /* Problem: Given a sentence with space-separated words, write a program to reverse the order of the words. Output should be a single Console.WriteLine statement. */
    Console.Write("\nEnter a sentence: ");
     string sentence = Console.ReadLine();

    // 1. Split string into array of words
    // 2. Reverse the array
    // 3. Join them back with spaces
    Console.WriteLine(string.Join(" ", sentence.Split(' ').Reverse()));
    #endregion

        }


        #region Question 2
         /* Problem: Modify the TestDefensiveCode method in demo to:
          o Accept only positive integers for both X and Y.
          o Ensure Y is greater than 1. */

        public static void TestDefensiveCode()
        {
            int X, Y, Z;

            // Validate X: Must be a positive integer (X > 0)
            do
            {
                Console.Write("Enter first positive Number (X): ");
            }
            while (!int.TryParse(Console.ReadLine(), out X) || X <= 0);

            // Validate Y: Must be greater than 1 (Y > 1)
            // Note: Being > 1 automatically satisfies the "positive integer" requirement.
            do
            {
                Console.Write("Enter Second Number (Y > 1): ");
            }
            while (!int.TryParse(Console.ReadLine(), out Y) || Y <= 1);

            Z = X / Y;
            Console.WriteLine($"Result: {Z}");
        }

        //  Question: How does int.TryParse() improve program robustness compared to int.Parse()?
        /*
        1. No Exceptions: int.Parse() throws exceptions (FormatException, OverflowException) 
           on failure, which can crash the program if not handled. int.TryParse() simply 
           returns 'false' without throwing an exception.
           
        2. Control Flow: It allows for cleaner logic (like the do-while loops above) to 
           repeatedly prompt the user until valid input is received, rather than using 
           expensive try-catch blocks for basic input validation.
        */
        #endregion
    }
}