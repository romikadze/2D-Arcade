namespace Source.Scripts
{
    public interface IHitable
    {
        public void Hit(float damage);

        public void Die();
    }
}