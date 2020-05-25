using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject playerDebrisPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            CreateExplosion(this.gameObject.transform.position);
            this.gameObject.SetActive(false);
        }
    }

    private void CreateExplosion(Vector3 position)
    {
        Vector3 offset = new Vector3(0, .5f, 0);
        GameObject debris = Instantiate(playerDebrisPrefab, position + offset, Quaternion.identity);
    }
}
