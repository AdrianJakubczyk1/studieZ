package com.company;
import sac.State;
import sac.StateFunction;

public class Manhattan extends StateFunction {
    public double calculate(State state) {
        Puzzle p = (Puzzle) state;
        byte[][] board;
        board = p.getBoard();
        double result = 0;
        for (int i = 0; i < p.getN(); i++)
            for (int j = 0; j < p.getN(); j++) {
                if (board[i][j] != 0) {

                    int targetI = board[i][j] / p.getN();
                    int targetJ = board[i][j] % p.getN();
                    result += Math.abs(i - targetI) + Math.abs(j - targetJ);
                }
            }
        return result;
    }
}
