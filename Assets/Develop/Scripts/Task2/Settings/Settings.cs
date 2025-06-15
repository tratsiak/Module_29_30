using System;
using UnityEngine;

[Serializable]
public class OrkSettings : ISettings
{
    [field: SerializeField] public int RageLevel { get; private set; }
}

[Serializable]
public class ElfSettings : ISettings
{
    [field: SerializeField] public int Agility { get; private set; }
    [field: SerializeField] public int MagicPower { get; private set; }
}

[Serializable]
public class DragonSettings : ISettings
{
    [field: SerializeField] public int FireBreathDamage { get; private set; }
    [field: SerializeField] public int FlightSpeed { get; private set; }
}
