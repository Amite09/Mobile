using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject[] projs;
    public Vector3 projSpawnPos;

    public string[] states;
    public int currentState;
    public float currentAngle;

    public bool superFireRate;

    private int angle = 0;


    // Update is called once per frame
    void Update()
    {
        if(Helper.superFireRate && !superFireRate){
            superFireRate = true;
            StartCoroutine(disableSuper());
        }
        if(!Helper.gameOver){
            checkTouches();
        }
    }


     

    void checkTouches(){
        foreach (Touch touch in Input.touches){
            if (touch.fingerId == 0 || touch.fingerId == 1){
                int fid = touch.fingerId;
                Vector3 _touchPosition = new Vector3(Input.GetTouch(fid).position.x, Input.GetTouch(fid).position.y, 5);
                Vector3 worldtouchPos = Camera.main.ScreenToWorldPoint(_touchPosition);
                if(worldtouchPos.y < 0.3){
                    // float rotateSpeed = 0.3f;
                    // Touch touchZero = Input.GetTouch(fid);
                    // Vector3 localAngle = this.transform.localEulerAngles;
                    // localAngle.z -= rotateSpeed * touchZero.deltaPosition.x;
                    // this.transform.localEulerAngles = localAngle;
                    // checkState();
                    if(worldtouchPos.x >= 0 && angle == 0){
                        currentState = (currentState == 0 ? currentState + 3 : currentState - 1);                   
                        StartCoroutine(rotatePlayer("Left"));
                    } else if(worldtouchPos.x < 0 && angle == 0){
                        currentState = (currentState == 3 ? currentState - 3 : currentState + 1);
                        StartCoroutine(rotatePlayer("Right"));
                    } 
                }
                else if(worldtouchPos.y > 0.3) {
                    if(!Helper.superFireRate && touch.phase == TouchPhase.Began){
                        StartCoroutine(shoot(worldtouchPos));
                    } else if (Helper.superFireRate) {
                        GameObject proj = Instantiate(projs[currentState], projSpawnPos, Quaternion.identity);
                        worldtouchPos.x *= 10000;
                        worldtouchPos.y *= 10000;
                        proj.GetComponent<Projectiles>().Target = worldtouchPos;
                        proj.GetComponent<Projectiles>().Color = states[currentState];
                    }
                }
            }
        }

        // if(Input.GetMouseButtonDown(0)){
        //     GameObject proj = Instantiate(projs[currentState], transform.position, Quaternion.identity);
        //     Vector3 _mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        //     Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(_mousePosition);
        //     worldMousePos.x *= 10000;
        //     worldMousePos.y *= 10000;
        //     proj.GetComponent<Projectiles>().Target = worldMousePos;
        //     proj.GetComponent<Projectiles>().Color = states[currentState];
        // }


    }

    void checkState(){
        Vector3 localAngle = this.transform.localEulerAngles;
        if(localAngle.z > currentAngle + 45){
            currentAngle += 90;
            currentState = (currentState == 3 ? currentState - 3 : currentState + 1);
        } else if (localAngle.z < currentAngle - 45){
            currentAngle -= 90;
            currentState = (currentState == 0 ? currentState + 3 : currentState - 1);
        }
    }

    IEnumerator shoot(Vector3 t){
        for(int i = 0; i < Helper.playerMaxShots; i++){
            GameObject proj = Instantiate(projs[currentState], projSpawnPos, Quaternion.identity);
            if(i != 0){
                t.x = Random.Range(0.7f * t.x, 1.3f * t.x);
                t.y = Random.Range(0.7f * t.y, 1.3f * t.y);
            }
            t.x *= 100;
            t.y *= 100;
            proj.GetComponent<Projectiles>().Target = t;
            proj.GetComponent<Projectiles>().Color = states[currentState];
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator disableSuper(){
        yield return new WaitForSeconds(5f);
        Helper.superFireRate = false;
        superFireRate = false;
    }

    IEnumerator rotatePlayer(string direction){
        if (direction == "Right"){
            while (angle < 18){
                transform.Rotate(0, 0, 5);
                angle++;
                yield return new WaitForEndOfFrame();
            }
        } else if (direction == "Left"){
            while (angle < 18){
                transform.Rotate(0, 0, -5);
                angle++;
                yield return new WaitForEndOfFrame();
            }
        }
        angle = 0;
    }



    


}
