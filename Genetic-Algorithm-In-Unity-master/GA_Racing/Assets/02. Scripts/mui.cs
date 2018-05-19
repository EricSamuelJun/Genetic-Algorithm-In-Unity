using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mui : MonoBehaviour {
    public Text generationText;
    public Text[] texts = new Text[10];
    public Transform textmother;
    public Toggle toggle;
    public bool istogglevalue;
    private void Awake()
    {
        mmui.myui = this.gameObject.GetComponent<mui>();
    }
    // Use this for initialization
    void Start () {
		for(int i=0; i< 10; i++)
        {
            texts[i] = textmother.GetChild(i).GetComponent<Text>();
        }
	}
	public void GenTxt(string str)
    {
        generationText.text = str;
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void ToggleChange()
    {
        istogglevalue = toggle.isOn;
    }
}
static class mmui
{
    public static mui myui;
    public static void GenTxt(string str)
    {
        myui.GenTxt(str);
    }
    public static void RankingText(int idx,string text)
    {
        myui.texts[idx].text = text;
    }
}
