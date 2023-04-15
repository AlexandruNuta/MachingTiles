using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema1mvp
{
    public class Piece
    {
        private bool _isPressed;
        private bool _isFound;
        private string _imagePath;

        public bool IsPressed
        {
            get => _isPressed;
            set => _isPressed = value;
        }

        public bool IsFound
        {
            get => _isFound;
            set => _isFound = value;
        }

        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }

        public Piece(bool isPressed = false, bool isFound = false, string imagePath = "")
        {
            _isPressed = isPressed;
            _isFound = isFound;
            _imagePath = imagePath;
        }

        public void Press()
        {
            _isPressed = true;
        }

        public void Unpress()
        {
            _isPressed = false;
        }

        public void Find()
        {
            _isFound = true;
        }
    }
}
