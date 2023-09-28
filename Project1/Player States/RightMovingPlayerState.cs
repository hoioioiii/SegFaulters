using Project1;

public class RightMovingPlayerState : IPlayerState
{
    private PlayerState playerState;
    //placeholder till connected with global health system
    private int health;
    private Player player;

    public RightMovingPlayerState(Player player, int initialHealth)
    {
        int xPos = player.positionX;
        int yPos = player.positionY;
        this.health = initialHealth;
        this.player = player;
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
        playerState.State = new DeadPlayerState(playerState);
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