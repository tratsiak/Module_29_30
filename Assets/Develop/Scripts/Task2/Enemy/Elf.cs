public class Elf : Enemy
{
    private int _agility;
    private int _magicPower;

    public override void Initialize(EnemySettings settings)
    {
        base.Initialize(settings);

        if (settings is ElfSettings elfSettings)
        {
            _agility = elfSettings.Agility;
            _magicPower = elfSettings.MagicPower;
        }
    }

    public override string GetInfo()
    {
        string baseInfo = base.GetInfo();

        return $"{baseInfo}, Agility: {_agility}, MagicPower: {_magicPower}.";
    }
}
