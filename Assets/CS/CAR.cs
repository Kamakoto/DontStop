
using System.Collections.Generic;
using UnityEngine;

public class CAR : MonoBehaviour {
    public   AudioClip Stop, Continnue;

    public static int Control = 0;
    public bool WasControl = false;
    public int SpeedUp = 0;
    public int isPlay = 1;
    public static bool isdead = false;
    
    Color a;
    public float SpeedMax;
    public float speed;
	// Use this for initialization
	void Start () {
        a = this.transform.GetComponent<Renderer>().material.color;
        this.gameObject.GetComponent<AudioSource>().spatialBlend = 0;
        if (this.transform.GetComponent<Rigidbody>().mass == 100)
        {
            SpeedMax = 18f;
            speed = 15;
        }
        else if (this.transform.GetComponent<Rigidbody>().mass == 300)
        {
            SpeedMax = 17f;
            speed = 14;
        }
        else if (this.transform.GetComponent<Rigidbody>().mass == 550)
        {
            SpeedMax = 20f;
            speed =16;
        }
        else if (this.transform.GetComponent<Rigidbody>().mass == 1)
        {
            SpeedMax = 20f;
            speed = 20;
        }
        else
        {
            SpeedMax = 15f;
            speed = 13;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localPosition.y > 5)
        {
            Destroy(this.gameObject);
            GameObject.Find("MainGame").GetComponent<UNLESS>().SendMessage("ChangeCarCount", -1);
            if (WasControl)
            {
                Control -= 1;
            }
        }

        this.transform.Translate(0, -0.1f, 0);
        this.transform.Translate(0, 0.1f, 0);
        if (isPlay==1||isPlay==2)
        {
            if (this.transform.tag == "1")
            {

                if (speed < SpeedMax)
                {
                    speed += 0.1f;
                }
                Vector3 a = new Vector3(0, 0, -1f);
                a = a * speed * Time.deltaTime;
                this.transform.Translate(a);
            }
            if (this.transform.tag == "2")
            {
                if (speed < SpeedMax)
                {
                    speed += 0.1f;
                }
                Vector3 a = new Vector3(0, 0, -1f);
                a = a * speed * Time.deltaTime;
                this.transform.Translate(a);
            }
        }




        if (Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            Vector2  b = Input.GetTouch(0).deltaPosition;
            float bx = System.Math.Abs(b.x);
            float by = System.Math.Abs(b.y);
            Ray Q=Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(Q,out Hit))
            {
                if (Hit.transform.GetComponent<Rigidbody>().mass != 550 && Hit.transform.GetComponent<CAR>().SpeedUp == 0 && (bx + by) >= 35 && Hit.transform.GetComponent<Rigidbody>().mass !=1)
                {
                    UnLockCon();
                    //GameObject.Find("Debug").GetComponent<UILabel>().text = b.ToString();
                    if (SPEEDUP._SpeedUpCount > 0)
                    {
                        Hit.transform.GetComponent<CAR>().SpeedUp = 1;
                        Hit.transform.GetComponent<CAR>().SpeedMax += 30;
                        Hit.transform.GetComponent<CAR>().speed += 25;
                        Hit.transform.GetComponent<CAR>().isPlay = 2;
                        SPEEDUP._SpeedUpCount -= 1;
                    }

                }
            }
        }


          
            


	}
    /// <summary>
    /// 车辆暂停判定
    /// </summary>
    void OnMouseUp()
    {
        if (this.transform.GetComponent<Rigidbody>().mass != 550 && this.transform.GetComponent<Rigidbody>().mass != 1)
        {
            if (isPlay==1)   //暂停判定    此处是 未被暂停后的进行的操作
            {
                if (Control < 5)   //再次判定   检查是否超过控制上线  
                {
                    WasControl = true;
                    Control += 1;
                    isPlay = 0;
                    this.transform.GetComponent<Renderer>().material.color = new Color(60 / 255f, 60 / 255f, 60 / 255f);
                    speed = 6f;
                    this.GetComponent<AudioSource>().clip = Stop;
                    this.GetComponent<AudioSource>().Play();
                }
                else   //如果超过上线 则进行下列操作
                {

                }
            }
            else
            {

                UnLockCon();
            }
        }
    }
            

  
    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>
    /// <param name="Car"></param>

    void OnCollisionEnter(Collision Car)
    {
        if (!isdead)
        {
            if (isPlay == 1 && Car.transform.tag == "1" || Car.transform.tag == "2" || Car.transform.tag == "3" || Car.transform.tag == "4")
            {
                if (this.gameObject.name == "MB(Clone)")
                {

                    GameObject.Find("Main Camera").GetComponent<Instation>().SendMessage("AddScore", 250);
                    GameObject.Find("MainGame").GetComponent<UNLESS>().SendMessage("ChangeCarCount", -1);
                    GameObject.Find("MainGame").GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject);
                }
                else if (Car.gameObject.name == "MB(Clone)")
                {

                    GameObject.Find("Main Camera").GetComponent<Instation>().SendMessage("AddScore", 250);
                    GameObject.Find("MainGame").GetComponent<UNLESS>().SendMessage("ChangeCarCount", -1);
                    GameObject.Find("MainGame").GetComponent<AudioSource>().Play();
                    Destroy(Car.gameObject);
                }
                else
                {
                    Game_Over();
                }
            }
            else if (Car.transform.tag == "SL")
            {
                DestroyCar();
            }
        }
    }

    void DestroyCar()
    {
        if (Instation.GameOver.active == false)
        {
            Destroy(this.gameObject);
            GameObject.Find("Main Camera").GetComponent<Instation>().SendMessage("AddScore", 100);
            GameObject.Find("MainGame").GetComponent<UNLESS>().SendMessage("ChangeCarCount", -1);
            if (WasControl)
            {
                Control -= 1;
            }
        }
    }



    void UnLockCon()
    {
        if (isPlay == 0)
        {
            WasControl = false;
            Control -= 1;
            isPlay = 1;
            this.GetComponent<AudioSource>().clip = Continnue;
            this.GetComponent<AudioSource>().Play();

            this.GetComponent<Renderer>().material.color = a;
        }
    }


    public void Game_Over()
    {
        if (PlayerPrefs.GetInt("score") < Instation.NowScore)
        {
            PlayerPrefs.SetInt("score", Instation.NowScore);
        }
        Instation.GameOver.SetActive(true);
        GameObject.Find("RootGame").SetActive(false);
        GameObject.Find("ModeS").GetComponent<UILabel>().text = Instation.NowScore.ToString();
        GameObject.Find("RankLocal").GetComponent<UILabel>().text = "最高记录:" + PlayerPrefs.GetInt("score").ToString();
        isdead = true;
        SpawnTrain.TrainTime = false;
    }

}
