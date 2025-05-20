using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    public PlayerController playerController;

    public float CurrentStamina => stamina.curValue;
    
    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float staminaUseage;
    public float staminaRecoverDelay;
    private float recoverTimer = 0f;
    
    void Update()
    {
        // 이동 여부
        bool isMoving = playerController.curMovementInput != Vector2.zero;
        // 실제로 달리는 중인지 체크
        bool isSprinting = playerController.isSprinting && isMoving;
        
        if (isSprinting)
        {
            // 스테미너 감소 및 회복 딜레이 타이머 리셋
            stamina.Add(-staminaUseage * Time.deltaTime);
            recoverTimer = staminaRecoverDelay;
        }
        else
        {
            // 회복 대기 시간 경과 후에만 스태미너 회복 시작
            if (recoverTimer > 0f)
            {
                recoverTimer -= Time.deltaTime;
            }
            else
            {
                stamina.Add(stamina.passiveValue * Time.deltaTime);
            }
        }

        if (health.curValue == 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("죽었습니다.");
    }

    // 스태미너가 0 초과일 때만 달릴 수 있음
    public bool CanSprint()
    {
        return stamina.curValue > 0f;
    }
}
