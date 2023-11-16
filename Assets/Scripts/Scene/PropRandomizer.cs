using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;


    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        //Spawn a random prop at every spawn point
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand;
            if (propPrefabs != null)
            {
                if(propPrefabs.Count - 1 < 0)
                {
                    return;
                }
                else
                {
                    rand = Random.Range(0, propPrefabs.Count - 1);
                }
                
                GameObject prop = Instantiate(propPrefabs[rand], sp.transform.position, Quaternion.identity);
                prop.transform.parent = sp.transform;  //Move spawned object into map
            }
            
        }
    }
}
