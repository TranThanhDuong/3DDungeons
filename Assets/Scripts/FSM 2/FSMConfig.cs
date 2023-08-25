using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMConfig 
{

}
public enum Actionkey
{
    NONE=0,
    IDLE =1,
    MOVE=2,
    VAULT=3,
    CLIMB=4,
    DEAD=5,
    RUN=6,
    SPAWN=7,
    SPAWNBOSS=8,
    MOVEBOSS=9,
    ATTACK =10,
    WANDER = 11,
    CHASE = 12,
    PATROL =13,
    GETHIT = 14 ,
    JUMP=15,
    FALLBACK=16,
    STUN=17,
    JUMPBOSSSKILL=18,
    STRONGATTACKSKILL=19,
    TELEPORTSKILL=20,
    SPINSKILL=21,
    ATTACKBOSS = 22,
    IDLEBOSS = 23,
    DEADBOSS=24,
    THROW=25,
    SPAWNBOSSMINIONS = 26,
    IDLEBOSSMINIONS = 27,
    MOVEBOSSMINIONS = 28,
    ATTACKBOSSMINIONS = 29,
    DEADBOSSMINIONS = 30


}
public class FSMData
{

}
public class FSMSampleData: FSMData
{
    public Sample parent;
}
public class Samurai_Grunt_Black_Data : FSMData
{
    public EnemyControl parent;
}
