using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour {
    bool isplaySet = false;
    static bool HighFps = false;
    static bool ShowFps = false;
    static bool MoreInfo = false;
    public GameObject fps,MainGame,MainMenu,RootGame;
	// Use this for initialization
	void Start () {
        int a1=PlayerPrefs.GetInt("S1");
        int a2 = PlayerPrefs.GetInt("S2");
        int a3 = PlayerPrefs.GetInt("S3");
        if (a1 == 1)
        {
            Application.targetFrameRate = 60;
            HighFps = true;
            GameObject.Find("s11").transform.GetComponent<UISprite>().spriteName = "YES";
            GameObject.Find("s11").transform.GetComponent<UIButton>().normalSprite = "YES";
        }
        else
        {
            Application.targetFrameRate = 30;
            HighFps = false;
            GameObject.Find("s11").transform.GetComponent<UISprite>().spriteName = "NO";
            GameObject.Find("s11").transform.GetComponent<UIButton>().normalSprite = "NO";
        }

        if (a2 == 1)
        {
            fps.SetActive(true);
            ShowFps = true;
            GameObject.Find("s22").transform.GetComponent<UISprite>().spriteName = "YES";
            GameObject.Find("s22").transform.GetComponent<UIButton>().normalSprite = "YES";
        }
        else
        {
            fps.SetActive(false);
            ShowFps = false;
            GameObject.Find("s22").transform.GetComponent<UISprite>().spriteName = "NO";
            GameObject.Find("s22").transform.GetComponent<UIButton>().normalSprite = "NO";
        }

        if (a3 == 1)
        {
            Instation.Online = true;
            GameObject.Find("s33").transform.GetComponent<UISprite>().spriteName = "YES";
            GameObject.Find("s33").transform.GetComponent<UIButton>().normalSprite = "YES";
        }
        else
        {
            Instation.Online = false;
            GameObject.Find("s33").transform.GetComponent<UISprite>().spriteName = "NO";
            GameObject.Find("s33").transform.GetComponent<UIButton>().normalSprite = "NO";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        if (this.transform.name == "setting")
        {
            if (!isplaySet)
            {
                GameObject.Find("Camera").GetComponent<TweenPosition>().PlayForward();
                isplaySet = true;
            }
            else
            {
                GameObject.Find("Camera").GetComponent<TweenPosition>().PlayReverse();
                isplaySet = false;
                if (MoreInfo==true)
                {
                    MoreInfo = false;
                    GameObject.Find("MoreInfo").GetComponent<TweenPosition>().PlayReverse();
                }
            }
        }



        if (this.transform.name == "s11")
        {
            if (HighFps)
            {
                Application.targetFrameRate = 30;
                HighFps = false;
                this.transform.GetComponent<UISprite>().spriteName = "NO";
                this.transform.GetComponent<UIButton>().normalSprite = "NO";
                PlayerPrefs.SetInt("S1", 0);
            }
            else
            {
                Application.targetFrameRate = 60;
                HighFps = true;
                this.transform.GetComponent<UISprite>().spriteName = "YES";
                this.transform.GetComponent<UIButton>().normalSprite = "YES";
                PlayerPrefs.SetInt("S1", 1);
            }
        }


        if (this.transform.name == "s22")
        {
            if (ShowFps)
            {
                fps.SetActive(false);
                ShowFps = false;
                this.transform.GetComponent<UISprite>().spriteName = "NO";
                this.transform.GetComponent<UIButton>().normalSprite = "NO";
                PlayerPrefs.SetInt("S2", 0);
            }
            else
            {
                fps.SetActive(true);
                ShowFps = true;
                this.transform.GetComponent<UISprite>().spriteName = "YES";
                this.transform.GetComponent<UIButton>().normalSprite = "YES";
                PlayerPrefs.SetInt("S2", 1);
            }
        }

        if (this.transform.name == "touch")
        {

            MainGame.SetActive(true);
            RootGame.SetActive(true);
            MainMenu.SetActive(false);
        }
        if (this.transform.name == "Back")
        {
            SceneManager.LoadScene(0);
            CAR.isdead = false;
            CAR.Control = 0;
        }

        if (this.transform.name == "submit")
        {
            GameObject.Find("GameOver").GetComponent<Rank>().SendMessage("SendScore", GameObject.Find("Username").GetComponent<UILabel>().text);
        }

        if (this.transform.name == "s33")
        {
            if (Instation.Online)
            {
                Instation.Online = false;
                this.transform.GetComponent<UISprite>().spriteName = "NO";
                this.transform.GetComponent<UIButton>().normalSprite = "NO";
                PlayerPrefs.SetInt("S3", 0);
            }
            else
            {
                Instation.Online = true;
                this.transform.GetComponent<UISprite>().spriteName = "YES";
                this.transform.GetComponent<UIButton>().normalSprite = "YES";
                PlayerPrefs.SetInt("S3", 1);
            }

        }
        if (this.transform.name == "s4")
        {
            if (MoreInfo == false)
            {

                GameObject.Find("MoreInfo").GetComponent<TweenPosition>().PlayForward();
                MoreInfo = true;
            }
            else
            {
                GameObject.Find("MoreInfo").GetComponent<TweenPosition>().PlayReverse();
                MoreInfo = false;
            }
        }
    }
}
