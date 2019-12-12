namespace WebSocketServerWorking.Collectables
{
    public class DurationLongVisitor : Visitor
    {
        private const double Modifier = 5;

        public double visit(Bomb bomb)
        {
            return bomb.duration * Modifier;
        }

        public double visit(SpeedBoost speedBoost)
        {
            return speedBoost.duration * Modifier;
        }
    }
}