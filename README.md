# FreeCellSolitaire2.0

This project is a continuation of FreeCell_Soliatire_Exercise. 

Working Features:
- General Rules and Logic: The players can stack cards on each other, FreeCell or Foundation slots
- Cards will return back to original position if they are dragged an not placed in a stackable section of the play area.
- Undo Button: This feature uses a Command Pattern that revolves around the CardMoveUndo, UserInput, Move and ICommand scripts
- Player can restart the tableau by pressing R

Future Improvements:
- Card collision could be improved. Hitting another card collider mid-drag can sometimes cause two cards to stack on each other unintentionally
- Better player feedback and sfx: there is no sfx when the player successfully stacks a card on top of another one/ 
