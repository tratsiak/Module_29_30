public class Ork : Enemy
{
    private int _rageLevel;

    public void Initialize(OrkSettings settings)
    {
        _rageLevel = settings.RageLevel;
    }

    public override string GetInfo() => $"RageLevel: {_rageLevel}.";
}
