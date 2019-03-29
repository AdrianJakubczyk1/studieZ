import java.util.*;

public class PortalGame{
private GameSupport supp = new GameSupport();
private ArrayList<ProstyPortal>portalList = new ArrayList<ProstyPortal>();

private int playerMoves = 0;

private void prepareTheGame()
{//creating portals and setting their names
	ProstyPortal first = new ProstyPortal();
	first.setName("first");
	ProstyPortal second = new ProstyPortal();
	second.setName("second");
	ProstyPortal third = new ProstyPortal();
	third.setName("third");
//adding portals on List
	portalList.add(first);
	portalList.add(second);
	portalList.add(third);

	System.out.println("to win you need to destroy three enemy objects ");
	System.out.println("first, second, third");
	System.out.println("try to do it as quickest as you can! ");


	for(ProstyPortal placedPortal : portalList)
	{//setting placement of portals
		ArrayList<String>newPlacement = supp.setThePortals(3);
		placedPortal.SetPolozenia(newPlacement);
	}
}//end of method

private void startTheGame()
{

	while(!portalList.isEmpty())//while not empty
	{
		String playersMove = supp.Pola("write pool that you want to shoot here:");//player trying to guess where the portal is.
		checkPlayersMove(playersMove);
	}
	endTheGame();//if there is no portals left end the game
}

private void checkPlayersMove(String move)
{
	playerMoves++;
	String result = "Missed! ";

	for(ProstyPortal portalToBeChecked : portalList)//checking if player got hit on any of portals
	{
		result = portalToBeChecked.sprawdz(move);
		if(result.equals("trafiony"))
		{
			break;//if hit then end loop
		}
		if(result.equals("zatopiony"))
		{
			portalList.remove(portalToBeChecked);
			break;
		}
	}
	System.out.println(result);
}
private void endTheGame()
{
	System.out.println("all portals has been destroyed!");
	if(playerMoves<18)//if player made it below 18 moves, player wins!
	{
		System.out.println("you've made only: "+playerMoves+" of moves goodjob!");
	}else//if not then its lost
	{
		System.out.println("you've made: "+playerMoves+" of moves you've lost :(");

	}
}

public static void main(String[]args)
{
	PortalGame game = new PortalGame();
	game.prepareTheGame();
	game.startTheGame();
}
}