OldPhonePad
This is a console-based C# application that simulates typing on an old mobile phone keypad, where each key corresponds to multiple letters. The user can input digits (0-9) to type characters, with each digit corresponding to a set of characters, and the number of times a digit is pressed determines which character is selected. The program displays the final output when # is pressed and resets after each input sequence.

Description
The program is like the old mobile phone's multi-press system, where a user can press a digit multiple times to select a character from the corresponding set. For example:

Press 2 once to type "A".
Press 2 twice to type "B".
Press 2 three times to type "C".
The program processes input based on the number of key presses and a timeout mechanism (1 second) to determine when the user has finished pressing a key. Pressing # will display the final output, and pressing Escape will exit the program.

Features
This will let you type like an old phone keypad.
Handles multi-press input for characters.
Resets after each sequence when # is pressed.
Exits the program when the Escape key is pressed.

Installation: 
1. Clone the repository: git clone https://github.com/KuysCoding/OldPhonePad.git
2. Navigate to the directory
3. Open the project in your preferred IDE (e.g., Visual Studio) or use the .NET CLI.
4. Build and run the application.

Usage
Typing
Press the number keys (0-9) to input characters.
1: Space, &, ,, (
2: "ABC"
3: "DEF"
4: "GHI"
5: "JKL"
6: "MNO"
7: "PQRS"
8: "TUV"
9: "WXYZ"
Press # to display the typed output.
Press Escape to exit the program.

Example Input and Output:
Press 2, then 2, then # → Output: B
Press 7, then 7, then 7, then # → Output: S
Press 4, 5, 6, then # → Output: J (for "4"), K (for "5"), M (for "6")

Timeout Mechanism
After 1 second of inactivity, the program will automatically finalize the current keypress and prepare for the next input sequence.
