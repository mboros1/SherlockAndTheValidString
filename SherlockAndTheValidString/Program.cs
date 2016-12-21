/*  A program that takes a string, s, from the Hackerrank standard input
    whose length is up to 10^5 char's long, and determines whether it's
    a "proper string", in that each char has an equal count or will have
    an equal count if exactly one char is deleted.  */

using System;
using System.Collections.Generic;
class Methods
{
    /* Method that converts a string to a dictionary that contains every 
       lower-case char and their count. Since the order of the chars in the
       string are irrelevant to this problem, it dramatically cuts down on
       computation time to work with a Dictionary with 26 entries.  */
    public static Dictionary<char, int> AlphabetHash(string s)
    {
        Dictionary<char, int> Hash = new Dictionary<char, int>();

        for (int i = 97; i <= 122; i++)
        {
            Hash.Add((char)i, 0);
        }
        int n = s.Length;

        for (int i = 0; i < n; i++) Hash[s[i]]++;

        return Hash;
    }
    /*  Loops through the AlphabetHash and determines whether each char
     *  has an equal count. */
    public static bool AreCharCountsEqual(Dictionary<char, int> Hash)
    {
        bool answer = false;
        int count1 = 0;
        int count = 0;

        for (int i = 97; i <= 122; i++)
        {
            for (int j = 97; j <= 122; j++)
            {
                if (Hash[(char)i] > 0 && Hash[(char)j] > 0)
                {
                    count1++;
                    if (Hash[(char)i] == Hash[(char)j])
                    {
                        count++;
                    }
                }
            }
            if (count == count1 && count > 0)
            {
                answer = true;
                break;
            }
            else
            {
                count = 0;
                count1 = 0;
            }
        }
        return answer;
    }
    /*  A method that determines if you can get the chars to have an equal
     *  count when exactly one char is deleted. Brute force problem, but since
     *  the Dictionary is so small computation time is insignificant.
     */
    public static bool CharCountsWithinOne(Dictionary<char, int> Hash)
    {
        bool answer = false;
        int count = 0;
        int count1 = 0;
        for (int i = 97; i <= 122; i++)
        {
            Dictionary<char, int> CheckHash = new Dictionary<char, int>(Hash);

            CheckHash[(char)i]--;

            for (int j = 97; j <= 122; j++)
            {
                for (int k = 97; k <= 122; k++)
                {
                    if (CheckHash[(char)j] > 0 && CheckHash[(char)k] > 0)
                    {
                        if (CheckHash[(char)j] == CheckHash[(char)k])
                        {
                            count++;
                        }
                        count1++;
                    }
                }
                if (count == count1 && count > 0)
                {
                    answer = true;
                    break;
                }
                else
                {
                    count = 0;
                    count1 = 0;
                }
            }
            if (answer)
            {
                break;
            }
        }
        return answer;
    }
}

class Solution
{
    static void Main(String[] args)
    {
        string s = Console.ReadLine();

        Dictionary<char, int> sHash = Methods.AlphabetHash(s);

        bool answer = Methods.AreCharCountsEqual(sHash);

        if (answer)
        {
            Console.WriteLine("YES");
        }
        else
        {
            answer = Methods.CharCountsWithinOne(sHash);
            
            if (answer)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}