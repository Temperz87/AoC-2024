// Puzzle opened in 0:001
public static class Day1 {  // Oh no this is just like java...
    // Completed in 5:50, I was taking my sweet time reading and actually tested on the example input
    // Rank 2460
    public static void part1() {
        string[] input = InputGetter.GetStringInputs();
        List<int> first = new();
        List<int> second = new();
        for (int i = 0; i < input.Length; i++) {
            string[] split = input[i].Split("  ");
            first.Add(int.Parse(split[0]));
            second.Add(int.Parse(split[1].Trim()));
        }
        first.Sort();
        second.Sort();

        long sum = 0;
        for (int i = 0; i < first.Count; i++) {
            sum += Math.Abs(first[i] - second[i]);
        }
        Debug.Answer(sum);
    }

    // Completed in 13:10, I used a hashmap initially then realized you have to consider duplicates
    // Rank 3726
    public static void part2() {
        string[] input = InputGetter.GetStringInputs();
        int[][] first = new int[input.Length][];
        List<int> second = new();
        for (int i = 0; i < input.Length; i++) {
            string[] split = input[i].Split("  ");
            int key = int.Parse(split[0]);
            first[i] = new int[2];
            first[i][0] = key;
            first[i][1] = 0;
        }

        for (int i = 0; i < input.Length; i++) {
            string[] split = input[i].Split("  ");
            int num = int.Parse(split[1].Trim());
            foreach (int[] arr in first) {
                if (arr[0] == num)
                    arr[1] += 1;
            }
        }

        long similarity = 0;
        foreach (int[] score in first) {
            Debug.Log($"Doing {score[0]} {score[1]}");
            similarity += score[0] * score[1];
        }
        Debug.Answer(similarity);
    }
}