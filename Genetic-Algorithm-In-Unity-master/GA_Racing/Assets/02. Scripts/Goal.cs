using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    int time = 0; //남은 시간 어디다 구현해놨는지 몰라서 임의로 넣어줌

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void onTriggerEnter(Collision coll)
    {
        if(coll.gameObject.layer==11)
        {
            Car car = coll.gameObject.GetComponent<Car>();
            time *= 10;
            car.score += time;
        }
    }
}
