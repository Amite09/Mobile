using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject[] blocks;
    public GameObject SuperBox;
    public GameObject[] specialBlocks;

    public float waitingForNextSpawn;
    public float theCountdown;

    public float superBoxNextSpawn;
    public float superBoxCountdown;

    public float specialBlockNextSpawn;
    public float specialBlockCountdown;

    public Vector3 lastSpawnPosition;

 
    // the range of X
    [Header ("X Spawn Range")]
    public float xMin;
    public float xMax;
 
 
    public void Update(){

        if(!Helper.bossFight){
            superBoxCountdown -= Time.deltaTime;
            specialBlockCountdown -= Time.deltaTime;
            theCountdown -= Time.deltaTime;

            if(specialBlockCountdown <= 0 && theCountdown <= 0){
            SpawnSpecialBlock();
            specialBlockCountdown = specialBlockNextSpawn;
            } else if (theCountdown <= 0 && (specialBlockCountdown <= specialBlockNextSpawn * 0.9f && specialBlockCountdown >= specialBlockNextSpawn * 0.1f)){
                SpawnBlock();
                theCountdown = waitingForNextSpawn;
            }
            if(superBoxCountdown <= 0){
                SpawnSuperBox();
                superBoxCountdown = superBoxNextSpawn;
            }
        }
    }

    void SpawnBlock(){
        float posX = Random.Range(xMin,xMax);       
        if(Mathf.Abs(posX-lastSpawnPosition.x) < 0.4){
            posX = posX > lastSpawnPosition.x ? posX + 0.4f : posX - 0.4f;
        }
        Vector3 pos = new Vector3(posX, 10, 10);
        GameObject block = blocks[Random.Range(0, blocks.Length)];
        Instantiate(block, pos, transform.rotation);
        lastSpawnPosition = pos;
    }

    void SpawnSuperBox() {
        float posX = Random.Range(xMin,xMax);       
        if(Mathf.Abs(posX-lastSpawnPosition.x) < 0.4){
            posX = posX > lastSpawnPosition.x ? posX + 0.4f : posX - 0.4f;
        }
        Vector3 pos = new Vector3(posX, 10, 10);
        GameObject box = SuperBox;
        Instantiate(box, pos, transform.rotation);
        lastSpawnPosition = pos;
    }

    void SpawnSpecialBlock(){
        Vector3 pos = new Vector3(Random.Range(xMin,xMax), 10, 10);
        GameObject sb = specialBlocks[Random.Range(0, specialBlocks.Length)];
        Instantiate(sb, pos, transform.rotation);
    }


}
