using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateWords : MonoBehaviour {

    Object Word;
    GameObject word;
    MyLists myLists;
    WordsOrPhrases wordsOrPhrases;

    static public string[] numOne;
    static public string[] numTwo;
    static public string[] numThree;
    static public string[] numFour;
    static public string[] numFive;

    

    void Start ()
    {
        Word = Resources.Load("Button");
        myLists = new MyLists();
        wordsOrPhrases = new WordsOrPhrases();

        numTwo = new string[myLists.scoreTwo.Count];
        numOne = new string[myLists.scoreOne.Count];
        numThree = new string[myLists.scoreThree.Count];
        numFour = new string[myLists.scoreFour.Count];
        numFive = new string[myLists.scoreFive.Count];

        //Debug.Log("numOne = " + numOne.Length);
        //Debug.Log("numTwo = " + numTwo.Length);
        //Debug.Log("numThree = " + numThree.Length);
        //Debug.Log("numFour = " + numFour.Length);
        //Debug.Log("numFive = " + numFive.Length);
    }

    public void CreatedWords()
    {
        // Отключаем рубашку
        Transform shirt = gameObject.transform.Find("Shirt(Clone)");
        //GameObject shirt = GameObject.FindWithTag("Shirt");
        if (shirt != null)
            shirt.gameObject.SetActive(false);

        // Ставим паддинг
        gameObject.GetComponent<VerticalLayoutGroup>().padding = new RectOffset(0, 0, 70, 0);

        for (int i = 0; i < 5; i++)
        {
            word = Instantiate(Word) as GameObject;
            word.name = "word " + (1 + i);
            word.transform.SetParent(gameObject.transform);
            word.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            word.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            word.GetComponent<RectTransform>().rotation = gameObject.GetComponent<RectTransform>().rotation;

            // Заносим слова и значения бонусов

            switch (i)
            {
                case 0:
                    int x0 = Random.Range(0, myLists.scoreOne.Count);
                    bool caseZero = false;

                    Debug.Log("x0 перед циклом foreach: " + x0);

                    for(int j = 0; j < numOne.Length; j++)
                    {
                        if(j == numOne.Length - 1)
                        {
                            if(numOne[j] != null)
                            {
                                Debug.Log("Последний индекс не равен нулю");
                                word.transform.Find("TxtName").GetComponent<Text>().text =
                                    "Всё имеет свойство кончатся, а у нас кончились слова";
                                word.transform.Find("TxtScore").GetComponent<Text>().text = "0";
                                caseZero = true;
                                break;
                            }
                        }
                    }

                    if (caseZero)
                        break;

                    foreach (var num in numOne)
                    {
                        if (num != null)
                        {
                            int q = int.Parse(num);
                            if (q == x0)
                            {
                                Debug.Log("num == x0 - true");
                                goto case 0;
                            }
                        }
                    }

                    for (int j = 0; j < numOne.Length; j++)
                    {
                        if (numOne[j] == null)
                        {
                            numOne[j] = string.Format("{0}", x0);
                            break;
                        }
                    }

                    for (int j = 0; j < numOne.Length; j++)
                    {
                        Debug.Log(string.Format("Сейчас numOne[{0}] имеет значение {1}", j, numOne[j]));
                    }

                    wordsOrPhrases = myLists.scoreOne[x0];
                    word.transform.Find("TxtName").GetComponent<Text>().text = wordsOrPhrases.Words;
                    word.transform.Find("TxtScore").GetComponent<Text>().text = "1";

                    break;
                case 1:
                    int x1 = Random.Range(0, myLists.scoreTwo.Count);
                    bool caseOne = false;

                    Debug.Log("x1 перед циклом foreach: " + x1);

                    for (int j = 0; j < numTwo.Length; j++)
                    {
                        if (j == numTwo.Length - 1)
                        {
                            if (numTwo[j] != null)
                            {
                                Debug.Log("Последний индекс не равен нулю");
                                word.transform.Find("TxtName").GetComponent<Text>().text =
                                    "Всё имеет свойство кончатся, а у нас кончились слова";
                                word.transform.Find("TxtScore").GetComponent<Text>().text = "0";
                                caseOne = true;
                                break;
                            }
                        }
                    }

                    if (caseOne)
                        break;

                    foreach (var num in numTwo)
                    {
                        if (num != null)
                        {
                            int q = int.Parse(num);
                            if (q == x1)
                            {
                                Debug.Log("num == x1 - true");
                                goto case 1;
                            }
                        }
                    }

                    for (int j = 0; j < numTwo.Length; j++)
                    {
                        if (numTwo[j] == null)
                        {
                            numTwo[j] = string.Format("{0}", x1);
                            break;
                        }
                    }

                    for (int j = 0; j < numTwo.Length; j++)
                    {
                        Debug.Log(string.Format("Сейчас numTwo[{0}] имеет значение {1}", j, numTwo[j]));
                    }
                    wordsOrPhrases = myLists.scoreTwo[x1];
                    word.transform.Find("TxtName").GetComponent<Text>().text = wordsOrPhrases.Words;
                    word.transform.Find("TxtScore").GetComponent<Text>().text = "2";

                    break;
                case 2:
                    int x2 = Random.Range(0, myLists.scoreThree.Count);
                    bool caseTwo = false;

                    Debug.Log("x2 перед циклом foreach: " + x2);

                    for (int j = 0; j < numThree.Length; j++)
                    {
                        if (j == numThree.Length - 1)
                        {
                            if (numThree[j] != null)
                            {
                                Debug.Log("Последний индекс не равен нулю");
                                word.transform.Find("TxtName").GetComponent<Text>().text =
                                    "Всё имеет свойство кончатся, а у нас кончились слова";
                                word.transform.Find("TxtScore").GetComponent<Text>().text = "0";
                                caseTwo = true;
                                break;
                            }
                        }
                    }

                    if (caseTwo)
                        break;

                    foreach (var num in numThree)
                    {
                        if (num != null)
                        {
                            int q = int.Parse(num);
                            if (q == x2)
                            {
                                Debug.Log("num == x2 - true");
                                goto case 2;
                            }
                        }
                    }

                    for (int j = 0; j < numThree.Length; j++)
                    {
                        if (numThree[j] == null)
                        {
                            numThree[j] = string.Format("{0}", x2);
                            break;
                        }
                    }

                    for (int j = 0; j < numThree.Length; j++)
                    {
                        Debug.Log(string.Format("Сейчас numThree[{0}] имеет значение {1}", j, numThree[j]));
                    }
                    wordsOrPhrases = myLists.scoreThree[x2];
                    word.transform.Find("TxtName").GetComponent<Text>().text = wordsOrPhrases.Words;
                    word.transform.Find("TxtScore").GetComponent<Text>().text = "3";

                    break;
                case 3:
                    int x3 = Random.Range(0, myLists.scoreFour.Count);
                    bool caseThree = false;

                    Debug.Log("x3 перед циклом foreach: " + x3);

                    for (int j = 0; j < numFour.Length; j++)
                    {
                        if (j == numFour.Length - 1)
                        {
                            if (numFour[j] != null)
                            {
                                Debug.Log("Последний индекс не равен нулю");
                                word.transform.Find("TxtName").GetComponent<Text>().text =
                                    "Всё имеет свойство кончатся, а у нас кончились слова";
                                word.transform.Find("TxtScore").GetComponent<Text>().text = "0";
                                caseThree = true;
                                break;
                            }
                        }
                    }

                    if (caseThree)
                        break;

                    foreach (var num in numFour)
                    {
                        if (num != null)
                        {
                            int q = int.Parse(num);
                            if (q == x3)
                            {
                                Debug.Log("num == x3 - true");
                                goto case 3;
                            }
                        }
                    }

                    for (int j = 0; j < numFour.Length; j++)
                    {
                        if (numFour[j] == null)
                        {
                            numFour[j] = string.Format("{0}", x3);
                            break;
                        }
                    }

                    for (int j = 0; j < numFour.Length; j++)
                    {
                        Debug.Log(string.Format("Сейчас numFour[{0}] имеет значение {1}", j, numFour[j]));
                    }
                    wordsOrPhrases = myLists.scoreFour[x3];
                    word.transform.Find("TxtName").GetComponent<Text>().text = wordsOrPhrases.Words;
                    word.transform.Find("TxtScore").GetComponent<Text>().text = "4";

                    break;
                case 4:
                    int x4 = Random.Range(0, myLists.scoreFive.Count);
                    bool caseFour = false;

                    Debug.Log("x3 перед циклом foreach: " + x4);

                    for (int j = 0; j < numFive.Length; j++)
                    {
                        if (j == numFive.Length - 1)
                        {
                            if (numFive[j] != null)
                            {
                                Debug.Log("Последний индекс не равен нулю");
                                word.transform.Find("TxtName").GetComponent<Text>().text =
                                    "Всё имеет свойство кончатся, а у нас кончились слова";
                                word.transform.Find("TxtScore").GetComponent<Text>().text = "0";
                                caseFour = true;
                                break;
                            }
                        }
                    }

                    if (caseFour)
                        break;

                    foreach (var num in numFive)
                    {
                        if (num != null)
                        {
                            int q = int.Parse(num);
                            if (q == x4)
                            {
                                Debug.Log("num == x4 - true");
                                goto case 4;
                            }
                        }
                    }

                    for (int j = 0; j < numFive.Length; j++)
                    {
                        if (numFive[j] == null)
                        {
                            numFive[j] = string.Format("{0}", x4);
                            break;
                        }
                    }

                    for (int j = 0; j < numFive.Length; j++)
                    {
                        Debug.Log(string.Format("Сейчас numFive[{0}] имеет значение {1}", j, numFive[j]));
                    }
                    wordsOrPhrases = myLists.scoreFive[x4];
                    word.transform.Find("TxtName").GetComponent<Text>().text = wordsOrPhrases.Words;
                    word.transform.Find("TxtScore").GetComponent<Text>().text = "5";

                    break;
                default:
                    word.transform.Find("TxtName").GetComponent<Text>().text = "Это кейс default";
                    word.transform.Find("TxtScore").GetComponent<Text>().text = "0";
                    break;
            }
        }
    }
}
