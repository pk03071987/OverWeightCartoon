using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHelicopters : MonoBehaviour
{
    public int index = 0;
    float[] randomSpeeds = new float[] { 20, 24, 27, 30, 17, 20, 24, 27, 30 };
    [SerializeField] float maxSpeed, minSpeed;
    float speed;
    [SerializeField]
    Transform cam;
    [SerializeField] float minX, maxx;
    [SerializeField] float minY, maxY;
    [SerializeField] float minz, maxz;
    bool isInited = false;
    Vector3 forward;
    private void Start()
    {
        forward = transform.forward;
        StartCoroutine(DelayStart());
    }
    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(index*2f);
        isInited = true;
        StartCoroutine(DoRandomize(true));
    }
    private void Update()
    {
        if(isInited)
        transform.Translate(transform.forward * Time.deltaTime*speed);
    }

    public void RandomPosition()
    {
        StartCoroutine(DoRandomize());
    }
    IEnumerator DoRandomize(bool dontRandomize=false)
    {
        if(!dontRandomize)
        yield return new WaitForSeconds(Random.Range(3, 5));
        speed =randomSpeeds[Random.Range(0, randomSpeeds.Length)]*-1f;
        transform.SetParent(cam);
        transform.localPosition = new Vector3(Random.Range(minX, maxx), Random.Range(minY, maxY), Random.Range(minz, maxz));
        transform.parent = null;
    }
}
