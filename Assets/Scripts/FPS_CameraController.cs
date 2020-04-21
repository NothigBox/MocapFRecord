using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CameraController : MonoBehaviour
{

    [SerializeField] Camera fpsCamera;
    [SerializeField] GameObject cameraGO;
    [SerializeField] Rigidbody rb;
    [SerializeField] bool firstPersonCameraActive=true;



    [SerializeField, Range(0, 3.0f)] float horizontalSpeed;
    [SerializeField, Range(0, 3.0f)] float verticalSpeed;

    [SerializeField] Vector2 mouseLook;
    [SerializeField] Vector2 smoothV;

    [SerializeField, Range(0, 10.0f)] float sensitivity = 5;
    [SerializeField, Range(0, 10.0f)] float smoothing = 2;

    GameObject character;

    [SerializeField] public bool isMoving = false;
    [SerializeField] public bool canMove = true;

    [SerializeField, Range(0, 1000)] float playerSpeed;

    [SerializeField] Animator playerAnimator;

    [SerializeField] float mHorizontal = 0;
    [SerializeField] float mVertical = 0;




    [SerializeField] bool thirdPersonCameraActive = false;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] public Transform Target, Player;
    float mouseX, mouseY;

    public Transform Obstruction;
    float zoomSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        Obstruction = Target;

        character = this.transform.parent.gameObject;
        //rb = character.GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        #region FPS CAMERA
        if (firstPersonCameraActive)
        {
            if (canMove)
            {
                var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

                md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

                mouseLook += smoothV;
                mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

                transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
            }
        }
        
        #endregion



        mHorizontal = Input.GetAxisRaw("Horizontal");
        mVertical = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Horizontal", mHorizontal);
        playerAnimator.SetFloat("Vertical", mVertical);

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
    private void LateUpdate()
    {
        if (thirdPersonCameraActive)
        {
            CamControl();
            ViewObstructed();
        }
        
    }

   

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if (Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }
}
