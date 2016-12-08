using System;

[Serializable]
public class OptionDataStruct{

    public string optionString;
    public bool rightAnswer;

    public OptionDataStruct(string optionString, bool rightAnswer)
    {
        this.optionString = optionString;
        this.rightAnswer = rightAnswer;
    }
}
