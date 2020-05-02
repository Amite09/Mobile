using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject[] projs;
    public Vector3 projSpawnPos;

    public string[] states;
    public int currentState;

    private int j = 0;


    // Update is called once per frame
    void Update()
    {
        checkTouches();
    }

    void checkTouches(){
        foreach (Touch touch in Input.touches){
            if (touch.fingerId == 0){
                Vector3 _touchPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5);
                Vector3 worldtouchPos = Camera.main.ScreenToWorldPoint(_touchPosition);

                if(worldtouchPos.x >= 0 && worldtouchPos.y < 0.5 && j == 0){
                    currentState = (currentState == 0 ? currentState + 3 : currentState - 1);                   
                    StartCoroutine(rotatePlayer("Left"));
                } else if(worldtouchPos.x < 0 && worldtouchPos.y < 0.5 && j == 0){
                    currentState = (currentState == 3 ? currentState - 3 : currentState + 1);
                    StartCoroutine(rotatePlayer("Right"));
                } else if(worldtouchPos.y > 0.5 && touch.phase == TouchPhase.Began) {
                    GameObject proj = Instantiate(projs[currentState], projSpawnPos, Quaternion.identity);
                    worldtouchPos.x *= 10;
                    worldtouchPos.y *= 10;
                    proj.GetComponent<Projectiles>().Target = worldtouchPos;
                    proj.GetComponent<Projectiles>().Color = states[currentState];
                }
            }
        }
    }

    IEnumerator rotatePlayer(string direction){
        if (direction == "Right"){
            while (j < 18){
                transform.Rotate(0, 0, 5);
                j++;
                yield return new WaitForEndOfFrame();
            }
        } else if (direction == "Left"){
            while (j < 18){
                transform.Rotate(0, 0, -5);
                j++;
                yield return new WaitForEndOfFrame();
            }
        }
        j = 0;
    }


}
