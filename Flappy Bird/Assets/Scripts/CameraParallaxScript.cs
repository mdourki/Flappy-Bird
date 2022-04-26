using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParallaxScript : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        transform.position = new Vector3(Player.transform.localPosition.x, transform.localPosition.y , transform.localPosition.z );
    }
}
