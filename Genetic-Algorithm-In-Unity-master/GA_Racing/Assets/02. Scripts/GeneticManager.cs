using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GeneticManager : MonoBehaviour {
    public DataAsset[] dataAsset;
    public Car[] cars = new Car[10];
    private Transform Carmanager;
    [Range(0,9)]
    public int caridx = 0;
    public bool isReady = true;
    public int[] score;
    public int generation;
    public bool giverandomstart = true;
    public int[,] ranking=new int[10,2];
    public Transform carPos = null;
    DataAsset father;
    DataAsset mother;
    int finishcount = 0;
    // Use this for initialization

    private void Awake()
    {
        Carmanager = GameObject.Find("CarManager").transform;
        for (int i = 0; i < 10; i++)
        {
            if(Carmanager.GetChild(i)!=null)
                cars[i] = Carmanager.GetChild(i).GetComponent<Car>();
            
        }
    }
    void Start()
    {
        for(int i=0; i<10; i++)
        {
            cars[i].mydata = dataAsset[i];
        }
        if (giverandomstart)
        {
            for(int i=0; i < 10; i++)
            {
                GiveRandom(i);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void GiveRandom(int idx)
    {
        for(int i=0; i <dataAsset[idx].value.Length; i++)
        {
            dataAsset[idx].value[i] = Random.Range(0f, 360f);
        }
    }
    public void AllRun()
    {
        mmui.GenTxt("Gen: " + generation);
        finishcount = 0;
        for(int i=0; i < 10; i++)
        {
            cars[i].RunStart();
        }
    }
    public void AllFinished()
    {
        finishcount++;
        if (finishcount != 10)
            return;
        for(int i =0; i < cars.Length; i++)
        {
            cars[i].RunStop();
            ranking[i, 0] = i;
            ranking[i, 1] = cars[i].score;
            cars[i].transform.position = carPos.position;
            cars[i].transform.rotation = carPos.rotation;
        }
        SortRancing();
        father = dataAsset[ranking[0, 0]];
        mother = dataAsset[ranking[1, 0]];
        for(int i=0; i < 10; i++)
        {
            cars[i].score = 0;
            cars[i].ItemClear();
        }
        CrossOver();
        Mutate();
        generation++;
        mmui.GenTxt("Gen: " + generation);
        if (mmui.myui.istogglevalue == true)
        {
            AllRun();
        }
    }
    void SortRancing()
    {
        int[] temper = new int[2];
        for (int i = 0; i < 10; i++)
        {
            for(int j = i+1; j <10; j++)
            {
                if (ranking[i, 1] <= ranking[j, 1])
                {
                    temper[0] = ranking[i, 0];
                    temper[1] = ranking[i, 1];
                    ranking[i, 0] = ranking[j, 0];
                    ranking[i, 1] = ranking[j, 1];
                    ranking[j, 0] = temper[0];
                    ranking[j, 1] = temper[1];
                }
            }
        }
        for (int i =0; i < 10; i++)
        {
            mmui.RankingText(i, "Car_" + (ranking[i, 0]) + " Score: " + ranking[i, 1]);
        }
    }
    private void CrossOver()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (i == ranking[0, 0] || i == ranking[1, 0])
            {

            }
            else
            {
                CrossOver(i);
            }
        }        
    }
    private void CrossOver(int son)
    {
        bool fama = (Random.value < 0.5f);
        int randp1 = Random.Range(0, 50);
        int randp2 = Random.Range(randp1 + 1, 75);
        int randp3 = Random.Range(randp2, 99);
        for(int i=0; i < randp1; i++)
        {
            if (fama)
            {
                dataAsset[son].value[i] = father.value[i];
            }
            else
            {
                dataAsset[son].value[i] = mother.value[i];
            }
        }
        for(int i = randp1; i < randp2; i++)
        {
            if (fama)
            {
                dataAsset[son].value[i] = mother.value[i];
            }
            else
            {
                dataAsset[son].value[i] = father.value[i];
            }
        }
        for(int i=randp2; i < randp3; i++)
        {
            if (fama)
            {
                dataAsset[son].value[i] = father.value[i];
            }
            else
            {
                dataAsset[son].value[i] = mother.value[i];
            }
        }
        for(int i = randp3; i < dataAsset[son].value.Length; i++)
        {
            if (fama)
            {
                dataAsset[son].value[i] = mother.value[i];
            }
            else
            {
                dataAsset[son].value[i] = father.value[i];
            }
        }
    }
    private void Mutate()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            Mutate(i);
        }
    }
    private void Mutate(int idx)
    {
        int[] randpos = new int[10];
        for(int i=0; i<10; i++)
        {
            if (i != 0)
            {
                randpos[i] = Random.Range(randpos[i - 1], (i + 1) * 10);
            }
            else
            {
                randpos[0] = Random.Range(0, (i + 1) * 10);
            }
        }
        for(int i =0; i < 10; i++)
        {
            dataAsset[idx].value[randpos[i]] = Random.Range(0f, 360f);
        }
    }
    private void GoRun()
    {
        AllRun();
    }
}