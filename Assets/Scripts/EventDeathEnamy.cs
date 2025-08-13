using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDeathEnamy : MonoBehaviour
{
    public static event Action EnemyDied;

    public static void OnEnemyDied()
    {
        EnemyDied?.Invoke();
    }
}

public class EventUnlockLvl : MonoBehaviour
{
    public static event Func<int, bool> LvlUnlock;
 
    public static bool OnLvlUnlock(int price)
    {
        return LvlUnlock.Invoke(price);
    }
}
