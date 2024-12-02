// Puzzle opened in 0:028 because the site was going down and not having a good time
// Tossing 504's and 500's and such :(
public static class Day2 {
    // Completed in 13:10, I could've gone faster but my Intellisense broke for some reason
    // Rank 3129
    public static void part1() {
        string[] inputs = InputGetter.GetStringInputs();
        long safe = 0;

        foreach (string line in inputs) {
            string[] longs = line.Split(" ");

            long curr = long.Parse(longs[0]);
            bool decreasing = curr > long.Parse(longs[1]);
            bool issafe = true;
            for (int i = 1; i < longs.Length; i++) {
                long next = long.Parse(longs[i]);
                 if (((curr > next && decreasing && curr - next <= 3) || (curr < next && !decreasing) && next - curr <= 3) && curr != next) {
                    curr = next;
                }
                else {
                    issafe = false;
                    break;
                }
            }
            if (issafe) {
                Debug.Log(line + " is safe");
                safe += 1;
            }

        }
        Debug.Answer(safe);
    }
    
    // Completed in 16:06, I had a skill issue where I tried "remove" then "Remove" then realized I needed "Remove At"
    // Rank 3726
    public static void part2() {
        string[] inputs = InputGetter.GetStringInputs();
        long safe = 0;

        foreach (string line in inputs) {
            string[] longs = line.Split(" ");
            bool issafe = true;
            for (int removeidx = -1; removeidx < longs.Length; removeidx++) {
                List<string> newlongs = new(longs);
                if (removeidx != -1) {
                    newlongs.RemoveAt(removeidx);
                }

                long curr = long.Parse(newlongs[0]);
                bool decreasing = curr > long.Parse(newlongs[1]);
                for (int i = 1; i < newlongs.Count; i++) {
                    long next = long.Parse(newlongs[i]);
                    if (((curr > next && decreasing && curr - next <= 3) || (curr < next && !decreasing) && next - curr <= 3) && curr != next) {
                        curr = next;
                    }
                    else {
                        issafe = false;
                        break;
                    }
                }
                if (issafe) {
                    Debug.Log(line + " is safe");
                    safe += 1;
                    break;
                }
                else
                    issafe = true;
            }
        }
        Debug.Answer(safe);
    }
}