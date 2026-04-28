using UnityEngine;

public class BroomInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private string interactText = "Pick up broom";
    [SerializeField] private bool hasBeenPickedUp;

    public void Interact()
    {
        if (hasBeenPickedUp)
        {
            Debug.Log("You already have the broom.");
            return;
        }

        hasBeenPickedUp = true;


        TaskManager.Instance.GetBroom();
        TaskManager.Instance.UpdateTaskUI();
        TaskManager.Instance.CompleteTask();


        Debug.Log("You got the broom.");
    }

    public string GetInteractText()
    {
        return interactText;
    }

}
