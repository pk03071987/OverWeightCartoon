using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPillars : MonoBehaviour
{

    [SerializeField] Transform camTrans;
    Vector3 localPos;

    void LateUpdate()
    {
       localPos=camTrans.InverseTransformPoint(transform.position);
        if (localPos.z < 0)
            Destroy(gameObject);
    }
}
