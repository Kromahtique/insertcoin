using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelThroughScreensManager : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;

    public Material cameraMaterial1;
    public Material cameraMaterial2;
    public Material noScreenMaterial;

    public int currentMachineID = 1;
    public GameObject machine;

    public GameWorld gameWorld;

    public GameObject currentMachine;
    public GameObject nextMachine;

    GameObject[] machines;

	// Use this for initialization
	void Start () {
        currentMachine = GameObject.Find("machine1");
        nextMachine = GameObject.Find("machine2");

        currentMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = cameraMaterial1;
        nextMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = cameraMaterial2;
    }

    public void SwapCameras()
    {
        Vector3 temp = camera2.transform.position;
        camera2.transform.position = camera1.transform.position;
        camera1.transform.position = temp;
        switchToNextMachine();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void switchToNextMachine()
    {
        currentMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = noScreenMaterial;
        currentMachine = nextMachine;
        currentMachineID++;
        
        nextMachine = GameObject.Find("machine" + (currentMachineID + 1));


        Material cameraMaterial;
        if ((currentMachineID + 1) % 2 == 0)
        {
            gameWorld.GetComponent<GameWorld>().ChooseBackground(2);
            cameraMaterial = cameraMaterial2;
        } else
        {
            gameWorld.GetComponent<GameWorld>().ChooseBackground(1);
            cameraMaterial = cameraMaterial1;
        }

        nextMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = cameraMaterial;
    }
}
