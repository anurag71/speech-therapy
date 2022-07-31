using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationModel
{
    public static List<List<string>> TrialSet =  new List<List<string>>();
    public static List<List<string>> PreTestingSet = new List<List<string>>();
    public static List<List<string>> PracticeSet = new List<List<string>>();
    public static List<List<string>> PostTestingSet = new List<List<string>>();
    public static List<string> current_sentence;
    public static int set;

    static ApplicationModel()
    {
            TrialSet.Add(new List<string> { "SIT", "DOWN" });
            TrialSet.Add(new List<string> { "RUN", "FAST" });
       
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
        
            PracticeSet.Add(new List<string> { "I", "LOVE", "IT" });

        PracticeSet.Add(new List<string> { "I'M", "TIRED" });
        PracticeSet.Add(new List<string> { "IT'S", "TOO", "COLD" });
        PracticeSet.Add(new List<string> { "I", "NEED", "SPACE" });

        PracticeSet.Add(new List<string> { "I", "DON'T", "CARE" });
        PracticeSet.Add(new List<string> { "GOOD", "EVENING" });
        PracticeSet.Add(new List<string> { "THAT'S", "OKAY" });

        PracticeSet.Add(new List<string> { "PLEASE", "REPEAT" });
        PracticeSet.Add(new List<string> { "I", "FEEL", "SLEEPY" });
        PracticeSet.Add(new List<string> { "MY", "FINGER", "HURTS" });

        PracticeSet.Add(new List<string> { "I'M", "NOT", "READY" });
        PracticeSet.Add(new List<string> { "IT'S", "PERSONAL" });
        PracticeSet.Add(new List<string> { "WHAT", "DAY", "IS", "IT?" });


        PracticeSet.Add(new List<string> { "I", "LIKE", "MUSIC" });
        PracticeSet.Add(new List<string> { "WHAT", "IS", "YOUR", "JOB?" });
        PracticeSet.Add(new List<string> { "WHERE", "IS", "THE", "DOCTOR?" });

        PracticeSet.Add(new List<string> { "YOU", "ARE", "ANNOYING" });
        PracticeSet.Add(new List<string> { "TODAY", "IS", "FRIDAY" });
        PracticeSet.Add(new List<string> { "I", "WANT", "A", "BLANKET" });

        PracticeSet.Add(new List<string> { "PLEASE", "PASS", "THE", "PEPPER" });
        PracticeSet.Add(new List<string> { "THIS", "SMELLS", "AMAZING" });
        PracticeSet.Add(new List<string> { "IT'S", "SUNNY", "OUTSIDE" });
        
            PostTestingSet.Add(new List<string> { "I", "LOVE", "DOGS" });
        PostTestingSet.Add(new List<string> { "I'M", "SORRY" });
        PostTestingSet.Add(new List<string> { "IT'S", "TOO", "LOUD" });

        PostTestingSet.Add(new List<string> { "I", "NEED", "IT" });
        PostTestingSet.Add(new List<string> { "GOOD", "THINKING" });
        PostTestingSet.Add(new List<string> { "THAT'S", "FUNNY" });

        PostTestingSet.Add(new List<string> { "PLEASE", "ANSWER" });
        PostTestingSet.Add(new List<string> { "I", "FEEL", "BETTER" });
        PostTestingSet.Add(new List<string> { "MY", "SHOULDER", "HURTS" });

        PostTestingSet.Add(new List<string> { "I'M", "NOT", "BUSY" });
        PostTestingSet.Add(new List<string> { "IT'S", "CONFUSING" });
        PostTestingSet.Add(new List<string> { "WHAT", "MONTH", "IS", "IT?" });

        PostTestingSet.Add(new List<string> { "I", "LIKE", "COOKIES" });
        PostTestingSet.Add(new List<string> { "WHAT", "IS", "YOUR", "AGE?" });
        PostTestingSet.Add(new List<string> { "WHERE", "IS", "THE", "COFFEE?" });

        PostTestingSet.Add(new List<string> { "YOU", "ARE", "GENEROUS" });
        PostTestingSet.Add(new List<string> { "TODAY", "IS", "SUNDAY" });
        PostTestingSet.Add(new List<string> { "I", "WANT", "A", "SANDWICH" });

        PostTestingSet.Add(new List<string> { "PELASE", "PASS", "THE", "SALAD" });
        PostTestingSet.Add(new List<string> { "THIS", "FEELS", "AMAZING" });
        PostTestingSet.Add(new List<string> { "IT'S", "WINDY", "OUTSIDE" });
        }
}
