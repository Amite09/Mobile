using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBox : MonoBehaviour
{
    public float speed = 0.02f;

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
            Helper.super = true;
            gameObject.SetActive(false);
            p.gameObject.SetActive(false);         
        }
    }

    void OnBecameInvisible(){
        if(this.transform.position.y < 0){
            gameObject.SetActive(false);
        }
    }
}
