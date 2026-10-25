using System.Collections;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    // Busca - Vê o Player - Persegue - Perde o player - Some - Volta a buscar

    // REFERÊNCIAS
    public Transform player;

    // NAVMESH
    public NavMeshAgent agent;

    // DISTÂNCIAS
    public float visionDistance = 10f;
    public float loseDistance = 15f;

    [Header("Respawn")]
    public Transform[] spawnPoints;

    public float minRespawnTime = 8f;
    public float maxRespawnTime = 15f;

    // TIMER
    public float loseTime = 5f;
    private float loseTimer;

    // ESTADOS
    public enum EnemyState
    {
        Wandering,
        Chasing,
        Respawning
    }

    public EnemyState currentState;

  void Start()
{
    agent = GetComponent<NavMeshAgent>();

    agent.updateRotation = false;
    agent.updateUpAxis = false;

    currentState = EnemyState.Wandering;
}

    void Update()
    {
        float distance =
            Vector3.Distance(transform.position, player.position);

    switch(currentState)
{
    case EnemyState.Wandering:

        Wander();

        if(distance < visionDistance)
        {
            currentState = EnemyState.Chasing;
        }

        break;

    case EnemyState.Chasing:

        ChasePlayer();

        if(distance > loseDistance)
        {
            loseTimer += Time.deltaTime;

            if(loseTimer >= loseTime)
            {
                DespawnEnemy();
            }
        }
        else
        {
            loseTimer = 0;
        }

        break;

    case EnemyState.Respawning:
        break;
}
    }

    void Wander()
    {
        // Por enquanto vazio
        // Depois podemos adicionar patrulha
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

  void DespawnEnemy()
{
    Debug.Log("Inimigo sumiu!");

    currentState = EnemyState.Respawning;

    StartCoroutine(RespawnEnemy());
}

   IEnumerator RespawnEnemy()
{
    // DESLIGA O INIMIGO
    agent.enabled = false;

    GetComponent<Collider>().enabled = false;

    SpriteRenderer sprite =
        GetComponentInChildren<SpriteRenderer>();

    if(sprite != null)
    {
        sprite.enabled = false;
    }

    // TEMPO ALEATÓRIO
    float randomTime =
        Random.Range(minRespawnTime, maxRespawnTime);

    yield return new WaitForSeconds(randomTime);

    // ESCOLHE SPAWN ALEATÓRIO
    int randomSpawn =
        Random.Range(0, spawnPoints.Length);

    transform.position =
        spawnPoints[randomSpawn].position;

    // REATIVA
    if(sprite != null)
    {
        sprite.enabled = true;
    }

    GetComponent<Collider>().enabled = true;

    agent.enabled = true;

    // VOLTA AO ESTADO NORMAL
    currentState = EnemyState.Wandering;

    loseTimer = 0;

    Debug.Log("Inimigo reapareceu!");
}
}