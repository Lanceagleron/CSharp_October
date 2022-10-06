// Create an empty array that will hold 10 integer values.
    int[] array = new int[10];

static void RandomArray(int[] arr)
{
    
    // Loop through the array and assign each index a random integer value between 5 and 25.
    for(int i = 0; i < arr.Length; i++)
    {
        Random rand = new Random();
        int randomNum = rand.Next(5, 25);
        int[] newArray = new int[] { randomNum };
        foreach (int num in newArray)
        {
            Console.WriteLine(num);
        }



        // Array.Sort(newArray);
        // if (newArray.Length > 0)
        // {
        //     Console.WriteLine("Minimum number is " + newArray[0]);
        //     Console.WriteLine("Maximum number is " + newArray[newArray.Length - 1]);
        // }
    }
    
}

// static int findMin(int[] arr)
//     {
//         if (arr.Length == 0) {
//             throw new Exception("Array is empty");
//         }
 
//         int min = int.MaxValue;
//         foreach (var i in arr) {
//             if (i < min) {
//                 min= i;
//             }
//         }
//         return min;
//     }

// static int findMax(int[] arr)
//     {
//         if (arr.Length == 0) {
//             throw new Exception("Array is empty");
//         }
 
//         int max = int.MinValue;
//         foreach (var i in arr) {
//             if (i > max) {
//                 max = i;
//             }
//         }
//         return max;
//     }

RandomArray(array);

