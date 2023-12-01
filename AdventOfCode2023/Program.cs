using AdventOfCode2023.Calendar;

var answerForDay1 = new Day01("Input/Day01")
    .ProcessCalibrationValuesFromFile()
    .GetCalibrationValuesSum;

Console.WriteLine(answerForDay1);