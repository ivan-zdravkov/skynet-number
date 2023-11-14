using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    int originalMin;
    int originalMax;

    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] Text guessText;

    private int guess;

    // Start is called before the first frame update
    void Start()
    {
        this.originalMin = min;
        this.originalMax = max;

        this.NewGuess();
    }

    public void OnPressHigher()
    {
        if (this.guess == this.originalMax || this.min >= this.max)
            this.DisableButtons();
        else
        {
            this.min = this.guess + 1;

            this.NewGuess();
        }
    }

    public void OnPressLower()
    {
        if (this.guess == this.originalMin || this.min >= this.max)
            this.DisableButtons();
        else
        {
            this.max = this.guess - 1;

            this.NewGuess();
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    private void NewGuess()
    {
        this.guess = Random.Range(this.min, this.max + 1);

        this.guessText.text = this.guess.ToString();
    }

    private void DisableButtons()
    {
        GameObject.Find("Higher Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Lower Button").GetComponent<Button>().interactable = false;
    }
}