using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelTextControllerScript : MonoBehaviour {

    public Text txt;
    public RectTransform ContentsTransform;
    public Scrollbar verticalScrollbar;
    public TextAsset aloitusteksti;
    public TextAsset uusintateksti;

	// Use this for initialization
	void Start () {
        LaitaAloitustxt();
	}

    public void SetScrollbarToBeginning()
    {
        verticalScrollbar.value = 1;
    }

	public void LaitaUusintatxt()
    {
        txt.text = uusintateksti.text;
        SetScrollbarToBeginning();
        ScaleContent();
    }

    public void LaitaAloitustxt()
    {
        txt.text = aloitusteksti.text;
        SetScrollbarToBeginning();
        ScaleContent();
    }

    public void ScaleContent()
    {
        float h = txt.rectTransform.rect.height;
        Debug.Log("PTCS: txt height " + h);
        ContentsTransform.sizeDelta = new Vector2(0, h);
    }
}
