using System;
using System.Collections;
using UnityEngine;

public class InvincibleState : DefaultPowerUpState
{
  public bool isActive { get; private set; } = false;

  public override void EnterState(PowerUpStateManager stateManager)
  {
    isActive = true;
    Debug.Log("Is Invincible");
    stateManager.TriggerCoroutine(WaitAndEnd(8f));
    stateManager.TriggerCoroutine(FlashSprite(stateManager.spriteRenderer, 16, 0.25f));
  }

  private IEnumerator FlashSprite(SpriteRenderer spriteRenderer, int numTimes, float delay)
  {
    for (int loop = 0; loop < numTimes; loop++)
    {
      spriteRenderer.enabled = false;
      yield return new WaitForSeconds(delay);
      spriteRenderer.enabled = true;
      yield return new WaitForSeconds(delay);
    }
  }

  IEnumerator WaitAndEnd(float waitTime)
  {
    yield return new WaitForSeconds(waitTime);
    Debug.Log("Is not Invincible");
    isActive = false;
  }

  public override void OnTriggerEnterMushroom(
      PowerUpStateManager stateManager,
      GameObject mushroom
  )
  {

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
      return;
    }
  }
}
