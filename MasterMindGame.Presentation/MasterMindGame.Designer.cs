namespace MasterMindGame.Presentation
{
    partial class MasterMindGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox ListBox_CodeHint;
        private System.Windows.Forms.Button Button_BreakCode;
        private System.Windows.Forms.Label Label_ShowGuessResult;
        private System.Windows.Forms.Label Label_ShowTips_Number;
        private System.Windows.Forms.Button Button_PlayNewRound;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Master Mind Game";
        }

        #endregion
    }
}

