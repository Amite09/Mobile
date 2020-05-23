using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject[] projs;
    public Vector3 projSpawnPos;




    public string[] states;
    public int currentState;

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
            if (touch.fingerId == 0){
                Vector3 _touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5);
                Vector3 worldtouchPos = Camera.main.ScreenToWorldPoint(_touchPosition);
                if(angle == 0){
                    if(worldtouchPos.x >= 0 && worldtouchPos.y < 0.3){
                        currentState = (currentState == 0 ? currentState + 3 : currentState - 1);                   
                        StartCoroutine(rotatePlayer("Left"));
                    } else if(worldtouchPos.x < 0 && worldtouchPos.y < 0.3){
                        currentState = (currentState == 3 ? currentState - 3 : currentState + 1);
                        StartCoroutine(rotatePlayer("Right"));
                    } 
                }
                if(worldtouchPos.y > 0.3) {
                    if(!Helper.superFireRate && touch.phase == TouchPhase.Began){
                        StartCoroutine(shoot(worldtouchPos));
                    } else if (Helper.superFireRate) {
                        GameObject proj = Instantiate(projs[currentState], projSpawnPos, Quaternion.identity);
                        worldtouchPos.x *= 100;
                        worldtouchPos.y *= 100;
                        proj.GetComponent<Projectiles>().Target = worldtouchPos;
                        proj.GetComponent<Projectiles>().Color = states[currentState];
                    }
                }
            }
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
