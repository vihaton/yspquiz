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
    private AndroidJavaObject activity;
    private GameObject UIPanel;
    private PanelTextControllerScript PTCS;
    private bool editorBuild;

    // Use this for initialization
    void Start () {
        answers = 0;
        rightAnswers = 0;
        QHS = GameObject.FindObjectOfType<QuestionHandlerScript>();
        PBC = GameObject.FindObjectOfType<ProgressBarController>();
        QNTC = GameObject.FindObjectOfType<QuestionNoTextController>();
        UIPanel = GameObject.FindGameObjectWithTag("UIPanel");
        PTCS = gameObject.GetComponent<PanelTextControllerScript>();
        QNTC.questionsInTotal = howManyQuestions;
        QNTC.UpdateQNTxt(1);
        
        DefinePlatform();
        if (!editorBuild) activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");

        UIPanel.SetActive(true);
    }

    private void DefinePlatform()
    {
    #if UNITY_ANDROID
            editorBuild = false;
            Debug.Log("Android build");
    #endif

    #if UNITY_EDITOR
            editorBuild = true;
            Debug.Log("Editor build");
    #endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activity.Call<bool>("moveTaskToBack", true);
        }
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
        correctPercent = (float)rightAnswers * 100 / answers;
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        QNTC.UpdateQNTxt(answers+1);
        PBC.UpdateProgressFill(correctPercent);
        PBC.UpdateProgressText(correctPercent);
        QHS.ChooseNextQuestion();

    }

    public void ToggleUIPanel()
    {
        bool isActive = UIPanel.activeSelf;
        UIPanel.SetActive(!isActive);
        if (!isActive)
        {
            PTCS.LaitaUusintatxt();
        }
    }

    public void StartQuiz()
    {
        rightAnswers = 0;
        answers = 0;
        correctPercent = 0;
        QHS.nextID = -1;
        UpdateHUD();
    }
    
}
