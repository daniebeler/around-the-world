using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject planet;
    public InputField inputField;

    private Vector3 inputVector;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inputField.text = "";
        inputField.onEndEdit.AddListener(delegate { inputSubmitCallBack(); });

        inputField.ActivateInputField();
        inputField.Select();
    }

    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * 10f, rb.velocity.y, Input.GetAxis("Vertical") * 10);

        transform.Translate(Vector3.forward * 3 * Time.deltaTime);

        rb.AddForce((transform.position - planet.transform.position).normalized * -9.81f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.up,
            (transform.position - planet.transform.position).normalized) * transform.rotation, 100 * Time.deltaTime);
    }

    private void inputSubmitCallBack()
    {

        if (inputField.text == "left")
        {
            transform.Rotate(new Vector3(0, 1, 0), -10f);
        }

        if (inputField.text == "right")
        {
            transform.Rotate(new Vector3(0, 1, 0), 10f);
        }

        Debug.Log(inputField.text);
        inputField.text = "";
        inputField.ActivateInputField();
        inputField.Select();
    }
}
