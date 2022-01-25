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
[System.Serializable]
public struct RandomFloatArray
{
    [SerializeField] bool uniqRandom;
    [SerializeField] List<float> randomFloats;
    List<float> tempList;

   
    public float RandomFloat
    {
        get
        {
            if (this.tempList == null)
                this.tempList = new List<float>(this.randomFloats);
            else if(this.tempList.Count==0)
                this.tempList = new List<float>(this.randomFloats);
            if(this.uniqRandom)
            {
                int indx = Random.Range(0,this.tempList.Count);
                float rnum = this.tempList[indx];
                this.tempList.RemoveAt(indx);
                return rnum;
            }
            else
            {
                return this.randomFloats[Random.Range(0, this.randomFloats.Count)];
            }
        }
    }
}