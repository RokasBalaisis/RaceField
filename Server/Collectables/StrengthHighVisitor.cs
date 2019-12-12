namespace WebSocketServerWorking.Collectables
{
    public class StrengthHighVisitor : Visitor
    {
        private const double Modifier = 2;

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