/*
 * Assignment: Rock Paper Scissors Lizard Spock Game
 * 
 * Objective:
 * Implement a fully functional Rock Paper Scissors Lizard Spock game using Unity and C#. The player selects a choice via UI buttons, 
 * the computer randomly selects its choice, and the game determines the winner based on the game rules.
 * 
 * Requirements:
 * 1. The player can choose from five options: Rock, Paper, Scissors, Lizard, or Spock by pressing designated buttons in the scene.
 * 2. The computer randomly selects one of the five choices each turn.
 * 3. Game logic determines the winner based on the following rules:
 *    - Rock beats Scissors and Lizard
 *    - Scissors beats Paper and Lizard
 *    - Paper beats Rock and Spock
 *    - Lizard beats Paper and Spock
 *    - Spock beats Scissors and Rock
 * 4. Ties occur when both the player and computer choose the same option.
 * 5. All game results (player choice, computer choice, and outcome) should be output using Debug.Log.
 * 6. Use an enum to represent the five choices instead of strings.
 * 7. Update the OnClick() method in the editor to use enums instead of strings. 
 *      NOTE: OnClick cannot directly take enums, so what would you use instead to pass in?
 *      
 * 
 * Instructions:
 * - Attach the script to any active GameObject in your Unity scene.
 * - Change the OnClick method on the UI buttons in the scene to use enums instead of strings.
 * - Observe the game results in the Console after each button press.
 * 
 * Hint:
 * - Start by just fixing up the strings and doing Rock Paper Scissors. 
 * - Once you have that working, add in the Lizard and Spock options and update the game logic accordingly.
 * - OnClick can't take enums, but what does a compiler read enums as? Remember, casting can change one type to another. 
 *
 */

using UnityEngine;

public class RockPaperScissorsGame : MonoBehaviour
{
    public enum Choice
    {
        invalid = 0,
        rock = 1,
        paper = 2,
        scissors = 3,
        lizard = 4,
        spock = 5
    }

    public void Play(int playerChoiceInt)
    {
        Play((Choice)playerChoiceInt);
    }

    public void Play(Choice playerChoice)
    {
        if (playerChoice == Choice.invalid)
        {
            Debug.LogWarning("Invalid Choice.");
            return;
        }

        Debug.Log("You Chose: " + playerChoice);

        Choice computerChoice = (Choice)Random.Range(1, 6);
        Debug.Log("Computer chose: " + computerChoice);

        Debug.Log(DetermineOutcome(playerChoice, computerChoice));
    }
    private string DetermineOutcome(Choice player, Choice computer)
    {
        if (player == computer)
            return "It is a tie. Both chose " + player;

        switch (player)
        {
            case Choice.rock:
                if (computer == Choice.scissors || computer == Choice.lizard)
                    return "Congrats nerd! Rock beats " + computer;
                break;
            case Choice.paper:
                if (computer == Choice.rock || computer == Choice.spock)
                    return "Congrats nerd! Rock beats " + computer;
                break;
            case Choice.scissors:
                if (computer == Choice.paper || computer == Choice.lizard)
                    return "Congrats nerd! Rock beats " + computer;
                break;
            case Choice.spock:
                if (computer == Choice.scissors || computer == Choice.rock)
                    return "Congrats nerd! Rock beats " + computer;
                break;
            case Choice.lizard:
                if (computer == Choice.scissors || computer == Choice.spock)
                    return "Congrats nerd! Rock beats " + computer;
                break;
        }
        return "You lost bozo! " + computer + " beats " + player;
    }
}
