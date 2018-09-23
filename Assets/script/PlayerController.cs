using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;
    public GameObject player;

    private Rigidbody rb;
    private int count;
    private int score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText ();
        SetScoreText();
        winText.text = "";
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        if (other.gameObject.CompareTag("Non-Pickups"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetScoreText();
        }
        
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        scoreText.text = "Score: " + score.ToString();
        if (count == 12)
        {
            winText.text = "Congradulations You Won! Your score is:" + score.ToString();
            transform.position = new Vector3(21.14f, 0.489f, 7.56f);
        }
        else if (count == 24)
        {
            winText.text = "Congradulations You Won! Your score is:" + score.ToString();
        }
        else
        {
            winText.text = "";
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }


}
