using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeWords : MonoBehaviour
{
    public Text myWord;
    public static string Word;

    // Update is called once per frame
    void Update()
    {

        string newString = Word;
        myWord.text = newString;

    }
}
