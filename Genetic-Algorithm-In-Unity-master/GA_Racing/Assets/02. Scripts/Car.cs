using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public List<string> m_item;
    public GameObject m_wall;
    [Range(1, 15)]
    public int speed = 10;
    [Range(0.1f, 10f)]
    public float moveterm = 0.1f;
    public DataAsset mydata;
    public int score;
    public GeneticManager genetic = null;
    [SerializeField]
    private bool isStarted = false;
    // Use this for initialization
    public void Awake()
    {
        genetic = GameObject.Find("GeneManager").GetComponent<GeneticManager>();
    }
    void Start()
    {
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void RunStart()
    {
        isStarted = true;
        StartCoroutine(RootUpdate());
    }
    public void RunStop()
    {
        isStarted = false;
    }
    public void RunExit()
    {
        isStarted = false;
        genetic.AllFinished();
    }
    IEnumerator RootUpdate()
    {
        float origin = transform.rotation.y;
        float purpos = 0;
        float angle = 0;
        int i = 0;
        while (isStarted || i < (mydata.value.Length))
        {
            purpos = mydata.value[i];
            angle = Mathf.LerpAngle(origin, purpos, moveterm);
            transform.eulerAngles = new Vector3(0, angle, 0);
            yield return new WaitForSeconds(moveterm);
            origin = purpos;
            i++;
            if (i > 99)
            {
                break;
            }
        }
        RunExit();
    }

    public bool IsTherenameitem(string str)
    {
        if (m_item.Count == 0)
        {
            return false;
        }
        else
        {
            Debug.Log("capacity: " +m_item.Capacity);
        }
        for (int i = 0; i < m_item.Count; i++)
        {

            if (string.Equals(m_item[i], str))
            {
                Debug.Log("여기 있어요!");
                return true;
            }
        }
        Debug.Log("여긴없네요.");
        return false;
    }
    public void ItemPush(string str)
    {
        m_item.Add(str);
    }
    public void ItemClear()
    {
        m_item.Clear();
    }
}