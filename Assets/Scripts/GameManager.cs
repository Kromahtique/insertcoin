using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject camera1;
    public GameObject camera2;

    public GameObject checkPoint1;
    public GameObject checkPoint2;

    public SpriteRenderer gameOver1;
    public SpriteRenderer gameOver2;

    public GameObject player;
    public GameObject mainCamera;

    public GameObject travelThroughScreensManager;

    public bool hasStarted = false;
    public Material cameraMaterial1;
    public Material cameraMaterial2;
    public Material noScreenMaterial;

    public Canvas startText;

    private Rigidbody playerRigid;
    private Character playerController;

    private GameObject[] obstacles;
    private GameObject[] machines;

    private GameCamera gameCamera1;
    private GameCamera gameCamera2;
    private Vector3 cameraInitPosition;
    private Vector3 playerInitPosition;

    void Start () {
        gameCamera1 = camera1.GetComponent<GameCamera>();
        gameCamera2 = camera2.GetComponent<GameCamera>();

        checkPoint1.GetComponent<CheckPoint>().hasBeenTouched = true;
        startText = GameObject.Find("StartText").GetComponent<Canvas>();

        playerRigid = player.GetComponent<Rigidbody>();
        playerRigid.isKinematic = true;

        playerController = player.GetComponent<Character>();

        cameraInitPosition = mainCamera.transform.position;
        playerInitPosition = playerController.transform.position;

        machines = GameObject.FindGameObjectsWithTag("Machine");
    }

    void RestartGame()
    {
        HideGameOver();
        hasStarted = false;
        startText.enabled = true;
        playerRigid.isKinematic = true;
        mainCamera.transform.position = cameraInitPosition;
        playerController.transform.position = playerInitPosition;

        travelThroughScreensManager.GetComponent<TravelThroughScreensManager>().currentMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = noScreenMaterial;
        travelThroughScreensManager.GetComponent<TravelThroughScreensManager>().nextMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = noScreenMaterial;
        travelThroughScreensManager.GetComponent<TravelThroughScreensManager>().currentMachineID = 1;

        GameObject firstMachine = GameObject.Find("machine1");
        GameObject secondMachine = GameObject.Find("machine2");

        travelThroughScreensManager.GetComponent<TravelThroughScreensManager>().currentMachine = firstMachine;
        travelThroughScreensManager.GetComponent<TravelThroughScreensManager>().nextMachine = secondMachine;

        firstMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = cameraMaterial1;
        secondMachine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = cameraMaterial2;

        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach (GameObject obs in obstacles)
        {
            Destroy(obs);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            if (!hasStarted)
            {
                //Start the game
                hasStarted = true;
                startText.enabled = false;
                playerRigid.isKinematic = false;
            } else if (playerController.isDead)
            {
                RestartGame();
                playerController.isDead = false;
            }
        }
    }

    public void DisplayGameOver()
    {
        foreach (GameObject machine in machines)
        {
            machine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = cameraMaterial1;
        }
        
        gameOver1.enabled = true;
        gameOver2.enabled = true;
    }

    public void HideGameOver()
    {
        foreach (GameObject machine in machines)
        {
            machine.GetComponent<Machine>().getScreen().GetComponent<MeshRenderer>().material = noScreenMaterial;
        }

        gameOver1.enabled = false;
        gameOver2.enabled = false;
    }
}
