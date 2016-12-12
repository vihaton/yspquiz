using UnityEngine;

public class OptionButtonControllerScript : MonoBehaviour {

    public bool theRightAnswer = false;
    private GameControllerScript GCS;

	// Use this for initialization
	void Start () {
        GCS = GameObject.FindObjectOfType<GameControllerScript>();
	}

    public void buttonIsPushed()
    {
        if (theRightAnswer)
        {
            GCS.RightAnswer();
        }
        GCS.Answered();
    }
}
