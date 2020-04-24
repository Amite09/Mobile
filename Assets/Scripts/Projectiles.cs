using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    private float speed = 10f;
    private bool canMove = true;
    private string color;
    public Vector3 target;

    public string Color {
        get {
            return color;
        }
        set {
            color = value;
        }
    }

    public Vector3 Target {
        get {
            return target;
        }
        set {
            target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableProj(5f));
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            Move();
        }
    }

    void Move() {
        Vector3 temp = transform.position;
        temp.x += target.x/20;
        temp.y += target.y/20;
        transform.position = temp;
    }

    IEnumerator DisableProj(float timer) {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive (false);
    }

}
