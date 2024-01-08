using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordle2024
{
    internal class WordManagment
    {
        public static void downloadCheck()
        {
            string fileUrl = "https://raw.githubusercontent.com/DonH-ITS/jsonfiles/main/words.txt";
            string localFilePath = "words.txt";

            //check using file exist method wether or not the file exists on the devicec already
            if (FileExists(localFilePath))
            {
                Console.WriteLine("File already exists.");
                
            }
            else
            {
                Console.WriteLine("downloading");

                //otherwise download the file from url
                DownloadFile(fileUrl, localFilePath);
            }
        }

        //function to check if fileExist and returns a bool 
        static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }


        //if file does not exist on pc download it
        static async void DownloadFile(string fileUrl, string localFilePath)
        {
            using (HttpClient webClient = new HttpClient())
            {
                try
                {
                    Console.WriteLine("Downloading file...");

                    // Download the file and save it locally
                    byte[] fileData = await webClient.GetByteArrayAsync(fileUrl);
                    File.WriteAllBytes(localFilePath, fileData);

                    Console.WriteLine("File downloaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error downloading file: {ex.Message}");
                }
            }
        }


        string selectRandomWord()
        {
            return "";
        }
 
    }
}
