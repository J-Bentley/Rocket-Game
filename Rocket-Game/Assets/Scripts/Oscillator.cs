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
        if (period <= Mathf.Epsilon) {  //epsilon = zero, avoids comparing float to float, bad practice
            return; 
        }

        float cycles = Time.time / period; //continually growing over time
        const float tau = Mathf.PI * 2; //6.283 
        float rawSinWave = Mathf.Sin(cycles * tau); //between -1 to 1
        
        movemementFactor = (rawSinWave + 1f) / 2f; //adjusted to go between 0 and 1
         
        Vector3 offset = movementVector * movemementFactor;
        transform.position = startingPosition + offset;
    }
}
