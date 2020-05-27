using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBox : MonoBehaviour
{
    public float speed = 0.02f;
    public int superIndex = 0;

    public GameObject[] projs;
    public string[] states;
    public int currentState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveBlock();
        
    }

    void moveBlock(){

        transform.Rotate(0, 1, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);

    }

    void OnTriggerEnter(Collider col){
        if(col.transform.root.TryGetComponent(out Projectiles p)){
            superIndex = Random.Range(1,5);  
        
            switch(superIndex){
                case 1: 
                    Helper.superFireRate = true;
                    gameObject.SetActive(false);
                    p.gameObject.SetActive(false);
                    break;
                case 2:
                    p.gameObject.SetActive(false);
                    Explode();
                    break;
                case 3:
                    p.bounce = true;
                    this.gameObject.SetActive(false);
                    break;
                case 4:
                    Helper.blockSpeedFactor = 0;
                    this.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    void Explode(){
        for (int i = 0; i < 100; i++){
            currentState = Random.Range(0,4);
            GameObject proj = Instantiate(projs[currentState], transform.position, Quaternion.identity);
            proj.GetComponent<Projectiles>().Target = new Vector3(Random.Range(-1f,1f) * 1000, Random.Range(-1f,1f) * 1000, 5f);
            proj.GetComponent<Projectiles>().Color = states[currentState];
        }
        this.gameObject.SetActive(false);       
    }

    void OnBecameInvisible(){
        if(this.transform.position.y < 0){
            gameObject.SetActive(false);
        }
    }


}
