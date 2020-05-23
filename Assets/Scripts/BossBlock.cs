using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBlock : MonoBehaviour
{

    public float speed;
    public int shotsLeft;

    public Material[] colors;
    public string color;

    // Start is called before the first frame update
    void Start()
    {
        speed = Helper.bossSpeed;
        shotsLeft = Helper.bossShotsLeft;
        int rand = Random.Range(0, colors.Length);
        GetComponent<MeshRenderer>().material = colors[rand];
        this.color = colors[rand].ToString().Substring(0, colors[rand].ToString().IndexOf(" "));
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
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.transform.root.TryGetComponent(out Projectiles p) && p.Color == this.color){
            shotsLeft--;
            if(shotsLeft == 0){
                Helper.score += 5;
                Helper.bossFight = false;
                Helper.bossShotsLeft *= 2;
                gameObject.SetActive(false);
            }
            if(Random.Range(0f,1f) > 0.9){
                changeColor();
            }
        }
    }

    void changeColor(){
        int rand = Random.Range(0, colors.Length);
        GetComponent<MeshRenderer>().material = colors[rand];
        this.color = colors[rand].ToString().Substring(0, colors[rand].ToString().IndexOf(" "));
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
