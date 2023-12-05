using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    public GameObject goalPrefab;
    public static int tankSize = 5;
    // Start is called before the first frame update
    
    static int numFish = 10;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

    void Start()
    {
        for (int i=0; i< numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
                                      Random.Range(-tankSize,tankSize),
                                      Random.Range(-tankSize,tankSize));
            allFish[i] = (GameObject) Instantiate(fishPrefab, pos, Quaternion.identity);
        }
    }
    void Update()
    {
        if (Random.Range(0,100000 ) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize,tankSize),
                                      Random.Range(-tankSize,tankSize),
                                      Random.Range(-tankSize,tankSize));
            goalPrefab.transform.position = goalPos;
        }
    }
}
