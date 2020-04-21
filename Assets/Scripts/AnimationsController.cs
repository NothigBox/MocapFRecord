using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    [SerializeField] float mHorizontal = 0;
    [SerializeField] float mVertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mHorizontal = Input.GetAxisRaw("Horizontal");
        mVertical = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Horizontal", mHorizontal);
        playerAnimator.SetFloat("Vertical", mVertical);
    }
}
