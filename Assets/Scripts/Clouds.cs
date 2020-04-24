using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -5){
            this.transform.position = new Vector3(transform.position.x, 50, transform.position.z);
        } else {
            this.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        }
    }
}
