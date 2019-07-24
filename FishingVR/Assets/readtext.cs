using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class readtext : MonoBehaviour
{
    public Text myText;

    // Update is called once per frame


    void Update()
    {
        string newString = randomText.FinalWord;
        myText.text = newString;
    }
}
