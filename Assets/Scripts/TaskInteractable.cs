using UnityEngine;

public class TaskInteractable : MonoBehaviour, Interactable
{

    [SerializeField] private string interactText = "Complete Task";
    [SerializeField] private string taskType;
    [SerializeField] private bool taskCompleted;

    public void Interact()
    {
        if (taskCompleted)
        {
            Debug.Log("Task already completed.");
            return;
        }

        taskCompleted = true;

        if (taskType == "Books")
        {
            TaskManager.Instance.restockedBooks = true;
        }
        else if (taskType == "Table")
        {
            TaskManager.Instance.cleanedTable = true;
        }
        else if (taskType == "Register")
        {
            TaskManager.Instance.checkedRegister = true;
        }

        Debug.Log("Task Completed: " + taskType);

        TaskManager.Instance.UpdateTaskUI();
        TaskManager.Instance.CompleteTask();

    }

    public string GetInteractText()
    {
        return interactText;
    }
}
