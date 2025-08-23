using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DesktopPsychologist_WF.Models;

namespace DesktopPsychologist_WF.CustomElements
{
    static internal class CreateCustomElements
    {
        static public PictureBox CustomPictureBox(string nameFileImage, int currentTopPosition, int panelContentWidth)
        {
            PictureBox pictureBox = new PictureBox();

            try
            {
                // Доступ к файлам в Resources
                string projectRootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string fullPath = Path.Combine(projectRootPath, @"Resources", nameFileImage);
                if (File.Exists(fullPath))
                {
                    pictureBox.Image = Image.FromFile(fullPath);
                }
                else
                {
                    pictureBox.Image = Properties.Resources.psy;
                }
            }
            catch
            {
                pictureBox.Image = Properties.Resources.psy;
            }

            // Рассчитываем размеры
            int maxWidth = 500;
            if (pictureBox.Image != null)
            {
                float ratio = (float)pictureBox.Image.Width / pictureBox.Image.Height;
                int newHeight = (int)(maxWidth / ratio);
                pictureBox.Size = new Size(maxWidth, newHeight);
            }
            else
            {
                pictureBox.Size = new Size(maxWidth, 300);
            }

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Anchor = AnchorStyles.Top;
            // Центрируем по горизонтали
            pictureBox.Location = new Point(
                (panelContentWidth - pictureBox.Width) / 2,
                currentTopPosition
            );

            return pictureBox;
        }

        static public TextBox CustomTextBox(string text, int currentTopPosition, int panelContentWidth, string typeText, int widthAdjustmentTextField = 30)
        {
            TextBox textBox = new TextBox();

            textBox.Text = text;
            if (typeText == "заголовок")
            {
                textBox.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                textBox.TextAlign = HorizontalAlignment.Center;
            }
            else if (typeText == "абзац")
            {
                textBox.Font = new Font("Segoe UI", 14);
                textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            else if (typeText == "информация")
            {
                textBox.Font = new Font("Segoe UI", 16);
                textBox.ForeColor = Color.Red;
                textBox.TextAlign = HorizontalAlignment.Center;

            }
            textBox.Multiline = true;
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Enabled = false;
            textBox.WordWrap = true;

            textBox.Location = new Point(10, currentTopPosition + 10);
            textBox.Width = panelContentWidth - widthAdjustmentTextField;

            textBox.Height = SizeCalculation(text, textBox, panelContentWidth);

            return textBox;
        }

        static public Panel PriceCard(string [] cardText, int currentTopPosition, int panelContentWidth)
        {
            Panel card = new Panel();
            card.Height = 450;
            card.Width = 400;
            card.BackColor = Color.Thistle;

            int currentTopPositionLable = 20;

            for(int i = 0; i < cardText.Length; i++)
            {
                Label labelTitle = new Label();
                labelTitle.Text = cardText[i];
                labelTitle.AutoSize = false;
                labelTitle.Width = card.Width;
                labelTitle.Height = 40;
                labelTitle.TextAlign = ContentAlignment.MiddleCenter;
                labelTitle.Location = new Point(0, currentTopPositionLable);

                if (i == 0) labelTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
                else if (i == 1) labelTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                else
                {
                    labelTitle.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                    labelTitle.Height = 150;
                }

                card.Controls.Add(labelTitle);
                currentTopPositionLable = labelTitle.Bottom + 20;
            }

            Button button = new Button();
            button.Text = "Оплатить";
            button.Width = 200;
            button.Height = 60;
            button.BackColor = Color.Orchid;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            button.Location = new Point((card.Width - button.Width)/2, card.Height - 80);
            button.Click += (sender, e) =>
            {
                MessageBox.Show("Данный функционал будет реализоваван в ближайшее время.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            card.Controls.Add(button);


            card.Location = new Point(
                (panelContentWidth - card.Width) / 2,
                currentTopPosition
            );

            return card;
        }

        static public TableLayoutPanel ReviewCard(Review review, int currentTopPosition, int panelContentWidth)
        {
            var card = new TableLayoutPanel()
            {
                ColumnCount = 3,
                RowCount = 3,
                Anchor = AnchorStyles.Top,
                Width = panelContentWidth,                               
                AutoSize = true,
                Location = new Point(10, currentTopPosition),
            };

            card.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150f));
            card.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));
            card.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            card.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
            card.RowStyles.Add(new RowStyle(SizeType.Absolute, 100f));
            card.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            PictureBox avatar = new PictureBox()
            {
                Margin = new Padding(0),
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };

            try
            {
                // Доступ к файлам в Resources
                string projectRootPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\"));
                string fullPath = Path.Combine(projectRootPath, @"Resources", review.Users.AvatarImage);
                if (File.Exists(fullPath))
                {
                    avatar.Image = Image.FromFile(fullPath);
                }
                else
                {
                    avatar.Image = Properties.Resources.psy;
                }
            }
            catch
            {
                avatar.Image = Properties.Resources.psy;
            }

            card.Controls.Add(avatar, 0, 0);
            card.SetColumnSpan(avatar, 1);
            card.SetRowSpan(avatar, 2);

           
            for (int i = 0; i < 3; i++)
            {
                var textBox = new TextBox()
                {
                    BorderStyle = BorderStyle.None,
                    Enabled = false,
                    WordWrap = true,
                    Multiline = true,
                    BackColor = Color.White,
                    Dock = DockStyle.Fill
                };

                if (i == 0)
                {
                    textBox.Text = review.Users.Login;
                    textBox.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                }
                if (i == 1)
                {
                    textBox.Text = $"{review.DateTimeReview.ToLongDateString()}  {review.DateTimeReview.ToLongTimeString()}";
                    textBox.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                }
                if (i == 2)
                {
                    textBox.Text = review.Text;
                    textBox.Font = new Font("Segoe UI", 16, FontStyle.Regular);
                    textBox.Width = card.Width - (int)card.ColumnStyles[0].Width - (int)card.ColumnStyles[1].Width - 30;
                    textBox.Height = SizeCalculation(review.Text, textBox, textBox.Width);
                }

                card.Controls.Add(textBox, 2, i);
            }

            return card;
        }

        static private int SizeCalculation(string text, TextBox textBox, int panelContentWidth)
        {
            // Рассчитываем высоту
            int padding = 30;
            Size textSize = TextRenderer.MeasureText(
                text,
                textBox.Font,
                new Size(panelContentWidth, int.MaxValue),
                TextFormatFlags.WordBreak
            );

            return textSize.Height + padding;
        }

    }
}
