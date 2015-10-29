using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float Speed;

    private Rigidbody _playerRigidbody;
    private float horizontal;
    private float vertical;
    private DialogueInit _dialogueHandler;

    // Use this for initialization
    void Start()
    {
        _dialogueHandler = GameObject.FindGameObjectWithTag("DialogueHandler").GetComponent<DialogueInit>();
        _playerRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        _playerRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * Speed, ForceMode.Impulse);

        RayTarget();
    }

    void RayTarget()
    {
        Debug.DrawRay(this.transform.position, new Vector3(horizontal, 0, vertical), Color.blue);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(horizontal, 0, vertical), out hit, 1f))
        {
            if (hit.transform.tag == "Person")
            {
                Debug.Log("It's a person");
                if(Input.GetButtonDown("Fire1"))
                {
                    _dialogueHandler.DialogueStart();
                    Debug.Log("Starting dialogue");
                }
            }
        }
    }
}
