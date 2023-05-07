namespace FormGenerator.HtmlGenerator
{
    public static class ListHelper
    {
        public static void MoveListItem<T>(List<T> list, bool up, Predicate<T> comparer)
        {
            if (list.Count < 2)
            {
                return;
            }

            int index = list.FindIndex(comparer);

            if (index == -1)
            {
                return;
            }

            int swapIndex = up ?
                (index == 0 ? list.Count - 1 : index - 1) :
                (index == list.Count - 1 ? 0 : index + 1);

            T temp = list[swapIndex];
            list[swapIndex] = list[index];
            list[index] = temp;
        }
    }
}