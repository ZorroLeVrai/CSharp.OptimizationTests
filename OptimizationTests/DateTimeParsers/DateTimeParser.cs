using System.Globalization;

namespace OptimizationTests.DateTimeParsers
{
    public delegate int ParseIntDelegate(ReadOnlySpan<char> text);

    public class DateTimeParser
    {
        private static readonly char[] SplitChars = new[] { '-', ':', 'T', 'Z' };

        public bool TryParseDateTimeFromStr(string dateTimeString, out DateTime dateTime)
        {
            return DateTime.TryParse(dateTimeString, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime);
        }

        public bool TryParseDateFromSpan(ReadOnlySpan<char> dateTimeSpan, out DateTime dateTime)
        {
            return DateTime.TryParse(dateTimeSpan, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime);
        }

        public bool TryParseDateUsingSplits(string dateTimeString, out DateTime dateTime)
        {
            var dateSplits = dateTimeString.Split(SplitChars);

            try
            {
                dateTime = new DateTime(int.Parse(dateSplits[0]), int.Parse(dateSplits[1]), int.Parse(dateSplits[2]), int.Parse(dateSplits[3]), int.Parse(dateSplits[4]), int.Parse(dateSplits[5]), DateTimeKind.Utc);
                return true;
            }
            catch (Exception) {
                dateTime = DateTime.MinValue;
                return false;
            }                        
        }

        public bool TryParseDateUsingSlicesWithCustomConverter(ReadOnlySpan<char> dateTimeSpan, ParseIntDelegate intConverter, out DateTime dateTime)
        {
            try
            {
                int year = intConverter(dateTimeSpan.Slice(0, 4));
                int month = intConverter(dateTimeSpan.Slice(5, 2));
                int day = intConverter(dateTimeSpan.Slice(8, 2));
                int hour = intConverter(dateTimeSpan.Slice(11, 2));
                int minute = intConverter(dateTimeSpan.Slice(14, 2));
                int second = intConverter(dateTimeSpan.Slice(17, 2));
                dateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
                return true;
            }
            catch (Exception)
            {
                dateTime = DateTime.MinValue;
                return false;
            }
        }

        private static int IntParserToInt(ReadOnlySpan<char> text) => int.Parse(text);

        private static int FastParserToInt(ReadOnlySpan<char> text)
        {
            int result = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                result = 10*result + (text[i] - '0');
            }

            return result;
        }

        public bool TryParseDateUsingSlices(ReadOnlySpan<char> dateTimeSpan, out DateTime dateTime)
        {
            return TryParseDateUsingSlicesWithCustomConverter(dateTimeSpan, IntParserToInt, out dateTime);
        }

        public bool TryParseDateUsingSlicesCustomParser(ReadOnlySpan<char> dateTimeSpan, out DateTime dateTime)
        {
            return TryParseDateUsingSlicesWithCustomConverter(dateTimeSpan, FastParserToInt, out dateTime);
        }
    }
}
