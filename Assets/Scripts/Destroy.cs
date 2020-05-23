using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject playerDebrisPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.gameObject.tag.ToString());
            CreateExplosion(this.gameObject.transform.position);
            Destroy(this.gameObject);
        }
    }

    private void CreateExplosion(Vector3 position)
    {
        Vector3 offset = new Vector3(0, .5f, 0);
        GameObject debris = Instantiate(playerDebrisPrefab, position + offset, Quaternion.identity);
    }
}
