namespace Woguelite.Stats
{
    public interface IHitResponder
    {
        int damage { get; }
        public bool CheckHit(HitData data);
        public void Response(HitData data);
    }
}