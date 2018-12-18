using GameF.Logic;
using System;
using Xamarin.Forms;

namespace GameF
{
    public partial class MainPage : ContentPage
    {
        private const int Size = 4;
        private Game Game;

        public MainPage()
        {
            InitializeComponent();
            this.Game = new Game(4);
            this.HideButtons();
        }

        protected void Button_Clicked(object sender, EventArgs e)
        {
            if(this.Game.IsSolved()) return;

            if(sender is Button button)
            {
                int x = int.Parse(button.ClassId.Substring(1, 1));
                int y = int.Parse(button.ClassId.Substring(2, 1));
                this.Game.PressAt(x, y);
                ShowButtons();
                var labelSteps = this.FindByName<Label>(nameof(this.Game.Steps));
                labelSteps.Text = "Steps: " + this.Game.Steps.ToString();
                if(this.Game.IsSolved())
                {
                    labelSteps.Text = "Done!";
                }
            }
        }

        protected void Start_Clicked(object sender, EventArgs e)
        {
            int seed = new Random().Next(1000);
            this.Game.Start(seed);
            this.ShowButtons();
            var labelSteps = this.FindByName<Label>(nameof(this.Game.Steps));
            labelSteps.Text = "Steps: " + this.Game.Steps.ToString();
        }

        #region Privates methods
        private void HideButtons()
        {
            for(int x = 0; x < Size; x++)
            {
                for(int y = 0; y < Size; y++)
                {
                    this.ShowDigit(0, x, y);
                }
            }
        }

        private void ShowButtons()
        {
            for(int x = 0; x < Size; x++)
            {
                for(int y = 0; y < Size; y++)
                {
                    this.ShowDigit(this.Game.GetDigitAt(x, y), x, y);
                }
            }
        }

        private void ShowDigit(int digit, int x, int y)
        {
            string name = "b" + x + y;
            var button = this.FindByName<Button>(name);
            button.Text = digit.ToString();
            button.IsVisible = digit > 0;
        }
        #endregion
    }
}