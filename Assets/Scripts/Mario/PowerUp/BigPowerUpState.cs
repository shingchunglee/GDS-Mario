using UnityEngine;

public class BigPowerUpState : DefaultPowerUpState
{
  public override void EnterState(PowerUpStateManager stateManager)
  {
    stateManager.GetComponent<BoxCollider2D>().size = new Vector2(1f, 2f);
    stateManager.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.5f);
    stateManager.animationManager.SetPowerUpState(MarioPowerUp.Big);
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
}
