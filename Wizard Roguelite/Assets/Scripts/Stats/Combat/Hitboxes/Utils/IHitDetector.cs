namespace Woguelite.Stats
{
    public interface IHitDetector
    {
        public IHitResponder HitResponder { get; set; }
        public void CheckHit();
    }
}