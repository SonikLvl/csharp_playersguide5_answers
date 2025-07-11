//342 The Three Lenses
Console.Title = "The Three Lenses";

int[] intsArray = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };
foreach (var i in ProceduralCode(intsArray))
    Console.WriteLine("ProceduralCode "+ i);
foreach (var i in KeywordQueryExpression(intsArray))
    Console.WriteLine("KeywordQueryExpression " + i);
foreach (var i in MethodCallBasedQueryExpression(intsArray))
    Console.WriteLine("MethodCallBasedQueryExpression " + i);


IEnumerable<int> ProceduralCode(int[] ints)
{
    List<int> list = new List<int>();

    Array.Sort(ints);
    for (int i = 0; i < ints.Length; i++)
    {
        if (ints[i]%2==0)
            list.Add(ints[i]*2);
    }
    return list;
}

IEnumerable<int> KeywordQueryExpression(int[] ints)
{
    return from i in ints
           orderby i
           where i % 2 == 0
           select i*2;
}

IEnumerable<int> MethodCallBasedQueryExpression(int[] ints)
{
    return ints.Order().Where(i => i % 2 == 0).Select(i => i * 2);
}
