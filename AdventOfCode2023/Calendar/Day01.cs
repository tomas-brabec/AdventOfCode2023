namespace AdventOfCode2023.Calendar;

public class Day01
{
    public List<int> CalibrationValues { get; init; }

    public int GetCalibrationValuesSum => CalibrationValues.Sum();

    private string _inputFileName;

    public Day01(string inputFileName)
    {
        _inputFileName = inputFileName;
        CalibrationValues = new List<int>(1000);
    }

    public Day01 ProcessCalibrationValuesFromFile() 
    {
        foreach (string line in File.ReadLines(_inputFileName)) 
        {
            char? firstDigit = null;
            char? lastDigit = null;
            foreach (char c in line) 
            {
                if (!char.IsDigit(c))
                    continue;

                if (firstDigit is null)
                {
                    firstDigit = c;
                }

                lastDigit = c;
            }
            CalibrationValues.Add(Convert.ToInt32($"{firstDigit}{lastDigit}"));
        }
        return this;
    }
}
