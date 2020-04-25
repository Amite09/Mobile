using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{

    public float speed = 0.005f;

    public string color;

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
            if (p.Color == this.color){
                gameObject.SetActive(false); 
            }
            p.gameObject.SetActive(false);         
        }
    }

}
