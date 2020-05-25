using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayTreasureChestShakeAnimation()
    {
        anim.SetBool("isShaking", true);
    }

    public void PlayOpenChestAnimation()
    {
        anim.SetBool("isShaking", false);
        anim.SetBool("isOpen", true);
    }
}
