using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class FollowCreatedPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public Slider slider;
    public bool isPathCompleted = false;
    private float distanceTraveled;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (isPathCompleted)
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            distanceTraveled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
        }

        #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            distanceTraveled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
        }
        #endif

        slider.value = (distanceTraveled / pathCreator.path.length) * 100;

        if (slider.value >= 99.5f)
        {
            gameObject.GetComponent<FollowCreatedPath>().enabled = false;
            isPathCompleted = true;
        }
    }

    public int GetPercentageComplete()
    {
        return (int)(distanceTraveled / pathCreator.path.length * 100);
    }
}
