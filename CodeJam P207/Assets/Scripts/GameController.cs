using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage; //The private field "bgImage" is a Sprite object that represents the background image of the puzzle buttons.

    public Sprite[] puzzles; //The public field "puzzles" is an array of Sprite objects that represent the puzzle images.

    public List<Sprite> gamePuzzles = new List<Sprite> (); //The public field "gamePuzzles" is a list of Sprite objects that represent the puzzles to be used

    public List<Button> btns = new List<Button>(); //The public field "btns" is a list of Button objects that represent the puzzle buttons in the game.

    private bool firstGuess, secondGuess; //The private bool fields "firstGuess" and "secondGuess" indicate whether the player has made their first or second guess

    //The private int fields "countGuesses", "countCorrectGuesses", and "gameGuesses" keep track of the number of guesses made by the player,
    //the number of correct guesses made, and the total number of guesses required to complete the game
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    //The private int fields "firstGuessIndex" and "secondGuessIndex"
    //keep track of the indexes of the puzzle buttons that the player has clicked for their first and second guesses
    private int firstGuessIndex, secondGuessIndex;

    //The private string fields "firstGuessPuzzle" and "secondGuessPuzzle"
    //keep track of the names of the puzzle images that correspond to the puzzle buttons that the player has clicked for their first and second guesses
    private string firstGuessPuzzle, secondGuessPuzzle;

    // The private start method is what getting called in the start of the run
    private void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }
    //The GetButtons() method finds all puzzle buttons in the game and adds them to the "btns" list.
    //It also sets the background image of each button to the "bgImage" Sprite object.
    private void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }
    //The AddGamePuzzles() method adds puzzle images to the "gamePuzzles" list
    private void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i < looper; i++)
        {

            if(index == looper / 2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);

            index++;
        }
    }
    //The AddListeners() method adds a listener to each puzzle button that calls the PickAPuzzle()
    private void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }
    //The PickAPuzzle() method is called when the player clicks a puzzle button.
    //It checks whether this is the player's first or second guess and stores the index and name of the puzzle image.
    public void PickAPuzzle()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        } 
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;

            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
    //The CheckIfThePuzzlesMatch() method is called after the player has made their second guess.
    //It waits for a .5f half a second, then checks whether the two puzzle images selected by the player match.
    //If they do, it disables the corresponding puzzle buttons and sets their images to transparent if it dont match it changes the puzzle image back to the background image
    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(.5f);

        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            yield return new WaitForSeconds(.2f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.2f);

        firstGuess = secondGuess = false;
    }
    //ChecKIfTheGameIsFinished method checks if the player made the correct guess to finish the game, it also count number of guesses it took to finish.
    private void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Game Finished");
            Debug.Log("it took u " + countGuesses + " guesses to finish");
        }
    }
    //The Shuffle() method shuffles the "gamePuzzles" list
    private void Shuffle(List<Sprite> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}
