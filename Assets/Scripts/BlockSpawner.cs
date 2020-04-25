using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject[] blocks;

    public float waitingForNextSpawn;
    public float theCountdown;
 
    // the range of X
    [Header ("X Spawn Range")]
    public float xMin;
    public float xMax;
 
 
    public void Update(){
         // timer to spawn the next goodie Object
         theCountdown -= Time.deltaTime;
         if(theCountdown <= 0)
         {
             SpawnBlock();
             theCountdown = waitingForNextSpawn;
         }
    }

    void SpawnBlock(){
        Vector3 pos = new Vector3(Random.Range(xMin,xMax), 6, 5);

        GameObject block = blocks[Random.Range(0, blocks.Length)];

        Instantiate(block, pos, transform.rotation);
    }

}
