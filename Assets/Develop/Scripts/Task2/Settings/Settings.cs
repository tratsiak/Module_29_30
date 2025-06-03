using System;
using UnityEngine;

[Serializable]
public class EnemySettings
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
}

[Serializable]
public class OrkSettings : EnemySettings
{
    [field: SerializeField] public int RageLevel { get; private set; }
}

[Serializable]
public class ElfSettings : EnemySettings
{
    [field: SerializeField] public int Agility { get; private set; }
    [field: SerializeField] public int MagicPower { get; private set; }
}

[Serializable]
public class DragonSettings : EnemySettings
{
    [field: SerializeField] public int FireBreathDamage { get; private set; }
    [field: SerializeField] public int FlightSpeed { get; private set; }
}
