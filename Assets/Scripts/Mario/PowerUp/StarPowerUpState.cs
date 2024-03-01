using System;
using System.Collections;
using UnityEngine;

public class StarPowerUpState : DefaultPowerUpState
{
  public bool isActive { get; private set; } = false;

  public override void EnterState(PowerUpStateManager stateManager)
  {
    isActive = true;
    stateManager.TriggerCoroutine(WaitAndEnd(8f));
    stateManager.TriggerCoroutine(RainbowSprite(stateManager.spriteRenderer, 16, 0.5f));
  }

  private IEnumerator RainbowSprite(SpriteRenderer spriteRenderer, int times, float seconds)
  {
    Color[] rainbowColors = new Color[]
    {
        Color.red,
        Color.yellow,
        Color.green,
        Color.cyan,
        Color.blue,
        Color.magenta
    };

    for (int i = 0; i < times; i++)
    {
      foreach (var color in rainbowColors)
      {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(seconds / rainbowColors.Length);
      }
    }
    spriteRenderer.color = Color.white;
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
    stateManager.currentState.OnTriggerEnterMushroom(stateManager, mushroom);
  }

  internal void OnTriggerEnterStar(PowerUpStateManager powerUpStateManager, GameObject star)
  {
    GameObject.Destroy(star);
  }

  public override void UpdateState(PowerUpStateManager stateManager)
  {

  }

  internal override void OnCollideGoomba(PowerUpStateManager stateManager, GameObject goomba, bool isStomping)
  {
    // TODO: Kill Goomba
    Debug.Log("Kill Goomba");
  }
}
