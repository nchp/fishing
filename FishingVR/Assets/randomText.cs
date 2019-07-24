using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomText : MonoBehaviour
{

    public List<string> Words;
    public static string FinalWord;
    public static string Filename;

    // Use this for initialization
    void Start()
    {
        TextAsset Text = Resources.Load<TextAsset>("Words");

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

        if ((flock.fCatch == 1) && (changeScore.gameStart == 1))
        {

            FinalWord = generateWord();
            changeWords.Word = FinalWord;
            Debug.Log("spawn word");
        }

    }




    public string generateWord()
    {
        Debug.Log("spawn ja");
        string word;
        int wordNum;

        if (spawnCFish.categoryNum == 1)

        {
            wordNum = Random.Range(0, 29);
        }
        else if (spawnCFish.categoryNum == 2)

        {
            wordNum = Random.Range(31, 93);
        }

        else if (spawnCFish.categoryNum == 3)

        {
            wordNum = Random.Range(95, 146);
        }

        else if (spawnCFish.categoryNum == 4)

        {
            wordNum = Random.Range(148, 222);
        }

        else
        {
            wordNum = Random.Range(225, 299);
        }



        //word = Words[Random.Range(0, Words.Count)];
        Debug.Log(wordNum);

        word = Words[wordNum];

        string returnWord = word;
        return returnWord;


    }

}