using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReset : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;

    void Start() {
        // rotate = transform.Rotate;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) {
            mPosDelta = Input.mousePosition - mPrevPos;
            // transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            transform.Rotate(Camera.main.transform.up, -Vector3.Dot(mPosDelta, Camera.main.transform.right), Space.World);
            transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta, Camera.main.transform.up), Space.World);
        }
        mPrevPos = Input.mousePosition;

        if(Input.GetMouseButton(1)) {
            ResetRotation();
        }
    }

    public void ResetRotation() {
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
