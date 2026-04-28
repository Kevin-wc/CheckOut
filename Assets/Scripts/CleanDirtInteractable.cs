using UnityEngine;

public class CleanDirtInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private string interactText = "Clean the dirt";
    [SerializeField] private bool taskCompleted;

    public void Interact()
    {
        if (taskCompleted)
        {
            Debug.Log("You already cleaned the dirt.");
            return;
        }

        if (!TaskManager.Instance.hasBroom)
        {
            Debug.Log("You need a broom to clean the dirt.");
            return;
        }

        taskCompleted = true;

        TaskManager.Instance.cleanedDirt = true;
        TaskManager.Instance.CompleteTask();
        TaskManager.Instance.UpdateTaskUI();

        Debug.Log("You cleaned the dirt.");
        gameObject.SetActive(false);
    }

    public string GetInteractText()
    {
        return interactText;
    }
}
