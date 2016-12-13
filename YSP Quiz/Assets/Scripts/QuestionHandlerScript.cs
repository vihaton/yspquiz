using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//There should be only one QuestionHandlerScript in scene.
public class QuestionHandlerScript : MonoBehaviour {

    public TextAsset questionsAndAnswers;

    public Text questionText;
    public GameObject optionButtonPrefab;
    public GameObject optionsContainer;
    public int nextID = 0;
    public int howManyQuestions;
    public QuestionDataStruct[] questions;

    private bool lastQuestion = false;
    private GameControllerScript GCS;

	// Use this for initialization
	void Start () {
        GCS = GameObject.FindObjectOfType<GameControllerScript>();
        MakeQuestions();
        howManyQuestions = questions.Length;
        GCS.SetHowManyQuestions(howManyQuestions);
        UpdateQuestion();
	}

    public void UpdateQuestion()
    {
        Debug.Log("UpdateQuestion @ QuestionHandlerScript, time " + Time.time);
        QuestionDataStruct QDS = (QuestionDataStruct) questions[nextID];
        questionText.text = QDS.questionString;

        RemoveOldOptions();
        
        ArrayList listOfOptions = QDS.getOptions();
        for (int i = 0; i < listOfOptions.Count; i++)
        {
            OptionDataStruct ODS = (OptionDataStruct) listOfOptions[i];
            GameObject optButt = Instantiate(optionButtonPrefab) as GameObject;
            optButt.transform.SetParent(optionsContainer.transform);
            Text textObject = optButt.GetComponentInChildren<Text>();
            textObject.text = ODS.optionString;
            OptionButtonControllerScript OBCS = optButt.GetComponent<OptionButtonControllerScript>();
            OBCS.theRightAnswer = ODS.rightAnswer;
        }
    }

    private void RemoveOldOptions()
    {
        GameObject[] options = GameObject.FindGameObjectsWithTag("OptionButton");

        for (int i = 0; i < options.Length; i++)
        {
            GameObject optButton = options[i];
            Destroy(optButton);
        }
    }

    public void ChooseNextQuestion()
    {
        if (lastQuestion)
        {
            GCS.ToggleUIPanel();
            lastQuestion = false;
            return;
        }

        nextID++;

        if (nextID == howManyQuestions - 1)
        {
            lastQuestion = true;
        }

        UpdateQuestion();
    }

    public void MakeQuestions()
    {
        string data = questionsAndAnswers.text;
        string[] rawQuestions = data.Split("\n"[0]);
        int max = rawQuestions.Length;
        if (rawQuestions[max - 1].Length < 1) max--;
        questions = new QuestionDataStruct[max];

        for (int i = 0; i < max; i++)
        {
            QuestionDataStruct QDS = FormQuestion(rawQuestions[i], i);
            questions[i] = QDS;
        }

        Debug.Log("Questions are ready, questions.Length = " + questions.Length);
    }

    private QuestionDataStruct FormQuestion(string rawString, int id)
    {
        string[] line = rawString.Split(","[0]);
        Debug.Log("chopped line @ FormQuestion: length " + line.Length + " first string " + line[0]);
        QuestionDataStruct QDS = new QuestionDataStruct(id, line[0]);

        string lastPiece = line[0];
        for (int i = 1; i < line.Length; i++)
        {
            bool choppedCell = false;
            string piece = line[i];

            if (lastPiece.StartsWith("\""))
            {
                piece = lastPiece + "," + piece;
                choppedCell = true;
            }
            else if (piece.StartsWith("\""))
            {
                choppedCell = true;
            }

            //Debug.Log("piece: " + piece + "\nEndsWith(\"): " + piece.EndsWith("\"")); //tällä huomaa C# bugin: EndsWith palauttaa valheellisesti false, jos " on rivin lopussa
            if (piece.EndsWith("\"") || piece.IndexOf("\"") != piece.LastIndexOf("\""))
            { //solu on valmis
                int lastIndex = piece.Length - 2;
                if (!piece.EndsWith("\"")) lastIndex--; //sana loppui rivinvaihtoon

                piece = piece.Substring(1, lastIndex); //poistetaan " alusta ja lopusta
                AddOptionToQuestion(QDS, piece);
                piece = "";

            }
            else if (!choppedCell)
            {
                AddOptionToQuestion(QDS, piece);
            }

            lastPiece = piece;
        }

        Debug.Log("QHS: valmis QDS questionstring " + QDS.questionString + " length: " + QDS.questionString.Length);
        return QDS;
    }

    /*
     * If string starts with "$", it is the right answer
     */
    private void AddOptionToQuestion(QuestionDataStruct QDS, string optionString)
    {
        bool rightAnswer = false;
        if (optionString.StartsWith("$"))
        {
            rightAnswer = true;
            optionString = optionString.Substring(1, optionString.Length - 1);
        }

        QDS.addAnOption(new OptionDataStruct(optionString, rightAnswer));
    }
    
    public QuestionDataStruct[] getQuestionList()
    {
        return questions;
    }


}
