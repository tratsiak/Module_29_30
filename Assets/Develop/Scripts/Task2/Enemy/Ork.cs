public class Ork : Enemy
{
    private int _rageLevel;

    public override void Initialize(EnemySettings settings)
    {
        base.Initialize(settings);

        if (settings is OrkSettings orkSettings)
            _rageLevel = orkSettings.RageLevel;
    }

    public override string GetInfo()
    {
        string baseInfo = base.GetInfo();

        return $"{baseInfo}, RageLevel: {_rageLevel}.";
    }
}
