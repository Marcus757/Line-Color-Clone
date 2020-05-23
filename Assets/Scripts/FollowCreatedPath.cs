using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class FollowCreatedPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public Slider slider;
    private float distanceTraveled;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            distanceTraveled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
        }

        slider.value = (distanceTraveled / pathCreator.path.length) * 100;
    }


}
