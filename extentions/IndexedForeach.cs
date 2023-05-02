namespace HassakuLab;

public static partial class IndexedForeach
{
    public static IEnumerable<(T item, int index)> Indexed<T>(this IEnumerable<T> source)
    {
        IEnumerable<(T item, int index)> impl()
        {
            var i = 0;
            foreach (var item in source)
            {
                yield return (item, i);
                ++i;
            }
        }

        return impl();
    }
}
