using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarCreater : MonoBehaviour
{
    [SerializeField] GameObject pillarPref;
    [SerializeField] Transform leftSideStartPos;
    [SerializeField] Transform rightSideStartPos;
    [SerializeField] float forwardDistance_min;
    [SerializeField] float forwardDistance_max;
    [SerializeField] float minSideDistance;
    [SerializeField] float maxSideDistance;
    [SerializeField] float minYDicrement;
    [SerializeField] float maxYDicrement;
    [SerializeField] int numberOfSTartingPillars = 20;


    private void Start()
    {
        StartCoroutine(CreatePillarsAtSTart());
    }
    IEnumerator CreatePillarsAtSTart()
    {
        int count = 0;
        float lf = leftSideStartPos.position.x;
        float rf = rightSideStartPos.position.x;
        float yPos = leftSideStartPos.position.y;
        float Z = leftSideStartPos.position.z;
        float lfMulti = -1f;
        float rfMutli = 1f;
        while(count< numberOfSTartingPillars)
        {
            CreatePillar(lf+ (XValue*lfMulti), yPos,Z+VriableValue(1f,2f));
            CreatePillar(rf+ (XValue*rfMutli), yPos,Z+VriableValue(1f,2f));
            yPos -= Random.Range(minYDicrement,maxYDicrement);
            Z += zDifference;
            
        yield return null;
            lfMulti *= -1f;
            rfMutli *= -1f;
            count++;
        }
    }

    float VriableValue(float mn_,float mx_)
    {
        return Random.Range(mn_, mx_) * (Random.Range(0,9)%2==0?-1f:1f);
    }
    public GameObject CreatePillar(float xpos,float ypos,float zpos)
    {
       
            GameObject g = Instantiate(pillarPref);
        g.transform.position = new Vector3(xpos, ypos, zpos);
        g.SetActive(true);
            return g;
        
    }

    float XValue => Random.Range(minSideDistance, maxSideDistance);
    float zDifference => Random.Range(forwardDistance_min, forwardDistance_max);
}
