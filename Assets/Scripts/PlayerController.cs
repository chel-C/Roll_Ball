using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public float Speed;
    public Text countText;
    public Text bobaCountText;
    public GameObject winHUD;
    public GameObject cupCollider;

    private Rigidbody rb;
    private int count;
    private int countBoba;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countBoba = 0;
        SetCountText ();
        SetCountBobaText();
        winHUD.gameObject.SetActive(false);

        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            //if (count >= 10)
            //{
            //    winText.text = "you did it!!";
            //   nextLevel.gameObject.SetActive(true);
            //    mainMenu.gameObject.SetActive(true);
            //}
        }
        if (other.gameObject == cupCollider)
        {
            countBoba = countBoba + 1;
            winHUD.gameObject.SetActive(true);
            SetCountBobaText();
        }
    }

    void SetCountText ()
    {
        countText.text = count.ToString();

    }

    void SetCountBobaText ()
    {
        bobaCountText.text = "Delicious Bobas: " + countBoba.ToString();

    }
}
