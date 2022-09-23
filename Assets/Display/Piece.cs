public class Piece {
    pubic Piece(SquareColor color,  bool[,] spawn_coord) {
        String COLOR = color;
        bool[,] SPAWN_COORD = spawn_coord;
    }
    
    Piece LIGHT_BLUE_PIECE = new Piece(SquareColor.LIGHT_BLUE, {{true, true, true, true}});
    Piece DEEP_BLUE_PIECE = new Piece(SquareColor.DEEP_BLUE, {{true, false, false}, {true, true, true}});
    Piece ORANGE_PIECE = new Piece(SquareColor.ORANGE, {{false, false, true}, {true, true, true}});
    Piece YELLOW_PIECE = new Piece(SquareColor.YELLOW, {{true, true}, {true, true}});
    Piece GREEN_PIECE = new Piece(SquareColor.GREEN, {{false, true, true}, {true, true, false}});
    Piece PURPLE_PIECE = new Piece(SquareColor.PURPLE, {{false, true, false}, {true, true, true}});
    Piece RED_PIECE = new Piece(SquareColor.PURPLE, {{true, true, false}, {false, true, true}});

}