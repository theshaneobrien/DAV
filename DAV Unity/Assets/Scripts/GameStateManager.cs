using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GamePlayUIManager uiManager;

    private bool isGameOver;

    private bool canInteractWithSomething;
    private DoorBehaviour doorWeAreCurrentlyAt;

    private float gameTimer;
    [SerializeField] private int maxGameTime = 10;
    
    //These are the variables related to the puzzle state
    [SerializeField] private List<Transform> puzzlePieces = new List<Transform>();
    [SerializeField] private List<bool> puzzlePiecesState = new List<bool>();

    [SerializeField] private GameObject keyGO;

    [SerializeField] private Dictionary<string, int> playerInventory = new Dictionary<string, int>();


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        uiManager = this.GetComponent<GamePlayUIManager>();

        foreach (var puzzlePiece in puzzlePieces)
        {
            puzzlePiecesState.Add(false);
        }
        
        playerInventory.Add("Key", 0);
        
        Debug.Log("We have " + playerInventory["Key"] + " Keys");
    }

    private void Update()
    {
        ContextSensitiveButtonPress();
        
        ProcessTimer();
    }

    private void ProcessTimer()
    {
        // Delta Time = time it takes to render a single frame
        gameTimer = gameTimer + Time.deltaTime;
        
        //This checks if our time limit was hit
        if (gameTimer >= maxGameTime)
        {
            //We need to tell the player they lost!
            uiManager.GameOverUI();
            isGameOver = true;
        }
        
        uiManager.SetGamePlayTimerUI(FormatTimer());
    }

    private void ContextSensitiveButtonPress()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (canInteractWithSomething == true)
            {
                if (doorWeAreCurrentlyAt != null)
                {
                    doorWeAreCurrentlyAt.OpenDoor();
                }
                else if (doorWeAreCurrentlyAt == null)
                {
                    Debug.Log("We never attached a door to this trigger");
                }
            }
            CheckPuzzleRotation();
        }
    }

    private void CheckPuzzleRotation()
    {
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            Transform puzzlePiece = puzzlePieces[i];
            if (puzzlePiece.transform.rotation.eulerAngles.y == 0)
            {
                puzzlePiecesState[i] = true;
                CheckIfPuzzleIsSolved();
            }
            else
            {
                puzzlePiecesState[i] = false;
            }
        }
    }

    private void CheckIfPuzzleIsSolved()
    {
        int countOfSolvedPieces = 0;
        foreach (bool puzzleState in puzzlePiecesState)
        {
            if (puzzleState == true)
            {
                countOfSolvedPieces += 1;
            }
        }

        if (countOfSolvedPieces >= 3)
        { 
            keyGO.SetActive(true);
        }
    }

    public void AddToInventory(string itemToAdd)
    {
        if (playerInventory.ContainsKey(itemToAdd))
        {
            playerInventory[itemToAdd] = playerInventory[itemToAdd] + 1;
            Debug.Log("We have " + playerInventory[itemToAdd] + " " + itemToAdd);
        }
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    public GamePlayUIManager GetUiManager()
    {
        return uiManager;
    } 
    
    public void SetCurrentContextInteractable(bool canInteract, DoorBehaviour doorToInteractWith)
    {
        canInteractWithSomething = canInteract;
        doorWeAreCurrentlyAt = doorToInteractWith;
    }

    private string FormatTimer()
    {
        //TODO: Fix the seconds so they dont go above 60
        int minutes = (int)gameTimer / 60;
        int seconds = (int)gameTimer;
        
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
