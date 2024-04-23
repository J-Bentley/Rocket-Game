using UnityEngine;

public class CollisionHandler : MonoBehaviour {
    void OnCollsiionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("Friendly hit");
                break;
            case "Finish":
                Debug.Log("You win!!");
                break;
            case "Fuel":
                Debug.Log("Fuel acquired.");
                break;
            default:
                Debug.Log("You blew up!!");
                break;
        }
    }
}
