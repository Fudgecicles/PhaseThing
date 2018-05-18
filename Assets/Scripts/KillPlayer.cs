using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(Vector3.Dot( collision.contacts[0].normal, Vector3.up) > .5f)
        {
            Destroy(collision.gameObject);
        }
    }
}
