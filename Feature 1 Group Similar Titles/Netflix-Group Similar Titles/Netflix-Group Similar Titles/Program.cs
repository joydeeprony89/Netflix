using System;
using System.Collections.Generic;

namespace Netflix_Group_Similar_Titles
{


//First, we need to figure out a way to individually group all the character combinations of each title.
//Suppose the content library contains the following titles: "duel", "dule", "speed", "spede", "deul", "cars". 
//How would you efficiently implement a functionality so that if a user misspells speed as spede, they are shown the correct title?
//We want to split the list of titles into sets of words so that all words in a set are anagrams. 
//In the above list, there are three sets: { "duel", "dule", "deul"}, {"speed", "spede"}, and
//{ "cars"}. Search results should comprise all members of the set that the search string is found in.
//We should pre-compute these sets instead of forming them when the user searches a title.
    class Program
    {
        static void Main(string[] args)
        {
            var strs = new string[] { "duel", "dule", "speed", "spede", "deul", "cars" }; // ["",""] "eat", "tea", "tan", "ate", "nat", "bat"
            var results = GroupAnagrams(strs);
            string query = "spede";

            foreach (var res in results)
                if(res.Contains(query))
                    Console.WriteLine(string.Join("-",res));
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> results = new List<IList<string>>();
            Dictionary<string, List<string>> kvp = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                List<string> list = new List<string>();
                char[] charArray = new char[26];
                foreach (char ch in str)
                {
                    charArray[ch - 'a']++;
                }

                string key = string.Join("", charArray);
                list.Add(str);
                if (!kvp.ContainsKey(key)) kvp.Add(key, list);
                else
                {
                    list.AddRange(kvp[key]);
                    kvp[key] = list;
                }

            }

            foreach (var val in kvp.Values)
            {
                results.Add(val);
            }

            return results;
        }
    }
}
