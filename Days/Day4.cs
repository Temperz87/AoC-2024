// Puzzle opened in 0:02
// This was REALLY hard, but I think I broke down the subproblems well enough
public static class Day4 {
    private static bool checkstr(string line, int idx, char c) {
        return idx >= 0 && idx < line.Length && line[idx] == c;
    }

    private static bool verticalcheckstr(string[] lines, int line, int idx, char c) {
        return line >= 0 && line < lines.Length && checkstr(lines[line], idx, c);
    }


    // Completed in 24:36 because I did idx > 0 and line > 0 instead of >= 0 in my helper functions
    // Rank 5097, my lowest one this year :(
    public static void part1() {
        long count = 0;
        string[] inputs = InputGetter.GetStringInputs();
        for (int i = 0; i < inputs.Length; i++) {
            string line = inputs[i];
            for (int j = 0; j < line.Length; j++) {
                if (line[j] == 'X') {
                    // horizontal check
                    if (checkstr(line, j + 1, 'M') && checkstr(line, j + 2, 'A') && checkstr(line, j + 3, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) horizontal");
                    }
                    // backwards
                    if (checkstr(line, j - 1, 'M') && checkstr(line, j - 2, 'A') && checkstr(line, j - 3, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) backwards");
                    }

                    // vertical
                    if (verticalcheckstr(inputs, i + 1, j, 'M') && verticalcheckstr(inputs, i + 2, j, 'A') && verticalcheckstr(inputs, i + 3, j, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) vertical");
                    }
                    // vertical backwards
                    if (verticalcheckstr(inputs, i - 1, j, 'M') && verticalcheckstr(inputs, i - 2, j, 'A') && verticalcheckstr(inputs, i - 3, j, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) vertical backwards");
                    }

                    // down right
                    if (verticalcheckstr(inputs, i + 1, j + 1, 'M') && verticalcheckstr(inputs, i + 2, j + 2, 'A') && verticalcheckstr(inputs, i + 3, j + 3, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) down right");
                    }
                    // down left
                    if (verticalcheckstr(inputs, i + 1, j - 1, 'M') && verticalcheckstr(inputs, i + 2, j - 2, 'A') && verticalcheckstr(inputs, i + 3, j - 3, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) down left");
                    }

                    // up left
                    if (verticalcheckstr(inputs, i - 1, j - 1, 'M') && verticalcheckstr(inputs, i - 2, j - 2, 'A') && verticalcheckstr(inputs, i - 3, j - 3, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) up left");
                    }
                    // up right
                    if (verticalcheckstr(inputs, i - 1, j + 1, 'M') && verticalcheckstr(inputs, i - 2, j + 2, 'A') && verticalcheckstr(inputs, i - 3, j + 3, 'S')) {
                        count += 1;
                        // Debug.Log($"Found x at ({i}, {j}) up right");
                    }

                }
            }
        }

        Debug.Answer(count);
    }

    // Completed in 37:03 because I printed the right answer but didn't realize I did so so I tried to debug a correct program then realized I'm stupid
    // That or the bug magically fixed itself when I added the debug logs
    // Rank 4531, my second lowest yet :(
    public static void part2() {
        long count = 0;
        string[] inputs = InputGetter.GetStringInputs();
        for (int i = 0; i < inputs.Length; i++) {
            string line = inputs[i];
            for (int j = 0; j < line.Length; j++) {
                if (line[j] == 'A') {

                    // two m on top two m on bottom
                    if (verticalcheckstr(inputs, i - 1, j - 1, 'M') && verticalcheckstr(inputs, i - 1, j + 1, 'M') && verticalcheckstr(inputs, i + 1, j - 1, 'S') && verticalcheckstr(inputs, i + 1, j + 1, 'S')) {
                        // Debug.Log("m top s bottom");
                        count += 1;
                    }

                    // two s on top two m on bottom
                    else if (verticalcheckstr(inputs, i - 1, j - 1, 'S') && verticalcheckstr(inputs, i - 1, j + 1, 'S') && verticalcheckstr(inputs, i + 1, j - 1, 'M') && verticalcheckstr(inputs, i + 1, j + 1, 'M')) {
                        // Debug.Log("s top m bottom");
                        count += 1;
                    }

                    // two m on left two m on right
                    else if (verticalcheckstr(inputs, i - 1, j - 1, 'M') && verticalcheckstr(inputs, i + 1, j - 1, 'M') && verticalcheckstr(inputs, i - 1, j + 1, 'S') && verticalcheckstr(inputs, i + 1, j + 1, 'S')) {
                        // Debug.Log("m left s right");
                        count += 1;
                    }

                    // two s on left two m on right
                    else if (verticalcheckstr(inputs, i - 1, j - 1, 'S') && verticalcheckstr(inputs, i + 1, j - 1, 'S') && verticalcheckstr(inputs, i - 1, j + 1, 'M') && verticalcheckstr(inputs, i + 1, j + 1, 'M')) {
                        // Debug.Log("s left m right");
                        count += 1;
                    }

                }
            }
        }

        Debug.Answer(count);
    }
}