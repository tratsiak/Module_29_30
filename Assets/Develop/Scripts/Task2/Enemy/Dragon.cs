public class Dragon : Enemy
{
    private int _fireBreathDamage;
    private int _flightSpeed;

    public void Initialize(DragonSettings settings)
    {
        _fireBreathDamage = settings.FireBreathDamage;
        _flightSpeed = settings.FlightSpeed;
    }

    public override string GetInfo() => $"FireBreathDamage: {_fireBreathDamage}, FlightSpeed: {_flightSpeed}.";
}
