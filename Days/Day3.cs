// Puzzle opened in 0:02
// Note to future employers: no this isn't how I normally lex
// But I am proud of how fast I cobbled it together
public static class Day3 {
    // Completed in 7:15 as I had a c <= '0' || c >= '9' then realized I instead needed > and <
    // Rank 2749
    public static void part1() {
        string input = InputGetter.GetStringInput();
        bool inMul = false;
        long ans = 0;
        bool doMult = true;
        for (int i = 0; i < input.Length - 4; i++) {
            if (inMul) {
                long first = 0;
                while (input[i] != ',') {
                    // Debug.Log("At first " + input[i]);
                    char c = input[i];
                    if (c < '0' || c > '9') {
                        inMul = false;
                        break;
                    }
                    i += 1;
                    c -= '0';
                    first *= 10;
                    first += c;
                }
                if (!inMul)
                    continue;
                i += 1;
                long second = 0;
                while (input[i] != ')') {
                    char c = input[i];
                    // Debug.Log("At second " + input[i]);
                    if (c < '0' || c > '9') {
                        inMul = false;
                        break;
                    }
                    i += 1;
                    c -= '0';
                    second *= 10;
                    second += c;
                }
                
                if (inMul && doMult)
                    ans += first * second;
                inMul = false;

            }
            if (input[i] == 'd' && input[i + 1] == 'o') {
                if (input[i + 2] == 'n' && input[i + 3] == '\'' && input[i + 4] == 't') {
                    doMult = false;
                    i += 4;
                }
                else {
                    doMult = true;
                    i += 2;
                }
            }
            if (input[i] == 'm' && input[i + 1] == 'u' && input[i + 2] == 'l' && input[i + 3] == '(') {
                inMul = true;
                i += 3;
            }
        }
        Debug.Answer(ans);
    }

    // Completed in 9:06 Kind of proud of how fast I integrated the new feature
    // Rank 900 (under 1000 gang :D)
    public static void part2() {
        // Yeah I didn't bother copy and pasting sooooooo :3   
    }
}