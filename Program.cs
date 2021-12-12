//=============================================================================
// Code created for Mantel Group Future Associates Program Interview 13.12.2021
// Functions find: 
//      - The number of unique IP addresses
//      - The top 3 most visited URLs
//      - The top 3 most active IP addresses
// @author: Madison Beare
//=============================================================================
using System.Collections.Generic;
using System.Linq;

namespace System.Text.RegularExpressions
{
    namespace Mantel_Group
    {
        public class Program
        {
            SortedDictionary<string, int> numberDict = new SortedDictionary<string, int>();
            SortedDictionary<string, int> urlDict = new SortedDictionary<string, int>();
            int consolePrint;
            public static String filename()
            {
                //filepath to be substituted accordingly
                return @"C:\Users\madis\Desktop\Files\Employment\Mantel Group\test_data.log";
            }
            public static void Main(string[] args)
            {
                Program IPAddresses = new Program();
                IPAddresses.UniqueIPAddresses();

                Program urlProgram = new Program();
                urlProgram.TopThreeURLs();

                Program TopThreeIP = new Program();
                TopThreeIP.MostActiveIPAddresses();
            }

            /**
            Method to test the no. of UniqueIPAddresses
            **/
            public SortedDictionary<string, int> UniqueIPAddresses()
            {
                int i = 0;
                foreach (string line in System.IO.File.ReadLines(filename()))
                {
                    //IPv4 validation regex. Further detail/source: https://www.debuggex.com/r/-EDZOqxTxhiTncN6/1
                    string pattern = @"\b^(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))";
                    Regex r = new Regex(pattern);
                    string input = line;
                    MatchCollection matches = r.Matches(input);

                    foreach (Match match in matches)
                    {
                        if (numberDict.ContainsKey(match.Value))
                        {
                            numberDict[match.Value]++;
                        }
                        else
                        {
                            numberDict.Add(match.Value, 1);
                        }
                    }
                    i++;
                }
                UniqueIPAddressCount();
                return numberDict;
            }

            /**
            Method to obtain the top 3 URLs
            **/
            public void TopThreeURLs()
            {
                foreach (string line in System.IO.File.ReadLines(filename()))
                {
                    //Regex for 'looks ahead' of GET and 'looks behind' HTTP
                    string URLExtractPattern = "(?<=GET )(.*)(?= HTTP)";
                    Regex URL = new Regex(URLExtractPattern);
                    string input = line;
                    MatchCollection URLMatches = URL.Matches(input);

                    foreach (Match match in URLMatches)
                    {
                        if (urlDict.ContainsKey(match.Value))
                        {
                            urlDict[match.Value]++;
                        }
                        else
                        {
                            urlDict.Add(match.Value, 1);
                        }
                    }
                }
                int top3 = 1;
                //takes the sorted dictionary (sorted by key) and resorts by descending value
                var sortedDict = from entry in urlDict orderby entry.Value descending select entry;
                foreach (KeyValuePair<string, int> kvp in sortedDict)
                {
                    if (top3 < 4)
                    {
                        Console.WriteLine("mostVisitedURLs = {0}, Times Visited = {1}", kvp.Key, kvp.Value);
                        top3++;
                    }
                }
                NumberOfURLsFound();
                Console.WriteLine();
            }

            /**
            Method to obtain the most active IP addresses
            **/
            public void MostActiveIPAddresses()
            {
                int top3 = 1;
                consolePrint = 1;
                var allSortedIPaddresses = UniqueIPAddresses();
                //takes the sorted dictionary (sorted by key) and resorts by descending value
                var sortedDict = from entry in allSortedIPaddresses orderby entry.Value descending select entry;
                foreach (KeyValuePair<string, int> kvp in sortedDict)
                {
                    if (top3 < 4)
                    {
                        Console.WriteLine("TopIPAddresses = {0}, Times Active = {1}", kvp.Key, kvp.Value);
                        top3++;
                    }
                }
                Console.WriteLine();
            }

            /**
            Method to return the number of unique IP Addresses
            **/
            public int UniqueIPAddressCount()
            {
                int IPAddressessCount = numberDict.Count();
                if (consolePrint < 1)
                {
                    Console.WriteLine("Number of unique IP addresses: " + IPAddressessCount);
                    Console.WriteLine();
                }
                return IPAddressessCount;
            }

            /**
            Method to return the number of unique URLs found
            **/
            public int NumberOfURLsFound()
            {
                int URLCount = urlDict.Count();
                return URLCount;
            }
        }
    }
}