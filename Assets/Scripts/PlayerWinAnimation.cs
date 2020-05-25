using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinAnimation : MonoBehaviour
{
    private Animation playerWinAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerWinAnim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinishLineCollider")
            playerWinAnim.Play();
    }
    public void AnimateWinSequence()
    {
        Camera.main.GetComponent<Rotate>().enabled = true;
    }
}
