using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    [SerializeField] private StalkerAI stalkerAI;

    [Header("Task Settings")]
    [SerializeField] private int currentTask;
    [SerializeField] private int totalTasks;
    private bool tasksComplete;

    [Header("Task State")]
    public bool restockedBooks;
    public bool cleanedTable;
    public bool checkedRegister;
    public bool gotBroom;
    public bool cleanedDirt;

    [Header("Item State")]
    public bool hasBroom;

    [Header("Final Scare")]
    [SerializeField] private GameObject stalkerObject;
    public bool finalScareStarted;

    [Header("Audio")]
    [SerializeField] private AudioSource chaseMusicAudio;


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
        UpdateTaskUI();
    }

    public void CompleteTask()
    {
        if (tasksComplete)
        {
            return;
        }

        currentTask++;

        Debug.Log("Task complete. Current task: " + currentTask);

        if (currentTask == 1)
        {
            Debug.Log("Objective: Clean the reading table.");
        }
        else if (currentTask == 2)
        {
            Debug.Log("Objective: Check the register");
        }
        else if (currentTask == 3)
        {
            Debug.Log("Objective: Get the broom from closet");
        }
        else if (currentTask == 4)
        {
            Debug.Log("Objective: Clean the dirt from the library floor");
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

        finalScareStarted = true;

        if (stalkerObject != null)
        {
            stalkerObject.SetActive(true);
            StalkerAI stalkerAI = stalkerObject.GetComponent<StalkerAI>();
        }

        if (stalkerAI != null)
        {
            stalkerAI.StartChase();
        }

        if (chaseMusicAudio != null)
        {
            chaseMusicAudio.Play();
        }

        UIController.Instance.UpdateObjectiveText("RUN TO THE OFFICE AND CALL THE POLICE!");
    }

    public void GetBroom()
    {
        hasBroom = true;
        gotBroom = true;
        Debug.Log("You picked up the broom.");
    }

    public void UpdateTaskUI()
    {
        string text = "Closing Tasks:\n";

        if (restockedBooks)
        {
            text += "<s>Restock Books</s>\n";
        }
        else
        {
            text += "Restock Books\n";
        }
        if (cleanedTable)
        {
            text += "<s>Clean Reading Table</s>\n";
        }
        else
        {
            text += "Clean Reading Table\n";
        }

        if (checkedRegister)
        {
            text += "<s>Check Register</s>\n";
        }
        else
        {
            text += "Check Register\n";
        }

        if (gotBroom)
        {
            text += "<s>Get Broom</s>\n";
        }
        else
        {
            text += "Get Broom\n";
        }

        if (cleanedDirt)
        {
            text += "<s>Clean Dirt</s>\n";
        }
        else
        {
            text += "Clean Dirt\n";
        }

        UIController.Instance.UpdateObjectiveText(text);
    }

    public void StopChaseMusic()
    {
        if (chaseMusicAudio != null && chaseMusicAudio.isPlaying)
        {
            chaseMusicAudio.Stop();
        }
    }

}
