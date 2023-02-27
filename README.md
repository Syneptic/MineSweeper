# MINESWEEPER
#### Video Demo:  <URL HERE>
#### Description: 
This is a C# implementation of Minesweeper which has been written using Visual Studio for Mac.

Minesweeper is a puzzle video game. The game consists of a two dimensional grid having cells that can either be empty or contain a mine. There are three things that can happen when a player checks a cell. If the cell contains a mine then the game is over. If the checked cell does not contain a mine but one or multiple of its adjacent cells contain mines then the number of adjacent mines will be display within the checked cell. Lastly, if the cell does not contain a mine and none of its adjacent cells contain mines either then all the neighbouring cells of the adjacent cells themselves get checked in a recursively. This happens until each recursively checked cell's adjacent cells contain at least one mine. This speeds up redundant moves within the gameplay. The recursive function will check all the empty adjacent cells instead of having the user click them. The player wins if they manage to check all the empty cells without stepping on a mine.

Windows Forms and similar C# graphical class libraries cannot be utilised on Visual Studio for Mac and thus the game has been implemented as a console application. The console will prompt the player for the X and Y coordinates to select a cell to check.

During the initialization of the game the console will prompt the player to choose the board's number of rows and columns.
A number up between 5 and 30 can be chosen. The console will keep prompting the user for a number if the input is not an integer or if the number is out of bounds for the specified range.
Once successfully entered, the board is created based on the 'xCell' and 'yCell' integers.
Having a 16.7% (or 1/6) chance, the 'assignMines()' function uses a 'Random' instance to randomly assign mines to cells. A cell is a mine if it gets set to the number '7'. If a cell is empty it gets assigned the number '8'. The array will then be printed to the console showing only 'X's for all the cells.
In addition a second grid is created. The 'bool[,] visited' array verifies if cells have already checked during a recursive check function.

Having received all the information, the game can now start. The application enters the 'while (!gameOver && !win)' loop which controls when the game will stop. As long as the bool variables 'gameOver' and 'win' are set to false the while loop will keep on running.
Once again the user gets prompted to enter two numbers within the specified range. The first prompt asks for the X coordinate within the two dimensional array and the second one asks for the Y coordinate. The application will run a while loop if invalid input has been entered until the player enters valid integers.

Once completed, the two entered integers get subtracted by -1 each. Since the grid starts at 0 the entered input has to be modified. The player should be able to treat the first row as being 'row 1'. So when the player enters '1' the 'zero'' row should be selected instead of the second row.

Now the input runs through multiple checks.
The first one verifies that the chosen numbers are within the specified range. Otherwise it will throw an error message and restart the while loop, thus prompting the player again to choose a cell.
After successful completion, the selected cell gets checked for mines. If a mine is present, the 'gameOver' bool gets set to true and the while loop breaks.
The next if statement verifies whether the selected cell has already been unveiled or not. If so, the while loop restarts and the player can enter a new X,Y coordinate.
Once all the if-statements have been passed and the cell does not contain a mine the 'checkInput' function is called.

The 'checkInput' function takes the grid and the entered X,Y coordinates as input and runs a nested for loop. This checks all adjacent cells for mines. If a mine is found then the 'int counter' variable is incremented by one. If no adjacent mines are found then the selected cell will be assigned the number '0' which means that it is empty and that it now has been unveiled. Otherwise the recorded number of adjacent mines which has been stored in the 'counter' variable gets assigned to the selected cell.
The 'checkInbound' function within the 'checkInput' function verifies the given input. In case of the adjacent cells being out of bounds for the given array the loop would simply jump the the next step in the for loop. This could happen if the player enters '1,1' as coordinates and the function checking all surrounding 8 cells would access '-1,-1' as an example. Without the 'checkInbound' function the application would throw an outOfBoundsException and the game would crash.

The application proceeds to the next line to see whether or not the specified cell has been assigned the number '0'. Assuming the cell has been set to '0' the 'recursiveCheck' function would be called. The 'recursiveCheck' recursively looks for mines within the adjacent cells. If cells don't have adjacent cells they get assigned the number '0' and loop proceeds to check each adjacent cell once again recursively, calling the 'recursiveCheck' for each adjacent cell independetly. This happens until all the checked cells either have the number of ajdacent mines assigned to them or they are set to '0' as well as set to 'visited'.
The functions returns immediately if the cell in question is either out of bounds or it has already been visited, thus preventing an infinite loop of recursive checking. Eventually, the updated array gets returned and assigned to the grid which has been passed in as input.

Following the previous step, the 'win' function gets called. It checks if there are any '8' cells left. In other words cells which have not yet been unveiled. If only non-'8' cells are left it means the player has checked all non-mine cells without stepping on a mine and has won the game.

If the 'win' function returns false and the player has not yet cleared all fields then the print function will print the updated array to the console. The player can the proceed to type in his next X,Y coordinate for the cell to check. This goes on until the player either steps on a mine and loses or the player has cleared all fields and thus wins the game.

There is also a 'testPrint()' function which has been used during development to see where the mines get placed. It prints an additional array to the console which displays all cells' assigned numbers. It can be used to see what happens if you enter a specific X,Y coordinate that is deliberately a mine, an empty cell or a cell with a given number of adjacent cells which contain mines and then see how the application responds. It has been commented out within the code but can be activated for trying out ideas and testing the code.

Overall, the most challenging part was the recursive function. Through multiple hours and some headaches the solution finally came up. Once the idea of a bool [,] appeared the implementation was relatively easy. Before I had only tried to implement the recursion without the help of another two dimensional 'visited' array.
I could have split up the whole design in multiple different classes and thus clean up the design. However, I felt that this project is not that big that multiple .cs files would be necessary. The difficult part in this project was the whole logic and architecture. The creation of this Minesweeper Console Application has been very rewarding and insightful. The lessons learned are important for the knowledge foundation and will be still relevant in many future projects and tasks.