public class Elf : Enemy
{
    private int _agility;
    private int _magicPower;

    public void Initialize(ElfSettings settings)
    {
        _agility = settings.Agility;
        _magicPower = settings.MagicPower;
    }

    public override string GetInfo() => $"Agility: {_agility}, MagicPower: {_magicPower}.";
}
