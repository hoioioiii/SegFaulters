public class LefttMovingPlayerState : IPlayerState
{
    private Player player;
    //placeholder till connected with global health system
    private int health;

    public LefttMovingPlayerState(Player player, int initialHealth)
    {
        this.player = player;
        this.health = initialHealth;
        //construct sprite here too?? (texture?)
    }

    public void ChangeDirection()
    {
        //grab keyboard inputs and switch case execute XMovingPlayerState based on command
        //ex: if Key[0].IsPressed, execute RightMovingPlayerState.ChangeDirection(player, Key[0])

        //left is just a placeholder till switch cases 
        //	player.State = new LeftMovingPlayerState(player);
    }

    public void DeathState()
    {
        player.State = new DeadPlayerState(player);
    }


    public void TakeDamage(int damageAmount)
    {

        //immunity for x amount of time
        //decrease global health by x amount
        //check if DeadPlayerState is needed

        health -= damageAmount;

        if (health <= 0)
        {
            player.State = new DeadPlayerState(player);

        }

    }
    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void UseWeapon()
    {
        //different sprite drawn
        //switch case depending on which direction facing
        //is a timed state, how to handle?
    }

    public void VictoryState()
    {
        player.State = new VictoryPlayerState(player);
    }
}