using UnityEngine;

public class OptionButtonControllerScript : MonoBehaviour {

    public bool theRightAnswer = false;
    private GameControllerScript GCS;
    private QuestionHandlerScript QHS;

	// Use this for initialization
	void Start () {
        GCS = GameObject.FindObjectOfType<GameControllerScript>();
        QHS = GameObject.FindObjectOfType<QuestionHandlerScript>();
	}

    public void buttonIsPushed()
    {
        if (theRightAnswer)
        {
            GCS.points++;
        }

        QHS.ChooseNextQuestion();
    }
}
