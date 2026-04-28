using UnityEngine;

public class StalkerContact : MonoBehaviour
{
    [SerializeField] private AudioSource jumpscareAudio;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera jumpscareCamera;

    private bool hasTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            if (playerCamera != null)
            {
                playerCamera.gameObject.SetActive(false);
            }
            if (jumpscareCamera != null)
            {
                jumpscareCamera.gameObject.SetActive(true);
            }
            if (jumpscareAudio != null)
            {
                jumpscareAudio.Play();
            }

            UIController.Instance.UpdateObjectiveText("The Stalker has caught you...");
            PlayerMovement.Instance.enabled = false;
            Time.timeScale = 0f;
        }
    }
}
