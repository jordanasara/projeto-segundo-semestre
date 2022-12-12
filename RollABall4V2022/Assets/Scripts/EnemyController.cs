using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

public class EnemyController : MonoBehaviour
{
    private float _moveSpeed;

    private int _maxHealthPoints;

    public EnemyDataSO enemyData; 
    
    private float moveSpeed;

    private int maxHealthPoints;

    private GameObject enemyMesh;

    public PatrolRoutManager RouteManager;

    public float FollowDistance => _followDistance;
    public float followDistance; //x = distancia minima pro inimigo seguir o jogador 

    public float ReturnDistance => _returnDistance;
    public float returnDistance; //z = distancia maxima pro inimigo seguir o jogador

    public float AttackDistance => _attackDistance;
    public float attackDistance; //y distancia minima pro inimigo atacar o jogador 

    public float GiveUpDistance => _giveUpDistance;
    public float giveUpDistance; //w distancia maxima pro inimigo atacar o jogador 

    private int _currentHealthPoints;

    private float _currentMoveSpeed;

    private Animator _enemyFSM;

    private NavMeshAgent _navMeshAgent;
    
    private SphereCollider _sphereCollider;
    
    private Object _enemyMesh;
    
    public float _returnDistance;
    
    private float _followDistance;
    
    private float _attackDistance;
    
    private float _giveUpDistance;

    private Transform _playerTransform;

    private void Awake()
    {
        _moveSpeed = enemyData.moveSpeed;
        _maxHealthPoints = enemyData.maxHealthPoints;

        //_enemyMesh = Instantiate(enemyData.enemyMesh, transform);

        _followDistance = enemyData.followDistance;
        _returnDistance = enemyData.returnDistance;
        _attackDistance = enemyData.attackDistance;
        _giveUpDistance = enemyData.giveUpDistance;

        _currentHealthPoints = _maxHealthPoints;
        _currentMoveSpeed = _moveSpeed;

        _enemyFSM = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _sphereCollider = GetComponent<SphereCollider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSphereRadius(float value)
    {
        _sphereCollider.radius = value;
    }

    public void SetDestinationToPlayer()
    {
        //transform.position += (_playerTransform.position - transform.position).normalized * _moveSpeed * Time.deltaTime;
        _navMeshAgent.SetDestination(_playerTransform.position)
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTransform = other.transform;
            _enemyFSM.SetTrigger(name: "OnPlayerEntered");
            Debug.Log("Jogador entrou.");
        }
    }
}
