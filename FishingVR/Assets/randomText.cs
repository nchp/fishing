using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomText : MonoBehaviour
{

    public List<string> Words;
    public static string FinalWord;
    public static string Filename;
    public static int wordNum;
    public static bool wordTemp;
    // Use this for initialization
    void Start()
    {

        TextAsset Text = Resources.Load<TextAsset>("test");

        string[] lines = Text.text.Split("\n"[0]);

        bool addingWords = true;

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i] == "Words:")
            {
                addingWords = true;
                Debug.Log("adding Words");
                continue;
            }

            if (lines[i] != "")
            {
                if (addingWords)
                {
                    Words.Add(lines[i]);
                }

            }


        }

    }



    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Filename);
        if ((spawnCFish.wordEnable == 1) && (changeScore.gameStart == 1))
        {

            FinalWord = generateWord();
            spawnCFish.wordEnable = 0;
            changeWords.Word = FinalWord;
            Debug.Log("spawn word");
        }

    }




    public string generateWord()
    {
        Debug.Log("spawn ja");
        string word;


        if (spawnCFish.categoryNum == 1)

        {
            wordNum = Random.Range(0, 29);
            Debug.Log(wordNum);
        }


        if (spawnCFish.categoryNum == 2)

        {
            wordNum = Random.Range(31, 93);
            Debug.Log(wordNum);
        }

        if (spawnCFish.categoryNum == 3)

        {
            wordNum = Random.Range(95, 146);
            Debug.Log(wordNum);
        }

        if (spawnCFish.categoryNum == 4)

        {
            wordNum = Random.Range(148, 222);
            Debug.Log(wordNum);
        }

        if (spawnCFish.categoryNum == 5)
        {
            wordNum = Random.Range(225, 299);
            Debug.Log(wordNum);
        }

        //word = Words[Random.Range(0, Words.Count)];

        word = Words[wordNum];

        string returnWord = word;


        return returnWord;

    }


}