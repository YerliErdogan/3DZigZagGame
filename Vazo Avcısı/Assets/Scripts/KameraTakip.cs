using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform topunKonumu;
    Vector3 aradakiMesafe;

    void Start()
    {
        aradakiMesafe = transform.position - topunKonumu.position;
    }


    void Update()
    {
        if (PlayerScript.topKontrol == false)
        {
            transform.position = topunKonumu.position + aradakiMesafe;
        }

    }
}
