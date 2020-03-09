using UnityEngine;

public class GameCamera : MonoBehaviour {

    public TravelThroughScreensManager travelThroughScreensManager;
    public Camera otherCameraObject;
    public GameObject checkPointObject;
    public CheckPoint otherCheckPoint;

    private CheckPoint checkPoint;
    private GameCamera otherCamera;

    private bool hasPassedCheckPoint = false;
    
    void Start () {
        checkPoint = checkPointObject.GetComponent<CheckPoint>();
        otherCamera = otherCameraObject.GetComponent<GameCamera>();
    }

    public void HasTouchedCheckPoint()
    {
        travelThroughScreensManager.SwapCameras();
        otherCheckPoint.hasBeenTouched = false;
    }

    public CheckPoint getCheckpoint()
    {
        return checkPoint;
    }
}
