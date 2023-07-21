using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private List<GameObject> pelletPrefabs;
    private int pelletCount=25;
    [SerializeField]GameObject pelletPrefab;
    void Start()
    {
        for(int i=0;i<pelletCount;i++)
        {
            GameObject p=Instantiate(pelletPrefab);
            p.SetActive(true);
            pelletPrefabs.Add(p);

        }
    }
    void ScatterPellets()
    {
        for(int i=0;i<pelletPrefabs.Count;i++)
        {
            //Random Positions
        }
    }

}
