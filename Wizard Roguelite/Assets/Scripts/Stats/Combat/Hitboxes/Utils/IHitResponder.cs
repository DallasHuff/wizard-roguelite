namespace Woguelite.Stats
{
    public interface IHitResponder
    {
        int Damage { get; }
        public bool CheckHit(HitData data);
        public void Response(HitData data);
    }
}