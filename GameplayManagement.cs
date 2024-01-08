using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace Wordle2024
{
    internal class GameplayManagement
    {
        public static char[] SelectRandomWord()
        {
            string filePath = "C:\\Users\\evang\\Desktop\\EGWL\\Wordle2024\\words.txt";
            string[] lines = File.ReadAllLines(filePath);

            // Generate a random number between 0 and 3103
            Random random = new Random();
            int randomNumber = random.Next(0, 3104);

            // Ensure the random number is within the valid range
            int selectedLineNumber = Math.Min(randomNumber, lines.Length - 1);

            // Get the selected line from the file
            string selectedWord = lines[selectedLineNumber];

            // Store each letter in an array of strings
            string[] randWordArray = new string[selectedWord.Length];
            for (int i = 0; i < selectedWord.Length; i++)
            {
                randWordArray[i] = selectedWord[i].ToString();
            }

            // Display the results
            Console.WriteLine($"Randomly selected word: {selectedWord}");
            Console.WriteLine("Array of Letters:");
            foreach (string letter in randWordArray)
            {
                Console.Write($"{letter} ");
            }

            return selectedWord.ToCharArray();
        }
    }
    
}

