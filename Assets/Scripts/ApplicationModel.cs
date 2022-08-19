using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationModel
{
    public static List<List<string>> PreTestingSet = new List<List<string>>();
    public static List<string> current_sentence;
    public static int set;
    public static int stage;
    public static float time=0f;

    static ApplicationModel()
    {
        PreTestingSet.Add(new List<string> { "I", "LOVE", "YOU" });
        PreTestingSet.Add(new List<string> { "I'M", "THIRSTY" });
        PreTestingSet.Add(new List<string> { "IT'S", "TOO", "HOT" });
        PreTestingSet.Add(new List<string> { "I", "NEED", "HELP" });
        PreTestingSet.Add(new List<string> { "IT'S", "TOO", "HOT" });
        PreTestingSet.Add(new List<string> { "I", "NEED", "HELP" });
        PreTestingSet.Add(new List<string> { "GOOD", "MORNING" });
        PreTestingSet.Add(new List<string> { "THAT'S", "PRETTY" });
        PreTestingSet.Add(new List<string> { "PLEASE", "LISTEN" });
        PreTestingSet.Add(new List<string> { "I", "FEEL", "HAPPY" });
        PreTestingSet.Add(new List<string> { "MY", "STOMACH", "HURTS" });
        PreTestingSet.Add(new List<string> { "I'M", "NOT", "HUNGRY" });
        PreTestingSet.Add(new List<string> { "IT'S", "IMPORTANT" });
        PreTestingSet.Add(new List<string> { "WHAT", "TIME", "IS", "IT?" });
        PreTestingSet.Add(new List<string> { "I", "LIKE", "PIZZA" });
        PreTestingSet.Add(new List<string> { "WHAT", "IS", "YOUR", "NAME?" });
        PreTestingSet.Add(new List<string> { "WHERE", "IS", "THE", "BATHROOM?" });
        PreTestingSet.Add(new List<string> { "YOU", "ARE", "BEAUTIFUL" });

        PreTestingSet.Add(new List<string> { "TODAY", "IS", "MONDAY" });
        PreTestingSet.Add(new List<string> { "I", "WANT", "A", "TISSUE" });
        PreTestingSet.Add(new List<string> { "PLEASE", "PASS", "THE", "BUTTER" });


        PreTestingSet.Add(new List<string> { "THIS", "LOOKS", "AMAZING" });
        PreTestingSet.Add(new List<string> { "IT'S", "RAINING", "OUTSIDE" });
        }
}
