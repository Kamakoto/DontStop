using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instation : MonoBehaviour {
    public GameObject Fps;
    public  GameObject Score;
    public static bool Online = false;
    public GameObject Control,go;
    public  static GameObject GameOver;
    public static int NowScore = 0;
    private float m_DeltaTime;
	// Use this for initialization
	void Awake() {
        NowScore = 0;
       
        GameOver = go;
	}
	
	// Update is called once per frame
	void Update () {
        m_DeltaTime += (Time.unscaledDeltaTime - m_DeltaTime) * 0.1f;
        float fps = 1f / m_DeltaTime;
        Fps.GetComponent<UILabel>().text = "FPS:" + (int)fps;
        Control.GetComponent<TextMesh>().text = "STOP:" + CAR.Control.ToString() + "/5";
        Score.GetComponent<TextMesh>().text = "SCORE:" + NowScore;
	}


    public void AddScore(int score)
    {
        NowScore += score;
    }
}
