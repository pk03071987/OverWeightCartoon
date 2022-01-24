using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Exts 
{
  public static T RandomItem<T>(this T[]items)
    {
        int rIndex = Random.Range(0, items.Length);
        return items[rIndex];
    }
}
