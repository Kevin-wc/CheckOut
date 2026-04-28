using UnityEngine;

public class PhoneInteractable : MonoBehaviour, Interactable
{
    [SerializeField] private string interactText = "Call the police!";
    [SerializeField] private bool usedPhone;



    public void Interact()
    {
        if (!TaskManager.Instance.finalScareStarted)
        {
            return;
        }
        if (usedPhone)
        {
            return;
        }



        usedPhone = true;

        Debug.Log("You called the police. They are on their way!");

        if (UIController.Instance != null)
        {
            UIController.Instance.UpdateObjectiveText("The police are on their way! Remain calm, it is over");
        }
        else
        {
            Debug.LogWarning("UIController instance is missing. Cannot update objective text.");
        }

        PlayerMovement.Instance.enabled = false;
        TaskManager.Instance.StopChaseMusic();
        Time.timeScale = 0f;
    }


    public string GetInteractText()
    {
        return interactText;
    }
}