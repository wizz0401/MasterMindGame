using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterMindGame.Business.Common;
using MasterMindGame.Presentation.Helpers;

namespace MasterMindGame.Presentation
{
    public partial class MasterMindGame : Form
    {
        private string[] _guessedNumberInfo;
        private MasterMindGameTurn _gameTurn;

        public MasterMindGame()
        {
            InitializeComponent();
            InitializeMasterMindGameComponent();
        }

        private void InitializeMasterMindGameComponent()
        {
            ResourceManagerHelper.Init();
            _gameTurn = new MasterMindGameTurn();
            _guessedNumberInfo = new string[_gameTurn.NumberLength];
            InitHintZone();
            InitTextBoxInputCodeBreak(_gameTurn.NumberLength);
            InitButtonBreakCode();
            InitLabelShowGuessResult();           
        }

        private void InitHintZone()
        {
            InitHintList();
            InitHitTips();
            InitButtonPlayNewRound();
        }

        private void InitHintList()
        {
            // 
            // ListBox_CodeGuide
            // 
            this.ListBox_CodeHint = new System.Windows.Forms.ListBox();
            this.ListBox_CodeHint.Location = new System.Drawing.Point(12, 31);
            this.ListBox_CodeHint.Name = "ListBox_CodeHint";
            this.ListBox_CodeHint.Size = new System.Drawing.Size(327, 225);
            this.ListBox_CodeHint.Font = new System.Drawing.Font("Microsoft YaHei", 16);
            this.ListBox_CodeHint.TabIndex = 0;
            this.Controls.Add(this.ListBox_CodeHint);
            LoadHints();
        }

        private void InitHitTips()
        {
            this.Label_ShowTips_Number = new System.Windows.Forms.Label();
            this.Label_ShowTips_Number.Location = new System.Drawing.Point(400, 31);
            this.Label_ShowTips_Number.Name = "Label_ShowTips_Number";
            this.Label_ShowTips_Number.Text = "This hints number is based on 1-9" +
                ";The ● means same number with answer in the same position; The ໐ means same number" +
                " with answer in the different position";
            this.Label_ShowTips_Number.Font = new System.Drawing.Font("Microsoft YaHei", 10);
            this.Label_ShowTips_Number.Size = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.Label_ShowTips_Number);
        }

        private void InitTextBoxInputCodeBreak(int numberlength)
        {
            var position = 0;
            for (var i = 0; i < numberlength; i++)
            {
                var inputBreakCode = new System.Windows.Forms.TextBox();
                inputBreakCode.Location = new System.Drawing.Point(position, 300);
                inputBreakCode.Name = "TextBox_CodeBreak_" + i;
                inputBreakCode.Size = new System.Drawing.Size(20, 20);
                inputBreakCode.TextChanged += new System.EventHandler(this.OnBreakCodeInputChanged);
                this.Controls.Add(inputBreakCode);
                position = position + 25;
            }
        }

        private void InitButtonPlayNewRound()
        {
            this.Button_PlayNewRound = new System.Windows.Forms.Button();
            this.Button_PlayNewRound.Location = new System.Drawing.Point(400, 150);
            this.Button_PlayNewRound.Name = "Button_PlayNewRound";
            this.Button_PlayNewRound.Text = "Play new round";
            this.Button_PlayNewRound.Click += new System.EventHandler(this.OnPlayNewRoundButtonClicked);
            this.Controls.Add(this.Button_PlayNewRound);
        }

        private void InitButtonBreakCode()
        {
            this.Button_BreakCode = new System.Windows.Forms.Button();
            this.Button_BreakCode.Location = new System.Drawing.Point(250, 300);
            this.Button_BreakCode.Name = "Button_BreakCode";
            this.Button_BreakCode.Text = "Guess";
            this.Button_BreakCode.Click += new System.EventHandler(this.OnBreakCodeButtonClicked);
            this.Controls.Add(this.Button_BreakCode);
        }

        private void InitLabelShowGuessResult()
        {
            this.Label_ShowGuessResult = new System.Windows.Forms.Label();
            this.Label_ShowGuessResult.Location = new System.Drawing.Point(0, 350);
            this.Label_ShowGuessResult.Name = "Label_ShowGuessResult";
            this.Label_ShowGuessResult.Text = "This is result";
            this.Label_ShowGuessResult.Font = new System.Drawing.Font("Microsoft YaHei", 10);
            this.Controls.Add(this.Label_ShowGuessResult);
        }

        private void LoadHints()
        {
            var hintsDetail = _gameTurn.ThisTurnHints;

            foreach(var hintDetail in hintsDetail)
            {
                var hintLabelBuilder = new StringBuilder();
                var hintText = hintDetail.Split('_')[0];
                var hintInfo = hintDetail.Split('_')[1];
                var numberStrong =Convert.ToInt32(hintInfo.Split(',')[0]);
                var numberWeak = Convert.ToInt32(hintInfo.Split(',')[1]);
                hintLabelBuilder.Append(string.Format("{0} ", hintText));
                for(var i=0;i< numberStrong;i++)
                {
                    hintLabelBuilder.Append("●");
                }

                for(var i=0;i<numberWeak;i++)
                {
                    hintLabelBuilder.Append("໐");
                }

                this.ListBox_CodeHint.Items.Add(hintLabelBuilder.ToString());

            }
        }

        private void OnBreakCodeButtonClicked(object sender, EventArgs e)
        {
            _gameTurn.ChangeState(new TryState());
            if (_gameTurn.IsGameOver)
            {
                if (_gameTurn.IsGameFail)
                {
                    MessageBox.Show(string.Format(ResourceManagerHelper.GetResource("MasterMindGame_Message_GameIsLost")
                        ,_gameTurn.ThisTurnAnswer));
                }
                else
                {
                    MessageBox.Show(ResourceManagerHelper
                        .GetResource("MasterMindGame_Message_GameIsSuccessful"));
                }
            }
            else
            {
                MessageBox.Show(string.Format(ResourceManagerHelper
                        .GetResource("MasterMindGame_Message_ContinueTryGame")
                    , GetPlayResultGraph(_gameTurn.CurrentCorrectPlayResultInfoDisplay)));
            }
            this.Label_ShowGuessResult.Text = _gameTurn.CurrentCorrectPlayResultDisplay;
        }

        private void OnBreakCodeInputChanged(object sender, EventArgs e)
        {
            var input = (TextBox)sender;

            if (!string.IsNullOrEmpty(input.Name) && !string.IsNullOrEmpty(input.Text))
            {
                if(!CommonHelper.IsInt(input.Text)
                    || Convert.ToInt32(input.Text) <0 
                    || Convert.ToInt32(input.Text) >9)
                {
                    MessageBox.Show("Please input the numeric value like 1-9.");
                    return;
                }
                var position = Convert.ToInt32(input.Name.Split('_')[2]);
                this._guessedNumberInfo[position] = string.Format("{0},{1}"
                    , input.Text, position);
            }

            _gameTurn.CurrentPlayResult = this._guessedNumberInfo.ToList();
        }

        private void OnPlayNewRoundButtonClicked(object sender, EventArgs e)
        {
            this._gameTurn.ChangeState(new StartState());
            this.ListBox_CodeHint.Items.Clear();
            LoadHints();
        }

        private string GetPlayResultGraph(string playresultInfo)
        {
            var builder = new StringBuilder();
            var numberStrong = Convert.ToInt32(playresultInfo.Split(',')[0]);
            var numberWeak = Convert.ToInt32(playresultInfo.Split(',')[1]);
            for (var i = 0; i < numberStrong; i++)
            {
                builder.Append("●");
            }

            for (var i = 0; i < numberWeak; i++)
            {
                builder.Append("໐");
            }
            return builder.ToString();
        }

    }
}
