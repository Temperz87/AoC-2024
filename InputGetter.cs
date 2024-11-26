﻿public static class InputGetter {
    private const string filePath = "inputs.txt";

    public static string[] GetStringInputs() => File.ReadAllLines(filePath);
    
    public static string GetStringInput() => File.ReadAllText(filePath);

    public static int[] GetIntInputs() {
        string[] lines = File.ReadAllLines(filePath);
        int[] ints = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++) {
            ints[i] = int.Parse(lines[i]);
        }
        return ints;
    }

    public static long[] GetLongInputs() {
        string[] lines = File.ReadAllLines(filePath);
        long[] longs = new long[lines.Length];
        for (int i = 0; i < lines.Length; i++) {
            longs[i] = long.Parse(lines[i]);
        }
        return longs;
    }
}


public static class Debug { // Unity Reference????????
    private const bool debug = true;
    public static void Log(object message) {
        if (debug)
            Console.WriteLine(message);
    }

    public static void Log(object message, ConsoleColor color) => LogColored(message, color);
    public static void LogWarning(object message) => LogColored(message, ConsoleColor.Yellow);
    public static void LogError(object message) => LogColored(message, ConsoleColor.Red);

    public static void LogAnswer(object message) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void LogColored(object message, ConsoleColor color) {
        if (!debug)
            return;

        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}