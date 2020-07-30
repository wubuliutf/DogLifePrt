using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int hunger;
    [SerializeField]
    private int happiness;
    [SerializeField]
    private string name;
    [SerializeField]
    private int loyal;
    [SerializeField]
    private int beauty;
    [SerializeField]
    private int handsome;
    [SerializeField]
    private int intelligent;

    private bool serverTime=false;
    private int clickCount;
    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetString("then", "07/30/2020 20:00:00");
        UpdateStatus();
        if (!PlayerPrefs.HasKey("petName"))
        {
            PlayerPrefs.SetString("petName", "CorgiBoi");
            name = PlayerPrefs.GetString("petName");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //testing click Debug.Log("Click");
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                //testing click Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag=="robot")
                {
                    clickCount++;
                    if (clickCount>=3)
                    {
                        clickCount = 0;
                        UpdateHappiness(1);
                    }
                }
            }
        }
    }

    void UpdateStatus()
    {
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }
        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }
        if (!PlayerPrefs.HasKey("loyal"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("loyal", loyal);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("loyal");
        }
        if (!PlayerPrefs.HasKey("beauty"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("beauty", beauty);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("beauty");
        }
        if (!PlayerPrefs.HasKey("handsome"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("handsome", handsome);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("handsome");
        }
        if (!PlayerPrefs.HasKey("intelligent"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("intelligent", intelligent);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("intelligent");
        }
        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
            //testing time failed Debug.Log(getTimeSpan().ToString());
        }

        TimeSpan ts = getTimeSpan();

        hunger -= (int)(ts.TotalHours * 2);
        if (hunger<0)
        {
            hunger = 0;
        }

        happiness -= (int)((100 - hunger) * (ts.TotalHours / 5));
        if (happiness<0)
        {
            happiness = 0;
        }

        if (serverTime)
        {
            UpdateServer();
        }
        else
        {
            InvokeRepeating("UpdateDevice", 0f, 30f);
        }
    }

    void UpdateServer()
    {
        //rightnow nothing
    }

    void UpdateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (serverTime)
        {
            return new TimeSpan();
        }
        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second; 
    }

    public int hungerValue
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int happinessValue
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public int loyalValue
    {
        get { return loyal; }
        set { loyal = value; }
    }
    public int beautyValue
    {
        get { return beauty; }
        set { beauty = value; }
    }
    public int handsomeValue
    {
        get { return handsome; }
        set { handsome = value; }
    }
    public int intelligentValue
    {
        get { return intelligent; }
        set { intelligent = value; }
    }

    public void UpdateHappiness(int i)
    {
        happiness += i;
        if (happiness>100)
        {
            happiness = 100;
        }
    }

    public string petName
    {
        get { return name; }
        set { name = value; }
    }

    public void saveDog()
    {
        if (!serverTime)
        {
            UpdateDevice();
            PlayerPrefs.SetInt("hunger", hunger);
            PlayerPrefs.SetInt("happiness", happiness);
        }
    }

    public void feedFood()
    {
        hunger += 10;
        handsome += 2;
        intelligent += 5;
        beauty += 10;
        loyal += 25;

    }
}
