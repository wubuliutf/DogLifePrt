using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;
    public GameObject dog;
    public GameObject beautyText;
    public GameObject loyalText;
    public GameObject handsomeText;
    public GameObject intelligentText;

    // Update is called once per frame
    void Update()
    {
        happinessText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().happinessValue;
        hungerText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().hungerValue;
        beautyText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().beautyValue;
        loyalText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().loyalValue;
        handsomeText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().handsomeValue;
        intelligentText.GetComponent<Text>().text = "" + dog.GetComponent<Dog>().intelligentValue;
    }

    public void buttonBehavior(int i)
    {
        switch (i)
        {
            case (0):
                //not able to implement look
                break;

            case (1):
                dog.GetComponent<Dog>().feedFood();
                break;

            case (2):
                break;

            case (3):
                dog.GetComponent<Dog>().saveDog();
                Application.Quit();
                break;
        }
    }
}
