using System.Collections.Specialized;

public class VictoryPlayerState : IPlayerState
{
    private Player player;
    //placeholder till connected with global health system
    public VictoryPlayerState(Player player)
    {
        this.player = player;
        //construct sprite here too?? (texture?)
    }
    public void ChangeDirection()
    {
        // no-op
    }

    public void DeathState()
    {
        // no-op
    }

    public void TakeDamage(int damageAmount)
    {
        // no-op
    }

    public void Update()
    {
        //not sure how to approach this
    }

    public void UseWeapon()
    {
        // no-op
    }

    public void VictoryState()
    {
       //show end game screen or something similar 
       //not sure how to implement yet
    }
}