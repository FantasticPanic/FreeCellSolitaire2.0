# FreeCellSolitaire2.0
![](https://github.com/FantasticPanic/FreeCellSolitaire2.0/blob/main/Assets/Images/freeCell_title.jpg)
This WebGL game was made with Unity. This is an exercise intended to recreate FreeCell Solitaire. I'm generally happy with the way it turned out, but
there could definitely be some improvements.

You can play my version here: https://nicholasramsay.itch.io/freecell-solitaire

You can play the original here: https://solitaired.com/freecell

Working Features:
- General Rules and Logic: The players can stack cards on each other, FreeCell or Foundation slots
- Cards will return back to original position if they are dragged an not placed in a stackable section of the play area.
- Undo Button: This feature uses a Command Pattern that revolves around the CardMoveUndo, UserInput, Move and ICommand scripts
- A timer that can track the finish time of the player
- Player can restart the tableau by pressing R
- Player can auto-win by pressing W. This will generate their finish time and display a random caption


Future Improvements:
- Card collision could be improved. Hitting another card collider mid-drag can sometimes cause two cards to stack on each other unintentionally
- Undo Button: The Undo button will sometimes undo actions in the wrong order.
- Better player feedback and sfx: there is no sfx when the player successfully stacks a card on top of another one. 
