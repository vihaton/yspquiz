using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogoGlowScript : MonoBehaviour {

    public float speed;
    public float divider;
    public Image background;
    private Color color;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        color = background.color;
        color.a = (1 + speed * Mathf.Sin(Time.time)) / divider;
        background.color = color;
	}
}
