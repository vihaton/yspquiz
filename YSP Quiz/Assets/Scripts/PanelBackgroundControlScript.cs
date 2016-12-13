using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PanelBackgroundControlScript : MonoBehaviour {

    public float speed;
    public Image matrix1;
    public Image matrix2;
    public RectTransform maskTransform;

    // Use this for initialization
    void Start() {

        Canvas.ForceUpdateCanvases();
        ScaleToMask(matrix1);
        ScaleToMask(matrix2);
        
        matrix2.rectTransform.localPosition = new Vector3(matrix1.rectTransform.localPosition.x - matrix1.rectTransform.rect.width, 0, 0);
    }

    private void ScaleToMask(Image img)
    {
        float w = maskTransform.rect.width;
        float h = maskTransform.rect.height;
        img.rectTransform.sizeDelta = new Vector2(maskTransform.rect.width, maskTransform.rect.height);
        Debug.Log("PBCS: mask w " + w + " h " + h + " img w " + img.rectTransform.rect.width + " h " + img.rectTransform.rect.height);
    }
	
	// Update is called once per frame
	void Update () {
        AnimateBackground(matrix1, matrix2);
        AnimateBackground(matrix2, matrix1);
	}

    private void AnimateBackground(Image img1, Image img2)
    {
        RectTransform rt = img1.rectTransform;
        float x = rt.localPosition.x;
        if (x >= rt.rect.width) x = img2.rectTransform.localPosition.x - rt.rect.width; //moves img1 to the left side of img2

        rt.localPosition = new Vector3(x + speed * Time.deltaTime, 0, 0);
    }
}
