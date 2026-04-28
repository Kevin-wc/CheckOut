using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    [Header("Task Settings")]
    [SerializeField] private int currentTask;
    [SerializeField] private int totalTasks;
    private bool tasksComplete;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        currentTask = 0;
        Debug.Log("Objective: Organize the books");
    }

    public void CompleteTask()
    {
        if (tasksComplete)
        {
            return;
        }

        currentTask++;

        if (currentTask == 1)
        {
            Debug.Log("Objective: Clean the reading table.");
        }
        else if (currentTask == 2)
        {
            Debug.Log("Objective: Check the register");
        }
        else if (currentTask >= totalTasks)
        {
            tasksComplete = true;
            Debug.Log("All tasks complete! Something feels off...");
            StartFinalScare();
        }

    }

    private void StartFinalScare()
    {
        // Implement final scare logic here
        Debug.Log("A book falls from the shelf");
        Debug.Log("Objective: Run to the office!");
    }

}
