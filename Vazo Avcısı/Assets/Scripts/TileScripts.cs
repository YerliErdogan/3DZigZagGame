using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScripts : MonoBehaviour
{
    private float fallDealy = 0.5f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileMenager.Instance.SpawnTile();
            StartCoroutine(FallDawn());
        }
    }

    IEnumerator FallDawn()
    {
        yield return new WaitForSeconds(fallDealy);
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(2);
        switch (gameObject.name)
        {
            case "LeftTile":
                TileMenager.Instance.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopTile":
                TileMenager.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }
}
