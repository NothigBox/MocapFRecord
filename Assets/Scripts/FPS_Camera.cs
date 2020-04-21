using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField, Range(0, 3.0f)] float horizontalSpeed;
    [SerializeField, Range(0, 3.0f)] float verticalSpeed;

    [SerializeField] Vector2 mouseLook;
    [SerializeField] Vector2 smoothV;

    [SerializeField, Range(0, 10.0f)] float sensitivity = 5;
    [SerializeField, Range(0, 10.0f)] float smoothing = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region FPS CAMERA
        if (playerController.firstPersonCameraActive)
        {
            if (playerController.canMove)
            {
                var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

                md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

                mouseLook += smoothV;
                mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                playerController.character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, playerController.character.transform.up);
            }
        }

        #endregion



        

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Cursor.visible == false)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.lockState = CursorLockMode.Confined;
            }

        }


    }
}
