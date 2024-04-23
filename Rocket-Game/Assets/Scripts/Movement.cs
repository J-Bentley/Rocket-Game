using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody rb;
    [SerializeField] float mainThrust;
    [SerializeField] float rotationThrust;

    void Start() {
        rb = GetComponent<Rigidbody>();    
    }

    void Update() {
        Thrust();
        Rotation();
    }

    void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void Rotation() {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D)) {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame) {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
