namespace Woguelite.Enums
{
    public enum HurtboxType
    {
        Player = 1 << 0,
        Enemy = 1 << 1
    }

    public enum HurtboxMask
    {
        None    = 0,       //0000b
        Player  = 1 << 0,  //0001b
        Enemy   = 1 << 1   //0010b
    }
}