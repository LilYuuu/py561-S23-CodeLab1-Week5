using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoaderScript : MonoBehaviour
{
    public int currentLevel = 0;
    
    public int CurrentLevel
    {
        get { return currentLevel; }
        set {
            currentLevel = value;
            LoadLevel();
        }
    }
    
    private const string FILE_NAME = "LevelNum.txt";
    private const string FILE_DIR = "/Levels/";
    private string FILE_PATH;
    
    public GameObject player;
    public GameObject wall;
    public GameObject panelA;
    public GameObject panelB;
    public GameObject trigger;
    
    GameObject currentPlayer;
    GameObject level;
    
    public Vector3 playerStartPos;
    
    public float xOffset;
    public float yOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;

        LoadLevel();
    }
    
    void LoadLevel()
    {
        Destroy(level);
        
        level = new GameObject("Level");
        
        string newPath = FILE_PATH.Replace("Num", currentLevel + "");
        
        // string fileContents = File.ReadAllText(FILE_PATH);
        string[] fileLines = File.ReadAllLines(newPath);

        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            string lineText = fileLines[yPos];
            char[] lineChars = lineText.ToCharArray();
            Debug.Log(lineText);
            for (int xPos = 0; xPos < lineChars.Length; xPos++)
            {
                char c = lineChars[xPos];

                GameObject newObj;
                GameObject newObj1;

                switch (c)
                {
                    case 'p':
                        playerStartPos = new Vector3(xOffset+xPos, 0, yOffset-yPos);
                        newObj = Instantiate<GameObject>(player);
                        newObj1 = Instantiate<GameObject>(wall);
                        currentPlayer = newObj;
                        break;
                    case 'w':
                        newObj = Instantiate<GameObject>(wall);
                        newObj1 = null;
                        break;
                    case 't':
                        newObj1 = Instantiate<GameObject>(wall);
                        newObj = Instantiate<GameObject>(trigger);
                        break;
                    case 'a':
                        newObj = Instantiate<GameObject>(panelA);
                        newObj1 = null;
                        break;
                    case 'b':
                        newObj = Instantiate<GameObject>(panelB);
                        newObj1 = null;
                        break;
                    default:
                        newObj = null;
                        newObj1 = null;
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.position = 
                        new Vector3(
                            xOffset+xPos, 0, yOffset-yPos);

                    newObj.transform.parent = level.transform;
                }
                
                if (newObj1 != null)
                {
                    newObj1.transform.position = 
                        new Vector3(
                            xOffset+xPos, 0, yOffset-yPos);

                    newObj1.transform.parent = level.transform;
                }
            }
        }
    }
    
    public void ResetPlayer()
    {
        currentPlayer.transform.position = playerStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
