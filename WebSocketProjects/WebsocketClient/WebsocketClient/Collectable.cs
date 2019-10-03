namespace WebsocketClient
{
    public abstract class Collectable
    {
        public enum Type
        {
            Bomb,
            SpeedBoost
        }

        public int durationMilliseconds; // duration in milliseconds of the collectable item effect
        public double strength; // strength could be bigger for better performing players, decrease over time, etc.

        // make collectable effective
        public abstract void ApplyEffect();

        // make collectable ineffective
        public abstract void RemoveEffect();
    }
}