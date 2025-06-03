public class Dragon : Enemy
{
    private int _fireBreathDamage;
    private int _flightSpeed;

    public override void Initialize(EnemySettings settings)
    {
        base.Initialize(settings);

        if (settings is DragonSettings dragonSettings)
        {
            _fireBreathDamage = dragonSettings.FireBreathDamage;
            _flightSpeed = dragonSettings.FlightSpeed;
        }
    }

    public override string GetInfo()
    {
        string baseInfo = base.GetInfo();

        return $"{baseInfo}, FireBreathDamage: {_fireBreathDamage}, FlightSpeed: {_flightSpeed}.";
    }
}
