using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    private string color;
    private Vector3 target;
    private Rigidbody body;

    public bool bounce = false;

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
        StartCoroutine(DisableProj(5f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RemoveProj();
    }

    void Move() {
        target.z = 10;
        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }

    void OnTriggerEnter(Collider col){        
        if(bounce && GameObject.Find(color + " Block(Clone)").TryGetComponent(out Blocks cb)){
            target = cb.transform.position;
        } else if(!col.transform.root.TryGetComponent(out Projectiles p)){
            gameObject.SetActive(false);
        }     
    }

    void RemoveProj(){
        if (bounce && GameObject.Find(color + " Block(Clone)") == null){
            gameObject.SetActive(false);
        }
    }

    IEnumerator DisableProj(float timer) {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    void OnBecameInvisible(){
        target.x *= -1;        
    }

}
