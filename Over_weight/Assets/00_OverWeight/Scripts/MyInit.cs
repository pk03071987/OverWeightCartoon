using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInit : MonoBehaviour
{
   List<IMyStart> customStart;
  List<IMyAwake> customAwake;
    [SerializeField] Transform parentComponent;

    private void Awake()
    {
        if (customAwake == null)
            customAwake = new List<IMyAwake>();
        if(parentComponent!=null)
        customAwake.AddRange(parentComponent.GetComponentsInChildren<IMyAwake>());
        int c = customAwake.Count;
        if (c>0)
        {
            for(int i=0;i<c;i++)
            {
                customAwake[i].MyAwake();
            }
        }
    }
    private void Start()
    {
        if (customStart == null)
            customStart = new List<IMyStart>();
        if (parentComponent != null)
            customStart.AddRange(parentComponent.GetComponentsInChildren<IMyStart>());
        int c = customStart.Count;
        if(c>0)
        {
            for(int i=0;i<c;i++)
            {
                customStart[i].MyStart(i);
            }
        }
    }
}
interface IMyStart
{
    void MyStart(int executionIndex);
}
interface IMyAwake
{
    void MyAwake();
}
