using Microsoft.VisualBasic;
using Project1;
public class PlayerState
{

    public IPlayerState State;
    private int initialHealth { get; set; }



    public PlayerState(Player player, int initialHealth)
    {
        this.initialHealth = initialHealth;
        State = new LeftMovingPlayerState(player, initialHealth);
    }

    public void ChangeDirection(PlayerDirection direction)
    {
        State.ChangeDirection(direction);
    }

    public void TakeDamage(int damageAmount)
    {

        State.TakeDamage(damageAmount);
    }

    public void UseWeapon()
    {
        State.UseWeapon();
    }

    public void Update()
    {
        State.Update();
    }
}
public enum PlayerDirection
{
    Left,
    Right,
    Up,
    Down
}