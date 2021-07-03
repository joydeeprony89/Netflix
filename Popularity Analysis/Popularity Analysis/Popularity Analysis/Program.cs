using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popularity_Analysis
{
    class Program
    {
        //Netflix maintains a popularity score for each of its titles. 
        //This popularity score is derived from customer feedback, likes, dislikes, etc
        //This score is updated weekly and added to the end of an array containing previous scores for the same title.
        //This score array helps Netflix identify titles that may be increasing or decreasing in popularity over time.
        //Some titles may be steady in popularity, increasing, decreasing, and fluctuating.
        //We want to identify and separate a title if it is gaining or losing popularity.

        //We’ll be provided with an array of integers representing the popularity scores of a movie collected over a number of weeks.
        //We need to identify only those titles that are either increasing or decreasing in popularity, so we can separate them from the fluctuating ones for better analysis.
        static void Main(string[] args)
        {
            int[][] movie_ratings = 
                {
                    {1,2,2,3},
                    {4,5,6,3,4},
                    {8,8,7,6,5,4,4,1}
                };
            for (int[] movie_rating : movie_ratings){
                if (IdentifyTitles(movie_rating))
                    Console.WriteLine("Title Identified and Separated");
                else
                    Console.WriteLine("Title Score Fluctuating");
            }
        }

        public static bool IdentifyTitles(int[] scores) 
        {
            bool increasing = true;
            bool decreasing = true;

            for (int i = 0; i < scores.Length - 1; i++) {
                if (scores[i] > scores[i+1])
                    increasing = false;
                if (scores[i] < scores[i+1])
                    decreasing = false;
            }
            return (increasing || decreasing);
        }
    }
}
