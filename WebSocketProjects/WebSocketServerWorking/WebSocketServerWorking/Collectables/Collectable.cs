using System.Threading;

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
        public double effectStrength { get; protected set; } // effectStrength could be bigger for better performing players, decrease over time, etc.
        protected string spriteName; // name of the sprite resource used to represent collectable on the map

        // draw animation 
        public abstract void Animate();

        // make collectable effective
        public abstract void ApplyEffect();

        // make collectable ineffective
        public abstract void RemoveEffect();

        // start new thread for each pickup to not block main thread while waiting
        public void PickUp()
        {
            new Thread(PickUpAndWaitAsync).Start();
        }

        // use picked up collectable item
        private void PickUpAndWaitAsync()
        {
            ApplyEffect();
            Animate();
            Thread.Sleep(duration);
            RemoveEffect();
        }
    }
}