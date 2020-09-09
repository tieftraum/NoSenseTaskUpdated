using System;
using System.Collections.Generic;
using System.Text;

namespace NoSenseTask.Helpers
{
    public static class HelperTools
    {
        public static IEnumerable<int> StringToIntEnumerable(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                yield break;
            }

            foreach (var s in text.Split(','))
            {
                int num;
                if (int.TryParse(s, out num))
                {
                    yield return num;
                }
            }
        }
        public static bool IsInArray(this int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
