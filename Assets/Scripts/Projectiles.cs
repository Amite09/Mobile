using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    private float speed = 10f;
    private bool canMove = true;
    private string color;
    public Vector3 target;
    private Rigidbody body;

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
        body = GetComponent<Rigidbody>();
        StartCoroutine(DisableProj(2f));
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            Move();
        }
    }

    void Move() {
        target.x *= 1.2f;
        target.y *= 1.2f;
        target.z = 5;
        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }

    IEnumerator DisableProj(float timer) {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

}
