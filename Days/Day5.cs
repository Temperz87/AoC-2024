// Puzzle opened in 0:01
// This puzzle wasn't hard I was just very tired and stressed while writing it
public static class Day5 {

    private static Dictionary<long, List<long>> rules = new();

    private static void AddConflict(long before, long after) {
        if (rules.ContainsKey(before))
            rules[before].Add(after);
        else
            rules.Add(before, [after]);
    }

    private static List<long> GetConflicts(long before) {
        if (rules.ContainsKey(before))
            return rules[before];
        return new();
    }

    private static bool ConflictsWith(long before, long after) {
        return rules.ContainsKey(before) && rules[before].Contains(after);
    }

    // Completed in 18:11, honestly I did fine on this part
    // Rank 3548
    public static void part1() {
        string[] inputs = InputGetter.GetStringInputs();

        int i = 0;
        for (; inputs[i].Length != 0; i++) {
            string[] split = inputs[i].Split("|");
            AddConflict(long.Parse(split[0]), long.Parse(split[1]));
        }

        List<long> middleNums = new();
        
        for (i += 1; i < inputs.Length; i++) {
            List<long> seen = new();
            bool isValid = true;

            string[] split = inputs[i].Split(",");
            foreach (string s in split) {
                long l = long.Parse(s);
                Debug.Log("Doing " + l);
                Debug.Log("seen:");
                foreach (long lo in seen) {
                    Debug.Log("\t" + lo);
                }
                foreach (long conflict in GetConflicts(l)) {
                    Debug.Log($"checking {conflict}");
                    if (seen.Contains(conflict)) {
                        Debug.LogWarning("Broken!");
                        isValid = false;
                        break;
                    }
                }
                Debug.Log("\n");
                if (!isValid)
                    break;
                seen.Add(l);
            }

            if (isValid) {
                seen.Order(); // For some reason this didn't break my part 1????
                Debug.Log($"Got valid page {inputs[i]} of middle {seen[seen.Count / 2]}");
                middleNums.Add(seen[seen.Count / 2]);
            }
        }

        Debug.Answer(middleNums.Sum());
    }

    // tfw c# doesn't do TCO
    private static List<long> correctlyOrderRecursive(List<long> ls) {
        if (ls.Count == 0)
            return ls;
        long checking = ls[0];
        List<long> newls = new(ls);
        
        for (int i = 1; i < ls.Count; i++) {
            if (ConflictsWith(ls[i], checking)) {
                newls.RemoveAt(0);
                newls.Insert(i, checking);
                return correctlyOrderRecursive(newls);
            }
        }

        newls.RemoveAt(0);
        List<long> another = correctlyOrderRecursive(newls);
        another.Insert(0, checking);
        return another;
    }

    private static List<long> correctlyOrder(List<long> ls) {
        List<long> correct = new();
        int desiredlen = ls.Count;

        while (correct.Count != desiredlen) {
            
            bool recur = true;
            while (recur) {
                long checking = ls[0];
                recur = false;
                for (int i = 1; i < ls.Count; i++) {
                    if (ConflictsWith(ls[i], checking)) {
                        ls.RemoveAt(0);
                        ls.Insert(i, checking);
                        recur = true;
                        break;
                    }
                }
            }

            correct.Add(ls[0]);
            ls.RemoveAt(0);    
        }
      
        Debug.Log("Returning");
        foreach (long l in correct) {
            Console.Write($"{l},");
        }
        Debug.Log('\n');
        return correct;
    }

    // Completed in 14:05:17 because I tried debugging for an hour then gave up and eep'd
    // I didn't wanna write a helper function for some reason so that is what ultimately did me in
    // Rank 46880 (I'm cooked chat)
    public static void part2() {        
        string[] inputs = InputGetter.GetStringInputs();

        int i = 0;
        for (; inputs[i].Length != 0; i++) {
            string[] split = inputs[i].Split("|");
            AddConflict(long.Parse(split[0]), long.Parse(split[1]));
        }

        List<long> middleNums = new();
        
        for (i += 1; i < inputs.Length; i++) {
            List<long> seen = new();
            bool isValid = true;

            string[] split = inputs[i].Split(",");
            foreach (string s in split) {
                long l = long.Parse(s);
                
                if (isValid) {
                    foreach (long conflict in GetConflicts(l)) {
                        if (seen.Contains(conflict)) {
                            isValid = false;
                            break;
                        }
                    }
                }
                seen.Add(l);
            }

            if (!isValid) {
                int idx = seen.Count / 2;
                long mid = correctlyOrder(seen)[idx];
                Debug.Log("Got middle num " + mid + " at " + idx);
                middleNums.Add(mid);
            }
        }

        Debug.Answer(middleNums.Sum());
    }
}