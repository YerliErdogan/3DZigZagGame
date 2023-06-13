using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float artanHiz;
    public GameObject ps;
    private Vector3 dir;
    public static bool topKontrol;
    public GameObject resetBtn;
    private int score = 0;
    public Text scoreText;
    private Animator animator;
    public GameObject ýmage;
    public AudioSource audioSource;
    public GameObject exitBtn;
    public AudioSource soundVase;


    void Start()
    {
        animator = GetComponent<Animator>();
        topKontrol = false;
        dir = Vector3.zero;
    }

   
    void Update()
    {   
        if (transform.position.y <= 0.5f)
        {
            animator.SetBool("IsFalling", true);
            resetBtn.SetActive(true);
            ýmage.SetActive(true);
            exitBtn.SetActive(true);
            audioSource.mute = true;
            topKontrol = true;
        }

        if (topKontrol == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            dir = Vector3.forward;

            animator.SetBool("IsMoving", true);

            if(transform.rotation == Quaternion.LookRotation(Vector3.left))
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(Vector3.left);
            }
        }

        speed += artanHiz * Time.deltaTime;

        float amoutToMove = speed * Time.deltaTime;

        transform.Translate(dir * amoutToMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag ==  "Pickup"){
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 5;
            scoreText.text = score.ToString();
            soundVase.playOnAwake = true;

        }
    }

   
}
