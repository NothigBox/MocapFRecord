using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    [SerializeField] GameObject fpsCamera;
    [SerializeField] GameObject thirdPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            fpsCamera.SetActive(true);
            thirdPersonCamera.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            fpsCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
        }
    }
}
