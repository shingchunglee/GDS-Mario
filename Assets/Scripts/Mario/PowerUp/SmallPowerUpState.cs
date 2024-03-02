using UnityEngine;

public class SmallPowerUpState : DefaultPowerUpState
{
    public override void EnterState(PowerUpStateManager stateManager)
    {
        stateManager.animationManager.SetPowerUpState(MarioPowerUp.Small);
    }

    public override void OnTriggerEnterMushroom(
        PowerUpStateManager stateManager,
        GameObject mushroom
    )
    {
        stateManager.SwitchState(stateManager.bigPowerUpState);
        GameObject.Destroy(mushroom);
    }

    public override void UpdateState(PowerUpStateManager stateManager)
    {

    }

    internal override void OnCollideGoomba(PowerUpStateManager stateManager, GameObject goomba, bool isStomping)
    {
        if (isStomping)
        {
            // TODO: Kill Goomba
            Debug.Log("Kill Goomba");
            goomba.GetComponent<Goomba_Stomp>().Flatten();
            Rigidbody2D rigidbody2D = stateManager.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 3f);
            return;
        }
        // TODO: Kill Mario
        Debug.Log("Kill mario");
        stateManager.deathManager.OnDeath();
    }

    internal override void OnCollideKoopa(PowerUpStateManager stateManager, GameObject koopa, bool isStomping)
    {
        if (isStomping)
        {
            koopa.GetComponent<Koopa_Shell>().onStomp();
            Rigidbody2D rigidbody2D = stateManager.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5f);
            return;
        }

        // TODO: Kill Mario
        Debug.Log("Kill mario");
        stateManager.deathManager.OnDeath();
    }
}
