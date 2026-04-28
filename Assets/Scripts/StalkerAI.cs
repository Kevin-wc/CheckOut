using UnityEngine;
using UnityEngine.AI;

public class StalkerAI : MonoBehaviour
{
    [Header("Stalker Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool isChasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            player = PlayerMovement.Instance.transform;
        }
    }
    private void Update()
    {
        if (isChasing)
        {
            agent.SetDestination(player.position);
        }
    }

    public void StartChase()
    {
        isChasing = true;
    }
}
