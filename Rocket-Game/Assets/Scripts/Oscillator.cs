using UnityEngine;

public class Oscillator : MonoBehaviour {
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movemementFactor;
    [SerializeField] float period = 2f;

    void Start() {
        startingPosition = transform.position;
        
    }

    void Update() {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);
        
        movemementFactor = (rawSinWave + 1f) / 2f;
         
        Vector3 offset = movementVector * movemementFactor;
        transform.position = startingPosition + offset;
    }
}
