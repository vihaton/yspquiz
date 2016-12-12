using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionNoTextController : MonoBehaviour {

    public int questionsInTotal;
    public Text questionNoText;

	void Start () {
	
	}
	

    public void UpdateQNTxt(int answered)
    {
        questionNoText.text = "Kysymys " + answered + "/" + questionsInTotal;
    }
}
