using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public float paningSpeed = 4;
    private float yInitPos;

    public GameManager gameManager;
    
	void Start () {
        yInitPos = transform.position.y;
	}
	
	void Update () {
        if (gameManager.hasStarted)
        {
            transform.Translate(Vector3.left * paningSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
        }
	}
}
