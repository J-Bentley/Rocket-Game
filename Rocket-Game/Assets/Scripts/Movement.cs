using UnityEngine;

public class Movement : MonoBehaviour {


    [SerializeField] float mainThrust;
    [SerializeField] float rotationThrust;
    [SerializeField] float thrustDemultiplier;
    [SerializeField] AudioClip thrustSound;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem leftBooster;
    Rigidbody rb;
    AudioSource audioSource;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            StartThrusting();
        }
        else {
            StopThrusting();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A)) {
            ThrustLeft();
        }
        else if (Input.GetKey(KeyCode.D)) {
            ThrustRight();
        }
        else {
            rightBooster.Stop();
            leftBooster.Stop();
        }
    }

    void StartThrusting() {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(thrustSound);
        }
        if (!mainBooster.isPlaying) {
            mainBooster.Play();
        }
    }

    void StopThrusting() {
        audioSource.Stop();
        mainBooster.Stop();
    }

    void ThrustLeft() {
        ApplyRotation(rotationThrust);
        if (!leftBooster.isPlaying) {
            leftBooster.Play();
        }
    }

    void ThrustRight() {
        ApplyRotation(-rotationThrust);
        if (!rightBooster.isPlaying) {
            rightBooster.Play();
        }
    }


    void ApplyRotation(float rotationThisFrame) {
        rb.freezeRotation = true; //forces user input to take priority over physics system
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
