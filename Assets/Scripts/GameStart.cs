using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public int scoreChecker;
    public GameObject boss;

    void Awake(){
        Helper.pointsToUpgrade = 25;
        Helper.pointsToBoss = 50;
        Helper.playerMaxShots = 1;
        Helper.superFireRate = false;
        Helper.armorShotsLeft = 5;
        Helper.colorBlockShotsLeft = 5;
        Helper.bossShotsLeft = 50;
        Helper.blockSpeed = 0.007f;
        Helper.bossSpeed = 0.0035f;
        Helper.bossFight = false;
        Helper.gameOver = false;
        Helper.score = 0;
        Time.timeScale = 1f;
        scoreChecker = 0;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkUpgrade();
        checkBoss();

    }

    void checkUpgrade(){
        if (Helper.score >= Helper.pointsToUpgrade){
            Helper.pointsToUpgrade += 25;
            Helper.playerMaxShots = Helper.playerMaxShots < 10 ? Helper.playerMaxShots + 1: Helper.playerMaxShots;
            Helper.armorShotsLeft += 5;
            Helper.colorBlockShotsLeft += 2;
            Helper.blockSpeed = Helper.blockSpeed == 0.001f ? Helper.blockSpeed : Helper.blockSpeed += 0.0005f; 
            if(GameObject.Find("BlockSpawner").TryGetComponent(out BlockSpawner b)){
                b.waitingForNextSpawn = b.waitingForNextSpawn > 0.5f ? b.waitingForNextSpawn -= 0.1f : 0.5f;
                b.superBoxNextSpawn  = b.superBoxNextSpawn > 5f ? b.superBoxNextSpawn -= 3 : 5f;
                b.specialBlockNextSpawn = b.specialBlockNextSpawn > 5f ? b.specialBlockNextSpawn -= 1 : 5f;
            }            
        }
    }

    void checkBoss(){
        scoreChecker = Helper.score;
        if (scoreChecker >= Helper.pointsToBoss){
            Helper.pointsToBoss *= 2; 
            scoreChecker = Helper.score - 150;
            Helper.bossFight = true;
            summonBoss();
        }
        
    }

    void summonBoss(){
        Vector3 pos = new Vector3(0, 10, 10);
        GameObject b = boss;
        Instantiate(b, pos, transform.rotation);
    }
}
