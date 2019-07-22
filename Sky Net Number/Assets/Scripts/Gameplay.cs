using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] Text guessText;
    [SerializeField] bool numberFound;

    IList<int> alreadyGuessed;

    private int guess;

    // Start is called before the first frame update
    void Start()
    {
        this.numberFound = false;
        this.alreadyGuessed = new List<int>();

        this.NewGuess();

        this.max++;
    }

    public void OnPressHigher()
    {
        this.min = this.guess;

        this.NewGuess();
    }

    public void OnPressLower()
    {
        this.max = this.guess;

        this.NewGuess();
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    private void NewGuess()
    {
        if (this.numberFound)
            return;

        this.guess = Random.Range(this.min, this.max);

        if (this.alreadyGuessed.Contains(this.guess))
        {
            if (this.alreadyGuessed.Count(x => x == this.guess) > 1)
            {
                this.numberFound = true;

                GameObject.Find("Higher Button").GetComponent<Button>().interactable = false;
                GameObject.Find("Lower Button").GetComponent<Button>().interactable = false;
            }
            else
            {
                this.alreadyGuessed.Add(this.guess);

                this.NewGuess();
            }
        }
        else
        {
            this.alreadyGuessed.Add(this.guess);
        }

        this.guessText.text = this.guess.ToString();
    }
}