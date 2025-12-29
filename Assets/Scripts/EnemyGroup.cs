using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float speedIncriser = 1.1f;
    [SerializeField] private float moveDownAmount = 0.5f;
    private Vector3 direction = Vector3.right;
    private float leftLimit = -8f;
    private float rightLimit = 8f;

    [Header("Shooting Settings")]
    [SerializeField] private float minShootInterval = 2f;
    [SerializeField] private float maxShootInterval = 5f;

    private List<Enemy> enemies = new List<Enemy>();
    private float nextShootTime;
    private GameManager gameManager;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            Enemy e = child.GetComponent<Enemy>();
            if (e != null)
                enemies.Add(e);
        }

        ScheduleNextShot();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        MoveGroup();
        CleanEnemyList();

        if (Time.time >= nextShootTime)
        {
            ShootFromRandomShooter();
            ScheduleNextShot();
        }

        if(enemies.Count == 0)
        {
            gameManager.winText.SetActive(true);
        }
    }

    private void MoveGroup()
    {
        transform.position += direction * speed * Time.deltaTime;

        foreach (Transform enemy in transform)
        {
            if (enemy == null) continue;
            if (direction == Vector3.right && enemy.position.x >= rightLimit)
            {
                MoveDown();
                direction = Vector3.left;
                break;
            }
            else if (direction == Vector3.left && enemy.position.x <= leftLimit)
            {
                MoveDown();
                direction = Vector3.right;
                break;
            }
        }
    }

    private void MoveDown()
    {
        transform.position += Vector3.down * moveDownAmount;
        speed = speed * speedIncriser;
        if(maxShootInterval > 0)
        {
            maxShootInterval = maxShootInterval / speedIncriser;
        }
        
    }

    private void CleanEnemyList()
    {
        enemies.RemoveAll(e => e == null);
    }

    private void ScheduleNextShot()
    {
        nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
    }

    private void ShootFromRandomShooter()
    {
        List<Enemy> shootingEnemies = enemies.FindAll(e => e != null && e.EnemyType == 2);

        if (shootingEnemies.Count > 0)
        {
            Enemy randomShooter = shootingEnemies[Random.Range(0, shootingEnemies.Count)];
            randomShooter.Shoot(); //disparamos desde el enemigo
        }
    }
}
