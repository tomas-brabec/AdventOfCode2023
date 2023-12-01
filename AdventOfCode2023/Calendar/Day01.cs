using System.Text;

namespace AdventOfCode2023.Calendar;

public class Day01
{
    public List<int> CalibrationValues { get; init; }

    public int GetCalibrationValuesSum => CalibrationValues.Sum();

    private string _inputFileName;

    private Dictionary<char, string> _numbers = new()
    {
        { '1', "one" },
        { '2', "two"},
        { '3', "three"},
        { '4', "four" },
        { '5', "five" },
        { '6', "six"},
        { '7', "seven"},
        { '8', "eight"},
        { '9', "nine"}
    };

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
            StringBuilder buffer = new StringBuilder(5);
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    buffer.Clear();

                    if (firstDigit is null)
                    {
                        firstDigit = c;
                    }

                    lastDigit = c;
                }
                else
                {
                    buffer.Append(c);
                    string bufferdText = buffer.ToString();
                    var matchingNumbers = _numbers.Where(x => x.Value.StartsWith(bufferdText)).ToDictionary();
                    if (matchingNumbers.Count == 0)
                    {
                        if (bufferdText.Length > 2)
                        {
                            for (int i = 1; i < bufferdText.Length; i++)
                            {
                                string text = bufferdText.Substring(i, bufferdText.Length - i);
                                var matchingNumbersCount = _numbers.Where(x => x.Value.StartsWith(text)).Count();
                                if (matchingNumbersCount > 0)
                                {
                                    buffer.Clear();
                                    buffer.Append(text);
                                    break;
                                }
                            }
                        }
                        else 
                        {
                            buffer.Clear();
                            buffer.Append(c);
                        }
                    }
                    else if (matchingNumbers.Count == 1 && matchingNumbers.First().Value == bufferdText)
                    {
                        if (firstDigit is null)
                        {
                            firstDigit = matchingNumbers.First().Key;
                        }

                        lastDigit = matchingNumbers.First().Key;
                        buffer.Clear();
                        buffer.Append(c);
                    }
                }
            }
            CalibrationValues.Add(Convert.ToInt32($"{firstDigit}{lastDigit}"));
        }
        return this;
    }
}
