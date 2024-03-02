using UnityEngine;

public class DefaultPowerUpState : BasePowerUpState
{
    public override void EnterState(PowerUpStateManager stateManager)
    {

    }

    public override void OnTriggerEnterMushroom(
        PowerUpStateManager stateManager,
        GameObject mushroom
    )
    {
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
            goomba.GetComponent<Goomba_Stomp>().Flatten();
            Rigidbody2D rigidbody2D = stateManager.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 3f);
            Debug.Log("Kill Goomba");
            return;
        }

        // Turn to small mario

        Debug.Log("small mario");
        stateManager.SwitchState(stateManager.smallPowerUpState);
        stateManager.invincibleState.EnterState(stateManager);
    }

    internal override void OnCollideKoopa(PowerUpStateManager stateManager, GameObject koopa, bool isStomping)
    {
        if (isStomping)
        {
            koopa.GetComponent<Koopa_Shell>().onStomp();
            Rigidbody2D rigidbody2D = stateManager.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 3f);
            return;
        }

        // Turn to small mario
        stateManager.SwitchState(stateManager.smallPowerUpState);
        stateManager.invincibleState.EnterState(stateManager);
    }
}
