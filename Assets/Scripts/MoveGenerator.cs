﻿using System.Collections.Generic;

public class MoveGenerator {

	static int[] knightOverlay = new int[]{6, 15, 17, 10, -6, -15, -17, -10};
	static int[] kingOverlay = new int[]{8, 1, -8, -1, 7, 9, -7, -9};
	static int[] orthogonalOverlay = new int[]{8, 1, -8, -1};
	static int[] diagonalOverlay = new int[]{7, 9, -7, -9};

	/// If true, move generator will not worry about checks when generating moves (ignores pins etc)
	/// This can be used for faster move gen if king captures are going to be rejected in search
	bool psuedolegalMode;

	List<ushort> moves;

	public List<ushort> GetMoves(bool capturesOnly, bool psuedolegal) {
		psuedolegalMode = psuedolegal;
		moves = new List<ushort> (128); // I imagine that most positions will yield less than 128 psuedolegal moves. (The greatest known number of legal moves available in a position is 218)

		if (capturesOnly) {
			GenerateCaptureMoves();
		} else {
			GenerateAllMoves();
		}

		return moves;
	}

	// Gemerate all moves
	void GenerateAllMoves() {
		int colourToMove = Board.currentGamestate & 1;
		for (int i =0; i <= 63; i ++) {
			if ((Board.boardArray[i] & 1) == colourToMove) {
				int movePieceType = Board.boardArray [i] & ~1; // piece type code

				if (movePieceType == Board.kingCode) { // moving the king
					for (int overlayIndex = 0; overlayIndex < kingOverlay.Length; overlayIndex ++) {
						//if ((Board.boardArray[i] & 1) !=
					}
				}


			}
		}
	}

	// Generates all moves that are captures. TODO: this should at some point be changed to 'aggressive moves' and include moves that deliver checks.
	void GenerateCaptureMoves() {
		
	}

	/// Creates and adds move to move list. Also checks legality if not in psuedolegal mode
	void CreateMove(int fromIndex, int toIndex, int promotionPieceIndex = 0) {
		if (!psuedolegalMode) { // if not in psuedolegal mode, elimate moves that leave king in check

		}

		ushort newMove = (ushort)(fromIndex | toIndex << 6 | promotionPieceIndex << 12);
		moves.Add (newMove);
	}

	/*

	/// Returns a list of all moves in the current position
	public List<Move> AllMoves() {


		List<Move> allMoves = new List<Move> ();

		
		return allMoves;
	}

	/// Returns all quiet (i.e non-capture) moves in the position.
	/// Currently checks are considered quiet moves *if they do not capture a piece*
	public List<Move> AllQuietMoves() {
		List<Move> quietMoves = new List<Move> ();

		bool whiteToMove = Board.currentGamestate.whiteToMove;

		// Iterate through all squares on board
		for (int x = 0; x < 7; x ++) {
			for (int y = 0; y < 7; y ++) {
				int squareIndex = y*8 + x;
				int pieceTypeCode = Board.boardArray[x,y] & ~1;
				bool whitePiece = (Board.boardArray[x,y] & 1) == 1;

				// Look at all pieces of side to move
				if (Board.currentGamestate.whiteToMove == whitePiece) {
					if (pieceTypeCode == Board.kingCode) { // king moves
						for (int i = 0; i < kingOverlay.Length; i ++) {
							Move newMove;
							if (TryCreateMove(out newMove, squareIndex, squareIndex + kingOverlay[i], true)) {
								quietMoves.Add(newMove);
							}
						}
						if (Board.currentGamestate.CanCastleKingside(whitePiece)) { // kingside castling

						}
						if (Board.currentGamestate.CanCastleQueenside(whitePiece)) { // queenside castling
							
						}
					}
					else if (pieceTypeCode == Board.knightCode) { // knight moves
						
					}
					else if (pieceTypeCode == Board.pawnCode) { // pawns moves
						
					}
					else { // queen rook and bishop moves

					}
				}

			}
		}

		
		return quietMoves;
	}

	/// Returns all moves that capture a piece
	public List<Move> AllCaptures() {
		List<Move> captureMoves = new List<Move> ();
		
		
		return captureMoves;
	}

	bool IndexOnBoard(int squareIndex) {
		return squareIndex >= 0 && squareIndex <= 63;
	}

	bool TryCreateMove(out Move move, int fromIndex, int toIndex, bool isKing = false) {
		move = new Move (fromIndex, toIndex);

		// If given indices are out of bounds, reject move
		if (!IndexOnBoard(fromIndex) || !IndexOnBoard(toIndex)) {
			return false;
		}

		// If move gen is not in psuedolegal mode, ensure move is fully legal (i.e look for pins, check blocks)
		if (!generatePsuedolegalMoves) {
			if (!isKing) {

			}
		}

		return true;
	}
	*/
}