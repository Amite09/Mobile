using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBlock : MonoBehaviour
{

    public float speed;
    public int shotsLeft;

    // Start is called before the first frame update
    void Start()
    {
        speed = Helper.blockSpeed;
        shotsLeft = Helper.armorShotsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        moveBlock();
        checkHeight();
        
    }

    void moveBlock(){

        transform.Rotate(0, 1, 0);
        if(!Helper.gameOver){
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Helper.blockSpeedFactor, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.transform.root.TryGetComponent(out Projectiles p)){
            shotsLeft--;
            if(shotsLeft == 0){
                Helper.score += 5;
                gameObject.SetActive(false);
            }
        }
    }
    
    void checkHeight(){
        if (this.transform.position.y < 1.2){            
            Helper.gameOver = true;
            this.gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible(){
        if(this.transform.position.y < 0){
            gameObject.SetActive(false);
        }
    }

}
