using UnityEngine;
using TMPro;

// Make SURE this line includes ": MonoBehaviour" at the end!
public class LocationDisplayManager : MonoBehaviour
{
    // This public variable will create a slot in the Unity Inspector
    // where we can drag our TextMeshPro object.
    public TextMeshProUGUI locationText;

    // The Start method is called once when the game begins.
    void Start()
    {
        // Check if the locationText has been assigned in the Inspector
        if (locationText != null)
        {
            // Set the text property of our UI element.
            locationText.text = "Whispering Woods - Start";
        }
        else
        {
            // Log an error to the console if we forgot to link the text object.
            Debug.LogError("Location Text is not assigned in the LocationDisplayManager script!");
        }
    }
}