using System;

namespace dots.and.boxes {
  [Flags]
  internal enum CellState : byte {
    Empty = 0,
    Top = 1,
    Left = 2,
    Bottom = 4,
    Right = 8,
    All = Top | Left | Bottom | Right,
    OwnedByPlayer1 = 16, //AllFilled & !OwnedByPlayer1 = OwnedByPlayer2
  }
}