public interface IPlayerState
{
	void ChangeDirection();
	void TakeDamage(int damageAmount);
	void UseWeapon();
	void Update();
	void VictoryState();
	void DeathState();

}

public class Player
{
	public IPlayerState State;
    private int initialHealth { get; set; }
    private Player player { get; set; }

    public Player(int initialHealth)
	{
        this.initialHealth = initialHealth;
        this.player = this; // initialize the player property
        State = new RightMovingPlayerState(this, initialHealth);
	}

	public void ChangeDirection()
	{
		State.ChangeDirection();
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