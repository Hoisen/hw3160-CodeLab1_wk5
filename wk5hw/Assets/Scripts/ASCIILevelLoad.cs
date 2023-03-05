using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoad: MonoBehaviour
{
    public GameObject player;
    public GameObject wall;
    public GameObject spike;
    public GameObject door;
    public GameObject enemy;
    public GameObject color;
    public GameObject fire;
    public GameObject anotherDoor;

    public GameObject currentPlayer;

    private int currentLevel = 0;
    private int newcurrentLevel = 0;
    GameObject level;
    GameObject newlevel;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    public int newCurrentLevel
    {
        get
        {
            return newcurrentLevel;
        }
        set
        {
            newcurrentLevel = value;
            LoadAnotherLevel();
        }
    }
    const string FILE_NAME = "LevelNum.txt";
    const string FILE_DIR = "/Levels/";
    string FILE_PATH;
    
    //anotherLevels
    const string FILE_NEWNAME = "LevelNewNum.txt";
    const string FILE_NEWDIR = "/AnotherLevels/";
    string FILE_NEWPATH;

    public float xOffset;

    public float yOffset;

    public Vector2 playerStartPos;
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath +FILE_DIR + FILE_NAME;
        FILE_NEWPATH = Application.dataPath + FILE_NEWDIR + FILE_NEWNAME;
        LoadLevel();
    }

    bool LoadLevel()
    {
        Destroy(level);
        Destroy(newlevel);
        level = new GameObject("Level: ");
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");

        //load all the lines of the file into an array of strings
        //string[] fileLines = File.ReadAllLines(FILE_PATH);

        string[] fileLines = File.ReadAllLines(newPath);
        
        //for loop to go through each line
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //get each line out of the array
            string LineText = fileLines[yPos];
            //string fileContents = File.ReadAllText(FILE_PATH);
            //turn the current line into an array of chars
            char[] lineChars = LineText.ToCharArray();

            //loop through
            for (int i = 0; i < lineChars.Length; i++)
            {
                //get the current char
                char c = lineChars[i];
                //make a variable for a new GameObject
                GameObject newObj = null;

                switch (c)
                {
                    case 'p':
                        playerStartPos = new Vector2(i, yPos);
                        newObj = Instantiate<GameObject>(player);
                        currentPlayer = newObj;
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '^':
                        newObj = Instantiate<GameObject>(spike);
                        break;
                    case 'd':
                        newObj = Instantiate<GameObject>(anotherDoor);
                        break;
                    case 'D':
                        newObj = Instantiate<GameObject>(door);
                        break;
                    case 'f':
                        newObj = Instantiate<GameObject>(fire);
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj != null)
                {
                    //position it based on where it was
                    //in the file
                    newObj.transform.position = new Vector2(xOffset + i, yOffset -yPos);
                    newObj.transform.parent = level.transform;
                }

            }
        }

        return false;
    }
    
        bool LoadAnotherLevel()
    {
        Destroy(newlevel);
        Destroy(level);
        newlevel = new GameObject("LevelNew: ");
        string anotherNewPath = FILE_NEWPATH.Replace("Num", newcurrentLevel + "");

        //load all the lines of the file into an array of strings
        //string[] fileLines = File.ReadAllLines(FILE_PATH);

        string[] fileLines = File.ReadAllLines(anotherNewPath);
        
        //for loop to go through each line
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //get each line out of the array
            string LineText = fileLines[yPos];
            //string fileContents = File.ReadAllText(FILE_PATH);
            //turn the current line into an array of chars
            char[] lineChars = LineText.ToCharArray();

            //loop through
            for (int i = 0; i < lineChars.Length; i++)
            {
                //get the current char
                char c = lineChars[i];
                //make a variable for a new GameObject
                GameObject newObj = null;

                switch (c)
                {
                    case 'p':
                        playerStartPos = new Vector2(i, yPos);
                        newObj = Instantiate<GameObject>(player);
                        currentPlayer = newObj;
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    case '^':
                        newObj = Instantiate<GameObject>(spike);
                        break;
                    case 'd':
                        newObj = Instantiate<GameObject>(anotherDoor);
                        break;
                    case 'D':
                        newObj = Instantiate<GameObject>(door);
                        break;
                    case 'f':
                        newObj = Instantiate<GameObject>(fire);
                        break;
                    default:
                        newObj = null;
                        break;
                }

                if (newObj != null)
                {
                    //position it based on where it was
                    //in the file
                    newObj.transform.position = new Vector2(xOffset + i, yOffset -yPos);
                    newObj.transform.parent = level.transform;
                }

            }
        }

        return false;
    }

    // public void ResetPlayer()
    // {
    //     currentPlayer.transform.position = playerStartPos;
    // }

    public void DoorHit()
    {
        CurrentLevel++;
    }

    public void AnotherDoor()
    {
        newCurrentLevel++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
