using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        checkScore();
    }

    void checkScore(){
        if (!(Helper.score.ToString().Equals(score.text))){
            score.text = Helper.score.ToString();
        }
    }
}
