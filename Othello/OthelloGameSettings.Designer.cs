using System.Windows.Forms;

namespace Othello
{
    partial class OthelloGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.buttonChangeBoardSize = new System.Windows.Forms.Button();
            this.buttonPlayAgainstComputer = new System.Windows.Forms.Button();
            this.buttonPlayAgainstFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonChangeBoardSize
            // 
            this.buttonChangeBoardSize.AccessibleDescription = "";
            this.buttonChangeBoardSize.AccessibleName = "";
            this.buttonChangeBoardSize.Location = new System.Drawing.Point(12, 12);
            this.buttonChangeBoardSize.Name = "buttonChangeBoardSize";
            this.buttonChangeBoardSize.Size = new System.Drawing.Size(260, 42);
            this.buttonChangeBoardSize.TabIndex = 0;
            this.buttonChangeBoardSize.Text = "Board Size: 6X6 (click to increase)";
            this.buttonChangeBoardSize.UseVisualStyleBackColor = true;
            this.buttonChangeBoardSize.Click += new System.EventHandler(this.buttonChangeBoardSize_Click);
            // 
            // buttonPlayAgainstComputer
            // 
            this.buttonPlayAgainstComputer.Location = new System.Drawing.Point(12, 72);
            this.buttonPlayAgainstComputer.Name = "buttonPlayAgainstComputer";
            this.buttonPlayAgainstComputer.Size = new System.Drawing.Size(121, 60);
            this.buttonPlayAgainstComputer.TabIndex = 1;
            this.buttonPlayAgainstComputer.Text = "Play against the computer";
            this.buttonPlayAgainstComputer.UseVisualStyleBackColor = true;
            this.buttonPlayAgainstComputer.Click += new System.EventHandler(this.buttonPlayAgainstComputer_Click);
            // 
            // buttonPlayAgainstFriend
            // 
            this.buttonPlayAgainstFriend.Location = new System.Drawing.Point(151, 72);
            this.buttonPlayAgainstFriend.Name = "buttonPlayAgainstFriend";
            this.buttonPlayAgainstFriend.Size = new System.Drawing.Size(121, 60);
            this.buttonPlayAgainstFriend.TabIndex = 2;
            this.buttonPlayAgainstFriend.Text = "Play against your friend";
            this.buttonPlayAgainstFriend.UseVisualStyleBackColor = true;
            this.buttonPlayAgainstFriend.Click += new System.EventHandler(this.buttonPlayAgainstFriend_Click);
            // 
            // OthelloGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 142);
            this.Controls.Add(this.buttonPlayAgainstFriend);
            this.Controls.Add(this.buttonPlayAgainstComputer);
            this.Controls.Add(this.buttonChangeBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OthelloGameSettings";
            this.Text = "Othello - Game Settings";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPlayAgainstComputer;
        private System.Windows.Forms.Button buttonPlayAgainstFriend;
        private System.Windows.Forms.Button buttonChangeBoardSize;
    }
}

