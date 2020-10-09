using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour{
    public float movementSpeed = 1f;
    private Rigidbody rbody;
    private float movementX;
    private float movementY;
    private int scoreCounter;
    public TextMeshProUGUI scoreCounterText;
    public GameObject winText;
    // Start is called before the first frame update
    void Start(){
        rbody = GetComponent<Rigidbody>();
        scoreCounter = 0;  
    }

    // Update is called once per frame
    void Update(){
    
    }

    void SetScoreCounterText(){
        scoreCounterText.SetText("Score : " + scoreCounter.ToString());
        if(scoreCounter >= 12){
            winText.SetActive(true);
        }
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y; 
    }

    private void FixedUpdate() {
        Vector3 movementForce = new Vector3(movementX, 0f, movementY);
        rbody.AddForce(movementForce * movementSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Collectables")){
            other.gameObject.SetActive(false);
            scoreCounter++;
            SetScoreCounterText();
        }
    }
}
