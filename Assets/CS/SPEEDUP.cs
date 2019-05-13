using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPEEDUP : MonoBehaviour {
    public GameObject _SpeedUpLabel;
    public static int _SpeedUpCount;
    public float a = 0;
	// Use this for initialization
	void Start () {
        _SpeedUpCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ReFreshLabel();

        if (a < 5f)
        {
            a += (1f * Time.deltaTime);

        }
        else
        {
            a = 0;
            if (_SpeedUpCount < 10)
            {
                _SpeedUpCount += 1;
            }
        }



	}

    public void ReFreshLabel()
    {
        _SpeedUpLabel.GetComponent<UILabel>().text = "SPEEDUP:" +(int)((a /5)*100)+ "%(" + _SpeedUpCount + ")";
    }
}
