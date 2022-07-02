using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPlacementScript : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovementScript;
    [SerializeField] Transform firePointLocation;
    // Start is called before the first frame update
    void Start()
    {
        firePointLocation.localPosition = new Vector3(0.125f, -0.021f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovementScript.isCrouching)
        {
            firePointLocation.localPosition = new Vector3(0.16f, -0.075f, 0);

        }
        else
        {
            firePointLocation.localPosition = new Vector3(0.125f, -0.021f, 0);
        }
    }
}
