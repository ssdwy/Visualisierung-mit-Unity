using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    private Transform parent;
    private Vector3 playerView;
    private Vector2 rotateView;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        //var _mainCamera = parent.GetComponentInChildren<Camera>();
        //mainCamera = _mainCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Dr¨¹cken M oder N, um die Kameraposition einzustellen.
        if (Input.GetKeyDown(KeyCode.M) && transform.localPosition.z > -1f)
        {
            playerView = new Vector3(0, 0, -1.7f);
            transform.localPosition += playerView;
        }
        if (Input.GetKeyDown(KeyCode.N) && transform.localPosition.z < -1f)
        {
            playerView = new Vector3(0, 0, -1.7f);
            transform.localPosition -= playerView;
        }
        Rotate();
    }
    private void Rotate()
    {
        rotateView.x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotateView.y += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, rotateView.x);
        transform.localRotation = Quaternion.Euler(-rotateView.y, 0, 0);
    }
    //private void firstView()
    //{
    //    rotateView.x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //    rotateView.y += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    //    Playerbody.Rotate(Vector3.up, rotateView.x);
    //    transform.localRotation = Quaternion.Euler(-rotateView.y, 0, 0);
    //}
}
