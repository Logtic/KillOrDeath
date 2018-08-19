using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType {Small, KingSlime, Big, Elite, Boss, Abokado }
public enum MonsterState {Idle, Chase, Attack, Dead }
public abstract class Enemy : MonoBehaviour {

    public EnemyBattleTrigger enemyTrigger;
    public string enemyName;
    public int enemyAtk;
    public int enemyMaxHp;
    public int enemyCurrentHp;
    public float enemySpeed;

    public bool direction; // false -> left, true -> right
    public bool limitMove;

    public virtual void SetInitState() { }
    
    public virtual void MoveRight() { }
    public virtual void MoveLeft() { }
    
    public virtual void IdleState() { }
    public virtual void ChaseState() { }
    public virtual void AttackState() { }
    public virtual void DeadState() { }

    public virtual void DeadCheck() { }
    public virtual void EnemyMovement(MonsterState monsterState) {
        switch (monsterState) {
            case MonsterState.Idle:
                IdleState();
                break;
            case MonsterState.Chase:
                ChaseState();
                break;
            case MonsterState.Attack:
                AttackState();
                break;
            case MonsterState.Dead:
                DeadState();
                break;
        }
    }
}
