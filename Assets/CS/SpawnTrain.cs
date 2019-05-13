using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrain : MonoBehaviour {
    float Now, SpawnTime;
    public static bool TrainTime = false;
    public GameObject Train;
    public GameObject light1, light2;
	// Use this for initialization
	void Start () {
        Now = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (SpawnTime == 0)
        {
            SpawnTime = Random.Range(20f, 30f);
        }

        if (Now < SpawnTime)
        {
            Now += 1f * Time.deltaTime;
        }
        else
        {
            SpawnTime = 0;
            TrainTime = true;
            this.transform.GetComponent<AudioSource>().Play();
            GameObject a= GameObject.Instantiate(Train);
            a.transform.SetParent(GameObject.Find("MainGame").transform);

            a.transform.localPosition = new Vector3(19f, 2.3f, -73f);
            Debug.Log(a.transform.localPosition);
            light1.SetActive(true);
            light2.SetActive(true);
            Now = 0;
        }


        if (TrainTime == false)
        {
            light1.SetActive(false);
            light2.SetActive(false);
            this.transform.GetComponent<AudioSource>().Stop();
        }
	}
}
