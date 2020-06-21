using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static bool IsNullOrEmpty<T>(this IList<T> list)
    {
        return list == null || list.Count == 0;
    }

    public static bool IsNullOrEmpty<T>(this T[] list)
    {
        return list == null || list.Length == 0;
    }
}
