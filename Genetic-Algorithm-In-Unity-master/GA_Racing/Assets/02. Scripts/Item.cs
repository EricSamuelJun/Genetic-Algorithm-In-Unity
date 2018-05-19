using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    bool flageItem = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.layer==8)
        {
            Car car = coll.gameObject.GetComponent<Car>();
            
            if(!car.IsTherenameitem(this.gameObject.name))
            {
                car.score += 10;
                car.ItemPush(this.gameObject.name);
            }
            else
            {
            }
        }
    }
}
