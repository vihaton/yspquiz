using UnityEngine;
using System.Collections;
using System;

//There should be only one Instance of GameControllerScript in scene.
public class GameControllerScript : MonoBehaviour {

    public float correctPercent;
    public int rightAnswers;
    public int answers;
    public int howManyQuestions;
    private QuestionHandlerScript QHS;
    private ProgressBarController PBC;
    private QuestionNoTextController QNTC;

    // Use this for initialization
    void Start () {
        answers = 0;
        rightAnswers = 0;
        QHS = GameObject.FindObjectOfType<QuestionHandlerScript>();
        PBC = GameObject.FindObjectOfType<ProgressBarController>();
        QNTC = GameObject.FindObjectOfType<QuestionNoTextController>();
        QNTC.questionsInTotal = howManyQuestions;
    }

    // Update is called once per frame
    void Update () {

	}

    public void SetHowManyQuestions(int questions)
    {
        howManyQuestions = questions;
    }

    public void RightAnswer()
    {
        rightAnswers++;
    }

    public void Answered()
    {
        answers++;
        correctPercent = (float) rightAnswers * 100 / answers;
        QNTC.UpdateQNTxt(answers);
        PBC.UpdateProgressFill(correctPercent);
        PBC.UpdateProgressText(correctPercent);
        QHS.ChooseNextQuestion();
    }
    
}
