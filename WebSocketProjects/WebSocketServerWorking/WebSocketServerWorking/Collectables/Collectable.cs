using System.Timers;

namespace WebSocketServerWorking.Collectables
{
    public abstract class Collectable
    {
        public enum Type // types of collectables that are allowed
        {
            Bomb,
            SpeedBoost
        }

        public int duration { get; protected set; } // duration in milliseconds of the collectable item effect

        public double
            effectStrength
        {
            get;
            protected set;
        } // effectStrength could be bigger for better performing players, decrease over time, etc.

        protected string spriteName; // name of the sprite resource used to represent collectable on the map

        // draw animation 
        public abstract void Animate();

        // make collectable effective
        public abstract void ApplyEffect();

        // make collectable ineffective
        public abstract void RemoveEffect();

        // use picked up collectable item, stop using it after timer expires
        public void PickUp()
        {
            using (var timer = new Timer {Interval = duration, AutoReset = false})
            {
                timer.Elapsed += EffectExpired;

                ApplyEffect();
                timer.Start();
                Animate();
            }
        }

        // effect expired, remove it's physics, visual effects, etc.
        public void EffectExpired(object sender, ElapsedEventArgs e)
        {
            RemoveEffect();
        }
    }
}