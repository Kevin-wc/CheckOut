using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("UI References")]
    [SerializeField] private TMP_Text objectiveText;

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
    public void UpdateObjectiveText(string text)
    {
        if (objectiveText != null)
        {
            objectiveText.text = text;
        }
        else
        {
            Debug.LogWarning("Objective Text reference is missing in UIController.");
        }
    }
}
