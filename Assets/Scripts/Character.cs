using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float flySpeed = 5;
    public float jumpForce = 25;
    public GameManager gameManager;
    Rigidbody rigid;
    GameManager gameMan;

    public bool isDead = false;

	// Use this for initialization
	void Start () {
        rigid = transform.GetComponent<Rigidbody>();
        gameMan = gameManager.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isDead && gameMan.hasStarted)
        {
            transform.Translate(Vector3.left * Time.deltaTime * flySpeed);

            bool isJumping = Input.GetButton("Jump");
            if (isJumping)
            {
                rigid.AddForce(Vector3.up * jumpForce);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Obstacle" || col.gameObject.tag == "GeneratedObstacles") && !isDead)
        {
            gameManager.DisplayGameOver();
            rigid.isKinematic = true;
            isDead = true;
        }
    }
}
