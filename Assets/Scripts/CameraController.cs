using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Unity variables
    private GameObject player;

    // canvas
    [SerializeField] private GameObject platformerCanvas;

    // variables
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    [SerializeField] private float topBound;
    [SerializeField] private float bottomBound;

    // Start is called before the first frame update
    void Start()
    {
        // Unity variables
        player = GameObject.Find("Joe");

        // load UI elements
        Instantiate(platformerCanvas, transform);

        GameObject.Find("Joe").GetComponent<PlayerController>().InstantiateCanvasManager(gameObject.transform.GetChild(0).gameObject.GetComponent<CanvasManager>());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // camera follows player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        // ensure camera is within left and right bounds
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        else if (Camera.main.transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }

        // ensure camera is within top and bottom bounds
        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, transform.position.z);
        }
        else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, bottomBound, transform.position.z);
        }

    }
}
