using UnityEngine;

public class TestInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private string interactText = "Press E to interact";

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
