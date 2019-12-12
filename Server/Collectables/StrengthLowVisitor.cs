namespace WebSocketServerWorking.Collectables
{
    public class StrengthLowVisitor : Visitor
    {
        private const double Modifier = 0.7;

        public double visit(Bomb bomb)
        {
            return bomb.effectStrength * Modifier;
        }

        public double visit(SpeedBoost speedBoost)
        {
            return speedBoost.effectStrength * Modifier;
        }
    }
}