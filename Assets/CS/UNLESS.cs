using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UNLESS : MonoBehaviour {
    public GameObject C1, C2,C3,C4,C5,C6,C7,C8,C9,C10;
    public GameObject L1,L2,L3,L4,T1,T2,T3,T4,T5,T6;
    public GameObject SWAT;
    public GameObject MB, MR;
    float a = 0, _Timeb = 0;
    public int HardLevel=1;
    private int CarCount=2;
    private int MaxCount = 12;
    private float SpawnTime =2f;
    private float SpawnTime2 = 2f;
    private int SameSide =0;
    private bool IsSpawn = false;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        if (_Timeb < 10f)
        {
            _Timeb += 1f * Time.deltaTime;
        }
        else
        {
            SpawnTime2 -= 0.1f;
            _Timeb = 0;
            HardLevel += 1;
        }


        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0)
        {
            if (IsSpawn == false)
            {
                CreateCar();
            }
            Debug.Log("车辆被生成了");
            SpawnTime = SpawnTime2;
            IsSpawn = false;
        }

        



	}

    public void ChangeCarCount(int a)
    {
        CarCount += a;
    }


    public void CreateCar()
    {
        int flag = 0;
        
        GameObject[] NormalCar = new GameObject[] { C1, C2, C3, C4, C5, C6, C7, C8, C9, C10 };
        GameObject[] MediumCar = new GameObject[] { L1, L2, L3, L4, T1, T2, T3, T4, T5, T6 };
        GameObject[] HardCar = new GameObject[] { SWAT };
        GameObject[] More= new GameObject[] { MB,MR };
        if (CarCount < MaxCount)
        {
            
            ChangeCarCount(1);
            int Rotation = (int)Random.Range(1.0f, 4.9f);
            int RandomCar=(int)Random.Range(0f,9.9f);

            if (MaxCount < 30)
            {
                MaxCount = 12 + HardLevel;
            }

            float Nomal = 0.8f - (0.02f * HardLevel);

            float Per = Random.Range(0f, 1f);
                   //     Debug.Log(Nomal+"   "+Per+" "+SpawnTime+" "+MaxCount);
            if (Per > Nomal)
            {
                flag = 2;
            }
            else
            {
                flag = 1;
            }

            //警车奖励道具刷新
            float _hard =Random.Range(0f,1.05f);
            if (SpawnTrain.TrainTime == true)
            {
                _hard = 0.5f;
            }
            Debug.Log(_hard);
            if (_hard > 1.0f)
                flag = 3;
            else if (_hard < 0.05f)
                flag = 4;
            GameObject a;




            if (flag== 1)
            {
                a = GameObject.Instantiate(NormalCar[RandomCar]);
                
            }
            else if (flag == 2)
            {
                a = GameObject.Instantiate(MediumCar[RandomCar]);

            }
            else if (flag == 3)
            {
                a = GameObject.Instantiate(HardCar[0]);
            }
            else
            {
                a = GameObject.Instantiate(More[0]);
            }
            //Debug.Log(SameSide + " " + Rotation);
            if (SameSide == Rotation)
            {
                if (SameSide <= 2)
                    Rotation += 2;
                if (SameSide >= 3)
                    Rotation -= 2;
            }

            if(Rotation==1)
            {
             int b=(int)Random.Range(1.0f,2.9f);
             if (b == 1)
             {
                 a.transform.tag = "1";
                 a.transform.SetParent(GameObject.Find("MainGame").transform);
                 a.transform.localPosition = new Vector3(-54, 0, -10);
                 a.transform.localEulerAngles = new Vector3(0, -90, 0);
             }
             else
             {
                 a.transform.tag = "1";
                 a.transform.SetParent(GameObject.Find("MainGame").transform);
                 a.transform.localPosition = new Vector3(-54, 0, -3);
                 a.transform.localEulerAngles = new Vector3(0, -90, 0);
             }
            }
            else if (Rotation == 2)
            {
                int b = (int)Random.Range(1.0f, 2.9f);
                if (b == 1)
                {
                    a.transform.tag = "2";
                    a.transform.SetParent(GameObject.Find("MainGame").transform);
                    a.transform.localPosition = new Vector3(60, 0, 4);
                    a.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else
                {
                    a.transform.tag = "2";
                    a.transform.SetParent(GameObject.Find("MainGame").transform);
                    a.transform.localPosition = new Vector3(60, 0, 11);
                    a.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
            }
            else if (Rotation == 3)
            {
                int b = (int)Random.Range(1.0f, 2.9f);
                if (b == 1)
                {
                    a.transform.tag = "2";
                    a.transform.SetParent(GameObject.Find("MainGame").transform);
                    a.transform.localPosition = new Vector3(10, 0, -52);
                    a.transform.localEulerAngles = new Vector3(0,180, 0);
                }
                else
                {
                    a.transform.tag = "2";
                    a.transform.SetParent(GameObject.Find("MainGame").transform);
                    a.transform.localPosition = new Vector3(3, 0, -52);
                    a.transform.localEulerAngles = new Vector3(0,180, 0);
                }
            }
            else if (Rotation ==4)
            {
                int b = (int)Random.Range(1.0f, 2.9f);
                if (b == 1)
                {
                    a.transform.tag = "1";
                    a.transform.SetParent(GameObject.Find("MainGame").transform);
                    a.transform.localPosition = new Vector3(-11, 0, 66);

                }
                else
                {
                    a.transform.tag = "1";
                    a.transform.SetParent(GameObject.Find("MainGame").transform);
                    a.transform.localPosition = new Vector3(-4, 0, 66);

                }
            }
            SameSide = Rotation;
            IsSpawn = true;
        }
    }




}
