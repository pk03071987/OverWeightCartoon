using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HelicopterVisibility : MonoBehaviour
{
    [SerializeField] UnityEvent onHidden;
    private void OnBecameInvisible()
    {
        onHidden?.Invoke();
    }
}
