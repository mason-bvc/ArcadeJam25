using System.Collections.Generic;
using UnityEngine;

public class Signs : MonoBehaviour
{
    [SerializeField] private int chanceToSpawn;
    [SerializeField] private List<GameObject> signs = new List<GameObject>();
    void Start()
    {
        if (Random.Range(0, chanceToSpawn) == 1)
        {
            Instantiate(signs[Random.Range(0, signs.Count)],gameObject.transform);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
