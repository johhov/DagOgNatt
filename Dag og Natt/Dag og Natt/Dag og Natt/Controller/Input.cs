using Microsoft.Xna.Framework.Input;

namespace Dag_og_Natt
{
    internal class Input
    {
        /// <summary>
        /// Handles the states of the mouse and keyboard.
        /// </summary>
        public KeyboardState previousKeyState;

        public KeyboardState currentKeyState;

        public Input()
        {
            //Leave empty.
        }

        public bool IsKeyPressed(Keys key)
        {
            return (currentKeyState.IsKeyDown(key));
        }

        public bool IsKeyPressedOnce(Keys key)
        {
            if (currentKeyState.IsKeyUp(key) && previousKeyState.IsKeyDown(key))
            {
                return true;
            }

            return false;
        }

        public void Update()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }
    }
}