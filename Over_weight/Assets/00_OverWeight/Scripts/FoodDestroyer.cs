using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour
{
    [SerializeField] Transform camTrans;
    private void Start()
    {
        camTrans = StaticObjs.mainCam.transform;
    }
    private void LateUpdate()
    {
        if(camTrans.InverseTransformPoint(transform.position).z<0)
        {
        
            Destroy(gameObject);
        }
    }
}
