using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.layer == 8)
        {
            
            Car car = coll.gameObject.GetComponent<Car>();
            if (car.m_wall == null)
            {
                car.score -= 1;
                car.m_wall = this.gameObject;
            }
            else if(car.m_wall.name == this.gameObject.name)
            {
                
            }
            else
            {
                car.score -= 1;
                car.m_wall = this.gameObject;
            }
            car.GetComponent<Rigidbody>().AddForce(car.transform.forward * -1 * 10);
        }
    }
}
