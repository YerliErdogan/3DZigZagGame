using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileMenager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    public GameObject currentTile;

    private static TileMenager instance;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftTiles 
    {
        get
        {
            return leftTiles;
        }
        set
        {
            leftTiles = value;
        }
    }

    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> TopTiles 
    {
        get
        {
            return topTiles;
        }
        set
        {
            topTiles = value;
        }
    }


    public static TileMenager Instance 
    { 
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileMenager>();
            }
            return instance;
        }
    }

    void Start()
    {
        CreateTiles(100);

        for (int i = 0; i < 50; i++)
        {
            SpawnTile();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));
            topTiles.Peek().name = "TopTile";
            topTiles.Peek().SetActive(false);
            leftTiles.Peek().name = "LeftTile";
            leftTiles.Peek().SetActive(false);
            
        }
    }

    public void SpawnTile()
    {
        if (leftTiles.Count == 0 || topTiles.Count == 0)
        {
            CreateTiles(10);
        }

       int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if (randomIndex == 1)
        {

            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        int spawnPickup = Random.Range(0, 10);

        if(spawnPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
