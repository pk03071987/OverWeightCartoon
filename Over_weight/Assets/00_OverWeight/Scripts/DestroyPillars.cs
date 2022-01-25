using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPillars : MonoBehaviour,IMyStart
{
    [SerializeField] bool checkZpos = false;
    private static System.Action<Transform> OnPillarPositionChange;
    [SerializeField] Transform lastPillar;
    [SerializeField] float[] randomYDifferences= { 8,-2,9,-3,10,-4};
    [SerializeField] RandomFloatArray ydiffrence;
    [SerializeField] RandomFloatArray zdiffrence;
    private static float lastY;
    private static float lastZ;
    [SerializeField] float localZ;
   
    [SerializeField] Transform camTrans;
    Vector3 localPos;
    private void Start()
    {
       
        OnPillarPositionChange += SetLastPillar;
    }
    private void OnDestroy()
    {
        OnPillarPositionChange -= SetLastPillar;
    }
    void SetLastPillar(Transform newLastPillar)
    {
        lastPillar = newLastPillar;
    }
    public void MyStart(int executionIndex)
    {
      
          lastY= transform.position.y;
        lastZ = transform.position.z;
    }
    void LateUpdate()
    {
       localPos=camTrans.InverseTransformPoint(transform.position);
        if ((localZ=localPos.z) <= 130)
        {
            if(lastPillar!=null)
            {
                Vector3 newPos = lastPillar.position;
                newPos.x = transform.position.x;
                newPos.y -= ydiffrence.RandomFloat;
                newPos.z += zdiffrence.RandomFloat;
                transform.position = newPos;
                transform.SetAsLastSibling();
                OnPillarPositionChange?.Invoke(transform);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
