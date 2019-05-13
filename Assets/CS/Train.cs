using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {
    float TrainSpeed = 50;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 a = new Vector3(0, -0.3f, 0);
        a = a * TrainSpeed * Time.deltaTime;
        this.transform.Translate(a);


	}

    void OnCollisionEnter(Collision Car)
    {
        if (Car.gameObject.name == "TrainOver")
        {
           SpawnTrain.TrainTime= false;
            Destroy(this.gameObject);
        }
    }
}
