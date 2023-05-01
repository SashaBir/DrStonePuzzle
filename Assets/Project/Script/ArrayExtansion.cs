namespace Puzzle
{
    public static class ArrayExtansion
    {
        public static T[] Shuffle<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var index = UnityEngine.Random.Range(0, array.Length);
                (array[i], array[index]) = (array[index], array[i]);
            }

            return array;
        }
    }
}