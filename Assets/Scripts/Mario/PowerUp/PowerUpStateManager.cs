using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpStateManager : MonoBehaviour
{
    public BasePowerUpState currentState;
    public SmallPowerUpState smallPowerUpState = new SmallPowerUpState();
    public BigPowerUpState bigPowerUpState = new BigPowerUpState();
    public StarPowerUpState starPowerUpState = new StarPowerUpState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = smallPowerUpState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        starPowerUpState.UpdateState(this);
        currentState.UpdateState(this);
    }

    public void SwitchState(BasePowerUpState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Item>(out Item item))
        {
            switch (item.itemType)
            {
                case ItemType.star:
                    starPowerUpState.EnterState(this);
                    starPowerUpState.OnTriggerEnterStar(this, other.gameObject);
                    break;
                case ItemType.mushroom:
                    currentState.OnTriggerEnterMushroom(this, other.gameObject);
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            BasePowerUpState powerUpState = currentState;
            if (starPowerUpState.isActive)
            {
                powerUpState = starPowerUpState;
            }

            bool isStomping = IsPlayerStomping(enemy, collision);

            switch (enemy.enemyType)
            {
                case EnemyType.goomba:
                    powerUpState.OnCollideGoomba(this, collision.collider.gameObject, isStomping);
                    break;
            }
        }
    }

    private bool IsPlayerStomping(Enemy enemy, Collision2D collision)
    {
        foreach (ContactPoint2D point in collision.contacts)
        {
            if (point.normal.y > 0.5f)
            {
                return true;
            }
        }
        return false;
    }
}
