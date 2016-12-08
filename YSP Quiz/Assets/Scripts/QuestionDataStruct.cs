using System.Collections;
using System;

[Serializable]
public class QuestionDataStruct {

    public int id;
    public string questionString;
    private ArrayList options;
    
    public QuestionDataStruct()
    {
        id = 666;
        questionString = "This is a question.";
        options = new ArrayList();
    }

    public QuestionDataStruct(int id, string theQuestion)
    {
        this.id = id;
        this.questionString = theQuestion;
        options = new ArrayList();
    }

    public void addAnOption(OptionDataStruct ods)
    {
        options.Add(ods);
    }

    public ArrayList getOptions()
    {
        return options;
    }
}
