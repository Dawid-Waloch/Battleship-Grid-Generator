# Battleship Grid Generator (C# Console App)
This is a simple console-based C# program that simulates automatic placement of ships on a Battleship game board. It generates a 10x10 grid and places ships of varying lengths (from 4-mast to 1-mast) while ensuring valid positions and surrounding restrictions according to classic Battleship rules.
## Features
- Randomized ship placement on a 10x10 game board
- Ship types:
  - 1 × 4-mast ship
  - 2 × 3-mast ships
  - 3 × 2-mast ships
  - 4 × 1-mast ships
- Collision and boundary prevention
- Surrounding water (buffer) zones added to prevent adjacent ships
- Console output of the final board state:
  - `1` = ship
  - `2` = surrounding buffer (cannot place other ships here)
  - `0` = empty cell (visible as 0 in output)
 ## How It Works
- The board is initialized as a 12x12 array to simplify boundary checks.
- The program attempts to place ships of decreasing size in valid directions (up, down, left, right).
- Each ship is surrounded by 2s to mark restricted zones (no adjacent ships allowed).
- Final output prints the 10x10 visible game board with the ship layout.
## Example Output
```python-repl
0 0 0 0 0 0 0 0 0 0 
0 0 0 1 1 1 0 1 0 0 
0 0 0 0 0 0 0 0 0 0 
0 0 0 0 0 0 0 1 0 0 
0 0 1 0 1 1 0 1 0 1 
0 0 0 0 0 0 0 1 0 0 
0 0 1 0 0 0 0 1 0 0 
0 0 0 1 1 1 0 0 0 0 
0 0 1 0 0 0 0 0 0 0 
0 0 1 0 0 0 0 0 1 1 
```
