using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    [Range(1,15)]
    public int speed= 10;
    public DataAsset mydata;
    public Color carcolor;
    private Material material;
    private MeshRenderer meshRenderer;
    public bool isStarted = false;
    // Use this for initialization
    //public void Awake()
    //{
    //    //material = this.transform.GetComponent<Material>();
    //    meshRenderer = this.transform.GetComponent<MeshRenderer>();
    //    material = meshRenderer.material;
    //}
    //public void Reset()
    //{
        
    //    this.transform.GetComponent<MeshRenderer>().material.color = carcolor;
    //    Debug.Log("Reset메소드 콜!");
    //}
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStarted)
        {
            this.transform.Translate(Vector3.forward * speed*Time.deltaTime);
        }
	}
    public void RunStart()
    {
        isStarted = true;
    }
    IEnumerator RootUpdate()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
