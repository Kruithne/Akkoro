using System.Collections.Generic;
using System.Windows.Forms;

namespace Akkoro
{
    class KeyMap
    {
        public bool IsUpper { get; private set; }
        public Keys Key { get; private set; }

        public static KeyMap GetKey(char keyChar)
        {
            return _map.ContainsKey(keyChar) ? _map[keyChar] : null;
        }

        private static Dictionary<char, KeyMap> _map = new Dictionary<char, KeyMap>()
        {
            { 'A', new KeyMap() { Key = Keys.A, IsUpper = true } },
            { 'B', new KeyMap() { Key = Keys.B, IsUpper = true } },
            { 'C', new KeyMap() { Key = Keys.C, IsUpper = true } },
            { 'D', new KeyMap() { Key = Keys.D, IsUpper = true } },
            { 'E', new KeyMap() { Key = Keys.E, IsUpper = true } },
            { 'F', new KeyMap() { Key = Keys.F, IsUpper = true } },
            { 'G', new KeyMap() { Key = Keys.G, IsUpper = true } },
            { 'H', new KeyMap() { Key = Keys.H, IsUpper = true } },
            { 'I', new KeyMap() { Key = Keys.I, IsUpper = true } },
            { 'J', new KeyMap() { Key = Keys.J, IsUpper = true } },
            { 'K', new KeyMap() { Key = Keys.K, IsUpper = true } },
            { 'L', new KeyMap() { Key = Keys.L, IsUpper = true } },
            { 'M', new KeyMap() { Key = Keys.M, IsUpper = true } },
            { 'N', new KeyMap() { Key = Keys.N, IsUpper = true } },
            { 'O', new KeyMap() { Key = Keys.O, IsUpper = true } },
            { 'P', new KeyMap() { Key = Keys.P, IsUpper = true } },
            { 'Q', new KeyMap() { Key = Keys.Q, IsUpper = true } },
            { 'R', new KeyMap() { Key = Keys.R, IsUpper = true } },
            { 'S', new KeyMap() { Key = Keys.S, IsUpper = true } },
            { 'T', new KeyMap() { Key = Keys.T, IsUpper = true } },
            { 'U', new KeyMap() { Key = Keys.U, IsUpper = true } },
            { 'V', new KeyMap() { Key = Keys.V, IsUpper = true } },
            { 'W', new KeyMap() { Key = Keys.W, IsUpper = true } },
            { 'X', new KeyMap() { Key = Keys.X, IsUpper = true } },
            { 'Y', new KeyMap() { Key = Keys.Y, IsUpper = true } },
            { 'Z', new KeyMap() { Key = Keys.Z, IsUpper = true } },
            { 'a', new KeyMap() { Key = Keys.A } },
            { 'b', new KeyMap() { Key = Keys.B } },
            { 'c', new KeyMap() { Key = Keys.C } },
            { 'd', new KeyMap() { Key = Keys.D } },
            { 'e', new KeyMap() { Key = Keys.E } },
            { 'f', new KeyMap() { Key = Keys.F } },
            { 'g', new KeyMap() { Key = Keys.G } },
            { 'h', new KeyMap() { Key = Keys.H } },
            { 'i', new KeyMap() { Key = Keys.I } },
            { 'j', new KeyMap() { Key = Keys.J } },
            { 'k', new KeyMap() { Key = Keys.K } },
            { 'l', new KeyMap() { Key = Keys.L } },
            { 'm', new KeyMap() { Key = Keys.M } },
            { 'n', new KeyMap() { Key = Keys.N } },
            { 'o', new KeyMap() { Key = Keys.O } },
            { 'p', new KeyMap() { Key = Keys.P } },
            { 'q', new KeyMap() { Key = Keys.Q } },
            { 'r', new KeyMap() { Key = Keys.R } },
            { 's', new KeyMap() { Key = Keys.S } },
            { 't', new KeyMap() { Key = Keys.T } },
            { 'u', new KeyMap() { Key = Keys.U } },
            { 'v', new KeyMap() { Key = Keys.V } },
            { 'w', new KeyMap() { Key = Keys.W } },
            { 'x', new KeyMap() { Key = Keys.X } },
            { 'y', new KeyMap() { Key = Keys.Y } },
            { 'z', new KeyMap() { Key = Keys.Z } },
            { '0', new KeyMap() { Key = Keys.D0 } },
            { '1', new KeyMap() { Key = Keys.D1 } },
            { '2', new KeyMap() { Key = Keys.D2 } },
            { '3', new KeyMap() { Key = Keys.D3 } },
            { '4', new KeyMap() { Key = Keys.D4 } },
            { '5', new KeyMap() { Key = Keys.D5 } },
            { '6', new KeyMap() { Key = Keys.D6 } },
            { '7', new KeyMap() { Key = Keys.D7 } },
            { '8', new KeyMap() { Key = Keys.D8 } },
            { '9', new KeyMap() { Key = Keys.D9 } },
            { ' ', new KeyMap() { Key = Keys.Space } },
            { '*', new KeyMap() { Key = Keys.Multiply } },
            { '+', new KeyMap() { Key = Keys.Add } },
            { '-', new KeyMap() { Key = Keys.Subtract } },
            { '/', new KeyMap() { Key = Keys.Divide } },
            { '?', new KeyMap() { Key = Keys.OemQuestion } },
            { '`', new KeyMap() { Key = Keys.Oemtilde } },
            { '(', new KeyMap() { Key = Keys.OemOpenBrackets } },
            { ')', new KeyMap() { Key = Keys.OemCloseBrackets } },
            { '.', new KeyMap() { Key = Keys.OemPeriod } },
            { ',', new KeyMap() { Key = Keys.Oemcomma } }
        };
    }
}
