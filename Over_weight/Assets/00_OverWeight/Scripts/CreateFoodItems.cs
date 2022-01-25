using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFoodItems : MonoBehaviour
{
    [SerializeField] RandomFloatArray yDifferenceArray;
    RandomInts randomFooodIndexes;
    [SerializeField] RangeValue startFood_creationDelay;
    [SerializeField] GameObject pillarPrefab;
    [SerializeField] GameObject[] foodsPrefab;
    [SerializeField] Transform playerTrans;


    [SerializeField] RangeValue pillarXScale;
    [SerializeField] float[] pillarZScale;
    [SerializeField] float miny = .5f;
    [SerializeField] float maxY = 1f;

    [SerializeField] float minZ = 2f;
    [SerializeField] float maxZ = 3f;
    [SerializeField] float foodelayMin = .5f;
    [SerializeField] float foodelayMax = 1f;
    [SerializeField] bool createFoods = false;
    [SerializeField] float minDist = 0;
    float lastZValue = 0f;


    //[SerializeField] GameObject[] pillarPrefabs;

    private void Start()
    {
        randomFooodIndexes = new RandomInts(0, foodsPrefab.Length);
        StartCoroutine(FoodCreaterLoop());
    }
    IEnumerator FoodCreaterLoop()
    {
        yield return new WaitForSeconds(startFood_creationDelay.value);
        while (true)
        {
            if (createFoods)
            {
                CreateFoodPillar();
                yield return new WaitForSeconds(Random.Range(foodelayMin, foodelayMax));
            }
            yield return null;
        }
    }
    GameObject CreateFoodPillar()
    {
        GameObject g = Instantiate(pillarPrefab);
        //int number = Random.Range(0, pillarPrefabs.Length - 1);
        //GameObject g = Instantiate(pillarPrefabs[number]);
        Vector3 playerPos = playerTrans.position;
        Vector3 newFoodPillarPos = playerPos + Vector3.forward * Random.Range(minZ, maxZ);
        newFoodPillarPos.y -= Random.Range(miny, maxY);
      //  newFoodPillarPos.x = pillarPrefabs[number].transform.position.x;
        if (lastZValue == 0)
        {
            lastZValue = newFoodPillarPos.z;
        }
        else
        {
            if (Mathf.Abs(newFoodPillarPos.z - lastZValue) < minDist)
            {
                newFoodPillarPos.z = lastZValue + minDist;
            }
            lastZValue = newFoodPillarPos.z;
        }
        g.transform.position = newFoodPillarPos;
        g.SetActive(true);
        CreateFoodsOnPillar(g.transform);
        Destroy(g, 8f);
        return g;
    }

    void CreateFoodsOnPillar(Transform pillarObj)
    {
        Vector3 LScale = pillarObj.localScale;
        LScale.x = pillarXScale.value;
        LScale.z = pillarZScale.RandomItem();
        pillarObj.localScale = LScale;
        GameObject g = NewFood();
        Vector3 pillarCenter = pillarObj.position + Vector3.up * .5f;
        if (LScale.z >= 8f)
        {
            Vector3 p1 = pillarObj.InverseTransformPoint(pillarCenter);
            Vector3 p2 = pillarObj.InverseTransformPoint(pillarCenter);
            p1.z -= .35f;
            p1 = pillarObj.TransformPoint(p1);
            g.transform.position = p1;
            p2.z += .35f;
            p2 = pillarObj.TransformPoint(p2);
            NewFood().transform.position = p2;
        }
        else
        {
            g.transform.position = pillarCenter;
        }

    }
    GameObject NewFood()
    {
        GameObject g = Instantiate(foodsPrefab[randomFooodIndexes.RValue]);
        Vector3 scl = g.transform.localScale;
        scl *= .6f;
        g.transform.localScale = scl;
        return g;
    }
}
[System.Serializable]
public struct RangeValue
{
    public float min;
    public float max;
    public float value => Random.Range(min, max);
}
public struct RandomInts
{
    int min, max;
    List<int> numbers;
    public RandomInts(int min_, int max_)
    {
        this.min = min_;
        this.max = max_;
        this.numbers = new List<int>();
        this.InitNums();
    }
    public int RValue
    {
        get
        {
            if (this.numbers.Count <= 0)
                this.InitNums();
            int rindex = Random.Range(0, this.numbers.Count);
            int rnum = this.numbers[rindex];
            this.numbers.RemoveAt(rindex);
            return rnum;
        }
    }
    void InitNums()
    {

        for (int i = this.min; i < this.max; i++)
            this.numbers.Add(i);

    }
}