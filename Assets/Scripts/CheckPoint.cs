using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public Camera camera;
    private GameCamera gameCamera;
    public bool hasBeenTouched = false;
    public GameWorld gameWorld;

	// Use this for initialization
	void Start () {
		gameCamera = camera.GetComponent<GameCamera>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && hasBeenTouched == false)
        {
            gameCamera.HasTouchedCheckPoint();
            hasBeenTouched = true;
            gameWorld.SwapScreens();
        }
    }
}
