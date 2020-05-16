using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{




    void Awake(){
        Helper.superFireRate = false;
        Helper.armorShotsLeft = 5;
        Helper.blockSpeed = 0.0075f;
        Helper.gameOver = false;
        Helper.score = 0;
        Time.timeScale = 1f;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
