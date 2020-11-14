package com.company;
import com.sun.deploy.security.SelectableSecurityManager;
import sac.graph.AStar;
import sac.graph.GraphSearchAlgorithm;
import sac.graph.GraphState;
import sac.graph.GraphStateImpl;
import java.util.LinkedList;
import java.util.List;
import java.util.Random;
public class Puzzle extends GraphStateImpl {


    public static final int n = 3;
    public static final double amountOfObjects=100;


    private byte[][] board;

    byte[][] getBoard(){
        return this.board;
    }

    int getN()
    {
        return n;
    }

    @Override
    public List<GraphState> generateChildren() {
        LinkedList<GraphState> children = new LinkedList<GraphState>();
        kierunek[] kierunek = Puzzle.kierunek.values();
                for(int k =0;k<4;k++){
                    Puzzle child = new Puzzle(this);
                    if(child.move(kierunek[k]))
                     {
                         child.setMoveName(kierunek[k].toString());
                         children.add(child);
                        }
            }
                return children;
    }

    @Override
    public boolean isSolution() {

        byte counter = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++){
                if (Byte.compare(counter , board[i][j]) !=0) {
                    return false;
                }
                counter++;
            }
        return true;
    }
    enum kierunek{
        left,
        right,
        down,
        up,
    }

    private int zeros = n*n;

    public Puzzle(Puzzle toCopy)
    {
        board = new byte[n][n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                board[i][j] = toCopy.board[i][j];
    }



    public Puzzle() {
        byte k = 0;
        board = new byte[n][n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                board[i][j] = k++;
    }

    @Override
    public int hashCode()
    {
        return toString().hashCode();
    }

    @Override
    public String toString()
    {
        String txt = "";
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) {
                txt += board[i][j] + " | ";
                if (j == n - 1)
                    txt += "\n";
            }
        return txt;
    }
    public boolean move(kierunek direction)
    {
        int[] zeroPos = locateZero();
        int row=zeroPos[0];
        int column = zeroPos[1];

        byte temp;

                    if(direction.equals(kierunek.right)) {
                        if(column == n-1)
                            return false;
                        else{
                            temp = board[row][column+1];
                            board[row][column+1] = 0;
                            board[row][column] = temp;

                        }
                }
                    else if(direction.equals(kierunek.left))
                    {
                        if(column==0)
                            return false;
                        else{
                            temp = board[row][column-1];
                            board[row][column-1] = 0;
                            board[row][column] = temp;
                        }
                    }else if(direction.equals(kierunek.up))
                    {
                        if(row==n-1)
                            return false;
                        else{
                            temp = board[row+1][column];
                            board[row+1][column] = 0;
                            board[row][column] = temp;
                        }
                }else if(direction.equals(kierunek.down))
                    {
                        if(row==0)
                            return false;
                        else{
                            temp = board[row-1][column];
                            board[row-1][column] = 0;
                            board[row][column] = temp;
                        }
                    }
            return true;
    }

    public void mixing(int moves)
    {
        Random r = new Random();
        for(int i = 0;i<moves;i++) {
            int move = r.nextInt() % 4;
            boolean result = true;
            if (move == 0)
                result = move(kierunek.right);
            else if (move == 1)
                result = move(kierunek.left);
            else if (move == 2)
                result = move(kierunek.up);
            else if (move == 3)
                result = move(kierunek.down);
            if (!result)
                i--;
        }
    }

    public int[] locateZero()
    {
        int[] result = new int[2];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) {
                if(board[i][j] == 0)
                {
                    result[0]=i;
                    result[1] = j;
                    break;
                }
            }
        return result;
    }


    public static void main(String[] args) {
	// write your code here
        double GTiles = 0;
        double GManhattan = 0;
        double timeManhattan=0;
        double timeTiles=0;
        double closedManhattan=0;
        double closedTiles=0;
        double openManhattan=0;
        double openTiles=0;
        Puzzle[] arr = new Puzzle[100];
        for(int i =0;i<amountOfObjects;i++) {
            Puzzle p = new Puzzle();
            p.mixing(1000);
            arr[i]=p;
        }
        for(int i =0;i<1;i++) {
            Puzzle.setHFunction(new Manhattan());
            GraphSearchAlgorithm algo = new AStar(arr[i]);
            algo.execute();
            List<GraphState> solutions = algo.getSolutions();
            for(GraphState sol:solutions)
            {
                GManhattan+=sol.getG();
                System.out.println(sol.getMovesAlongPath());

            }

            timeManhattan+= algo.getDurationTime();
            closedManhattan+=algo.getClosedStatesCount();
            openManhattan+=algo.getOpenSet().size();

        }

        for(int i =0;i<1;i++) {
            Puzzle.setHFunction(new MisplacedTiles());
            GraphSearchAlgorithm algo = new AStar(arr[i]);

            algo.execute();
            List<GraphState> solutions = algo.getSolutions();
            for(GraphState sol:solutions)
            {
                GTiles+=sol.getG();
                System.out.println(sol.getMovesAlongPath());
            }
            timeTiles+= algo.getDurationTime();
            closedTiles+=algo.getClosedStatesCount();
            openTiles+=algo.getOpenSet().size();
        }
        System.out.println("------Manhattan----------");
        System.out.println("get G: "+GManhattan/amountOfObjects);
        System.out.println("time Manhattan: "+timeManhattan/amountOfObjects);
        System.out.println("closed Manhattan: " + closedManhattan/amountOfObjects);
        System.out.println("opened Manhattan: " + openManhattan/amountOfObjects);
        System.out.println("\n\n------MisplacedTiles----------");
        System.out.println("get G: "+GTiles/amountOfObjects);
        System.out.println("time MisplacedTiles: "+timeTiles/amountOfObjects);
        System.out.println("closed MisplacedTiles:" + closedTiles/amountOfObjects);
        System.out.println("opened MisplacedTiles:" + openTiles/amountOfObjects);

    }
}
