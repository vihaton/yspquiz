using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {

    public Image fill;
    public Text progressText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateProgressFill(float percent)
    {
        fill.fillAmount = percent / 100;
    }

    public void UpdateProgressText(float percent)
    {
        percent = Mathf.Round(percent);
        progressText.text = "" + percent + "% oikein";
    }
}
