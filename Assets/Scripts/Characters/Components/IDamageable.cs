namespace Characters
{
    public interface IDamageable
    {
        public void TakeDamage(float amount);
        public bool IsAlive();
    }
}