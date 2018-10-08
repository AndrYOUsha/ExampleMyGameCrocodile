using System.Collections;
using System.Collections.Generic;

public class MyLists
{
    public List<WordsOrPhrases> scoreOne = new List<WordsOrPhrases>();
    public List<WordsOrPhrases> scoreTwo = new List<WordsOrPhrases>();
    public List<WordsOrPhrases> scoreThree = new List<WordsOrPhrases>();
    public List<WordsOrPhrases> scoreFour = new List<WordsOrPhrases>();
    public List<WordsOrPhrases> scoreFive = new List<WordsOrPhrases>();

    public MyLists()
    {
        ScoreOne();
        ScoreTwo();
        ScoreThree();
        ScoreFour();
        ScoreFive();
    }

    void ScoreOne()
    {
        scoreOne.Add(new WordsOrPhrases { Words = "Конфета"});
        scoreOne.Add(new WordsOrPhrases { Words = "Пила"});
        scoreOne.Add(new WordsOrPhrases { Words = "Баня"});
    }

    void ScoreTwo()
    {
        scoreTwo.Add(new WordsOrPhrases { Words = "Крушить"});
        scoreTwo.Add(new WordsOrPhrases { Words = "Есть"});
        scoreTwo.Add(new WordsOrPhrases { Words = "Бежать"});
    }

    void ScoreThree()
    {
        scoreThree.Add(new WordsOrPhrases { Words = "Обёрточная бумага"});
        scoreThree.Add(new WordsOrPhrases { Words = "Машина времени"});
        scoreThree.Add(new WordsOrPhrases { Words = "Лампочка ильича"});
    }

    void ScoreFour()
    {
        scoreFour.Add(new WordsOrPhrases { Words = "Барабашка"});
        scoreFour.Add(new WordsOrPhrases { Words = "Время приключений"});
        scoreFour.Add(new WordsOrPhrases { Words = "Мастер и Маргарита"});
    }

    void ScoreFive()
    {
        scoreFive.Add(new WordsOrPhrases { Words = "Чип и Дейл спешат на помощь"});
        scoreFive.Add(new WordsOrPhrases { Words = "Гадкий кайот"});
        scoreFive.Add(new WordsOrPhrases { Words = "Поручик Ржевский"});
    }
}
