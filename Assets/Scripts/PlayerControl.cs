using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private SwipeInput input;

    private Time timeTouched;
    private Time timeLeft;

    public bool swipingRight = false;
    public bool swipingLeft = false;

    public GameObject[] projs;
    public Vector3 projSpawnPos;

    public string[] states;
    public int currentState;

    private int j = 0;

    // Start is called before the first frame update
    void Start()
    {
        input = transform.root.GetComponent<SwipeInput>();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfMoved();    
        Shoot();
    }


    void checkIfMoved(){
        if(!(swipingLeft || swipingRight)){
            if(input.swipedLeft){       
                swipingLeft = true;
                currentState = (currentState == 3 ? currentState - 3 : currentState + 1);

            } else if(input.swipedRight){
                swipingRight = true;
                currentState = (currentState == 0 ? currentState + 3 : currentState - 1);
            }
        }

        if(swipingLeft){
            if(j < 18){
                j++;
                transform.Rotate(0, 0, 5);
            } else {
                j = 0;
                swipingLeft = false;
            }
        } else if(swipingRight) {
            if(j < 18){
                j++;
                transform.Rotate(0, 0, -5);
            } else {
                j = 0;
                swipingRight = false;
            }
        }
    }


    void Shoot(){


        if(swipingLeft || swipingRight){
            return;
        }

        foreach (Touch touch in Input.touches){
            if (touch.fingerId == 0){
                if (Input.GetTouch(0).phase == TouchPhase.Began){
                    Vector3 _touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5);
                    if (_touchPosition.y < 190){
                        return;
                    }
                    GameObject proj = Instantiate(projs[currentState], projSpawnPos, Quaternion.identity);
                    Vector3 worldtouchPos = Camera.main.ScreenToWorldPoint(_touchPosition);
                    proj.GetComponent<Projectiles>().Target = worldtouchPos;
                    proj.GetComponent<Projectiles>().Color = states[currentState];
                }
            }
        }

        if(Input.GetMouseButtonDown(0)){
            Vector3 _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            if (_mousePosition.y < 190){
                return;
            }
            GameObject proj = Instantiate(projs[currentState], projSpawnPos, Quaternion.identity);
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(_mousePosition);
            proj.GetComponent<Projectiles>().Target = worldMousePos;
            proj.GetComponent<Projectiles>().Color = states[currentState];
        }
    }

}
