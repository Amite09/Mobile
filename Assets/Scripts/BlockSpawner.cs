using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject[] blocks;
    public GameObject SuperBox;

    public float waitingForNextSpawn;
    public float theCountdown;

    public float superBoxNextSpawn;
    public float superBoxCountdown;
 
    // the range of X
    [Header ("X Spawn Range")]
    public float xMin;
    public float xMax;
 
 
    public void Update(){
         // timer to spawn the next goodie Object
         theCountdown -= Time.deltaTime;
         if(theCountdown <= 0){
             SpawnBlock();
             theCountdown = waitingForNextSpawn;
        }

        superBoxCountdown -= Time.deltaTime;
        if(superBoxCountdown <= 0){
             SpawnSuperBox();
             superBoxCountdown = superBoxNextSpawn;
        }
    }

    void SpawnBlock(){
        Vector3 pos1 = new Vector3(Random.Range(xMin,xMax), 10, 10);
        Vector3 pos2 = new Vector3(Random.Range(xMin,xMax), 10, 10);
        GameObject block1 = blocks[Random.Range(0, blocks.Length)];
        GameObject block2 = blocks[Random.Range(0, blocks.Length)];
        if(pos1.x >= pos2.x){
            pos1 = new Vector3(pos1.x + 0.34f, pos1.y, pos1.z);
        } else {
            pos2 = new Vector3(pos2.x + 0.34f, pos2.y, pos2.z);
        }
        Instantiate(block1, pos1, transform.rotation);
        Instantiate(block2, pos2, transform.rotation);
    }

    void SpawnSuperBox() {
        Vector3 pos = new Vector3(Random.Range(xMin,xMax), 10, 10);
        GameObject box = SuperBox;
        Debug.Log("as");
        Instantiate(box, pos, transform.rotation);
    }


}
