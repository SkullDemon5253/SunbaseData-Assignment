using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnobject : MonoBehaviour
{
    public GameObject circlePrefab;
    public int minCircleCount = 5;
    public int maxCircleCount = 10;

    void Start()
    {
        int circleCount = Random.Range(minCircleCount, maxCircleCount + 1);

        for (int i = 0; i < circleCount; i++)
        {
            Instantiate(circlePrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-2.5f, 2.5f); // Adjust the range based on your screen size
        float y = Random.Range(-4.5f, 4.5f);
        return new Vector3(x, y, 0);
    }
}
