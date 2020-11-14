package com.company;
import sac.State;
import sac.StateFunction;
public class MisplacedTiles extends StateFunction{
    public double calculate(State state){
        Puzzle p =(Puzzle) state;
        byte[][] board;
        board=p.getBoard();
        byte counter=0;
        double result=0;
        for(int i =0;i<p.getN();i++)
            for(int j =0;j<p.getN();j++)
            {
                if ((board[i][j] != counter) &&  (board[i][j] != 0)) {
                    result++;
                }
                counter++;
            }

return result;

    }

}
