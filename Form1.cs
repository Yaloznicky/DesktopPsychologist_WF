using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DesktopPsychologist_WF.CustomElements;
using DesktopPsychologist_WF.Models;
using DesktopPsychologist_WF.Services;
using Microsoft.AspNetCore.Identity;
namespace DesktopPsychologist_WF
{
    public partial class Form1 : Form
    {
        private readonly IDbService db;
        private bool isResizing = false;
        private string currentMenuSection = "btnAboutMe";
        private User currentUser = null;


        public Form1(IDbService db)
        {
            this.db = db;

            InitializeComponent();

            labelUser.Text = "";
            showContent();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            currentMenuSection = ((Button)sender).Name;
            panelContent.Controls.Clear();
            showContent();
        }

        private void showContent()
        {
            switch (currentMenuSection)
            {
                case "btnAboutMe":
                    AboutMe();
                    break;
                case "btnThemes":
                    Themes();
                    break;
                case "btnPrice":
                    Price();
                    break;
                case "btnRewiews":
                    Rewiews();
                    break;
                case "btnContacts":
                    Contacts();
                    break;
                default:
                    break;
            }
        }

        private void AboutMe()
        {
            labelTitle.Text = "Обо мне";

            int currentTopPosition = 20; 
            
            // 1. Создаем и настраиваем PictureBox

            var pictureBox = CreateCustomElements.CustomPictureBox(@"img/avatar_W.jpg", currentTopPosition, panelContent.Width);
            panelContent.Controls.Add(pictureBox);
            currentTopPosition += pictureBox.Height + 50;

            // 2. Создаем текстовые элементы

                // TODO: Сделать таблицу в БД
            string[] testText = {
                "Lorem ipsum dolor sit amet",
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit.Ad adipisci cumque impedit nobis, debitis, quis culpa temporibus distinctio sit saepe et fugit facere corporis voluptate at quidem, ratione recusandae itaque blanditiis id! Ut, aut dignissimos porro quis, ad suscipit.Perferendis culpa cupiditate nam tenetur earum illo fugiat voluptates sint similique."
            };

            for (int i = 0; i < 4; i++)
            {
                var content = new TextBox();
                if(i == 0)
                {
                    content = CreateCustomElements.CustomTextBox(testText[i], currentTopPosition, panelContent.Width, "заголовок");
                }
                else
                {
                    content = CreateCustomElements.CustomTextBox(testText[1], currentTopPosition, panelContent.Width, "абзац");
                }

                panelContent.Controls.Add(content);

                // Текущая позиция Y для следующего элемента
                currentTopPosition = content.Bottom; 
            }          
        }

        private void Themes()
        {
            labelTitle.Text = "Услуги";

            List<Theme> themes = db.GetThemes();
            themes.Reverse();

            int currentTopPosition = 20;
            var title = new TextBox();
            var content = new TextBox();

            if(checkAdmin())
            {
                Button addTheme = new Button()
                {
                    Text = "Добавить новую услугу",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    BackColor = Color.Blue,
                    ForeColor = Color.White,
                    Size = new Size(300, 50),
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.Top,
                    Location = new Point((panelContent.Width - 300) / 2, currentTopPosition)
                };
                addTheme.Click += (s, e) => 
                {
                    WriteTheme();
                    UpdatePanelLayout();
                };
                panelContent.Controls.Add(addTheme);
                currentTopPosition = addTheme.Bottom + 60;
            }

            foreach (var theme in themes)
            {
                // 1. Создаем и настраиваем PictureBox

                var pictureBox = CreateCustomElements.CustomPictureBox(theme.pathImage, currentTopPosition, panelContent.Width);
                panelContent.Controls.Add(pictureBox);
                currentTopPosition += pictureBox.Height + 50;


                // 2. Создаем текстовые элементы

                title = CreateCustomElements.CustomTextBox(theme.themeName, currentTopPosition, panelContent.Width, "заголовок");
                currentTopPosition = title.Bottom;

                content = CreateCustomElements.CustomTextBox(theme.text, currentTopPosition, panelContent.Width, "абзац");
                if(checkAdmin()) currentTopPosition = content.Bottom + 20;
                else currentTopPosition = content.Bottom + 80;
                

                panelContent.Controls.Add(title);
                panelContent.Controls.Add(content);  
                
                if(checkAdmin())
                {
                    Button editeTheme = new Button()
                    {
                        //Name = theme.id.ToString(),
                        Text = "Изменить",

                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        BackColor = Color.Blue,
                        ForeColor = Color.White,
                        Size = new Size(200, 50),
                        FlatStyle = FlatStyle.Flat,
                        Anchor = AnchorStyles.Top,
                        Location = new Point((panelContent.Width - 400) / 2, currentTopPosition)
                    };
                    editeTheme.Click += (s, e) =>
                    {
                        WriteTheme(theme.id);
                        UpdatePanelLayout();
                    };
                    panelContent.Controls.Add(editeTheme);

                    Button deleteTheme = new Button()
                    {
                        Text = "Удалить",
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Size = new Size(200, 50),
                        FlatStyle = FlatStyle.Flat,
                        Anchor = AnchorStyles.Top,
                        Location = new Point(editeTheme.Right + 40, currentTopPosition)
                    };
                    deleteTheme.Click += (s, e) =>
                    {
                        db.DeleteThemes(theme.id);
                        UpdatePanelLayout();
                    };
                    currentTopPosition = deleteTheme.Bottom + 80;
                    panelContent.Controls.Add(deleteTheme);
                }
            }
        }

        private bool checkAdmin()
        {
            if (labelUser.Text == "Admin") return true;
            else return false;
        }

        private void Price()
        {
            labelTitle.Text = "Стоимость";

            int currentTopPosition = 20;

            // TODO: Сделать таблицу в БД
            string[][] cardText = {
                new string[] {
                    "Первая косультация",
                    "Цена 2000 руб.",
                    "Знакомимся\nУточняем запрос\nНамечаем план психотерапии\nФормируем доверительное и безопасное общение"
                },
                new string[] {
                    "Разовая косультация",
                    "Цена 4000 руб.",
                    "При оплате каждой встречи отедльно"
                },
                new string[] {
                    "Пакет на 5 косультаций",
                    "Цена 18000 руб.",
                    "При оплате пакета стоимость одной консультации дешевле на 10%\n\n(3 600 руб. за одну встречу)"
                }
            };

            for(int i = 0; i < cardText.Length; i++)
            {
                var cardPrice = CreateCustomElements.PriceCard(cardText[i], currentTopPosition, panelContent.Width);
                panelContent.Controls.Add(cardPrice);

                currentTopPosition = cardPrice.Bottom + 20;
            }
        }

        private void Rewiews()
        {
            labelTitle.Text = "Отзывы";

            var reviews = db.GetReviews();
            reviews.Reverse();

            int currentTopPosition = 20;

            Button writeReview = new Button()
            {
                Text = "Написать свой отзыв",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.Orchid,
                ForeColor = Color.White,
                Size = new Size(300, 50),
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top,
                Location = new Point((panelContent.Width - 300) / 2, currentTopPosition)
            };

            writeReview.Click += (s, e) =>
            {
                WriteReview();
                UpdatePanelLayout();
            };

            panelContent.Controls.Add(writeReview);

            currentTopPosition = writeReview.Bottom + 20;

            if (labelUser.Text != "")
                writeReview.Enabled = true;
            else
            {
                writeReview.Enabled = false;
                string message = "Отправить отзыв могут только зарегистрированные пользователи!!!";

                var text = new Label()
                {
                    Text = message,
                    Font = new Font("Segoe UI", 16),
                    ForeColor = Color.Red,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = panelContent.Width,
                    Height = 60,
                    Location = new Point(0, currentTopPosition - 20)
                };

                panelContent.Controls.Add(text);
                currentTopPosition = text.Bottom + 20;
            }


            foreach (var review in reviews)
            {
                var cardReview = CreateCustomElements.ReviewCard(review, currentTopPosition, panelContent.Width);
                panelContent.Controls.Add(cardReview);

                if (checkAdmin())
                {
                    currentTopPosition = cardReview.Bottom + 10;

                    Button editeReview = new Button()
                    {
                        Text = "Изменить",
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        BackColor = Color.Blue,
                        ForeColor = Color.White,
                        Size = new Size(200, 50),
                        FlatStyle = FlatStyle.Flat,
                        Anchor = AnchorStyles.Top,
                        Location = new Point((panelContent.Width - 400) / 2, currentTopPosition)
                    };
                    editeReview.Click += (s, e) =>
                    {
                        WriteReview(review.Id);
                        UpdatePanelLayout();
                    };
                    panelContent.Controls.Add(editeReview);

                    Button deleteReview = new Button()
                    {
                        Text = "Удалить",
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Size = new Size(200, 50),
                        FlatStyle = FlatStyle.Flat,
                        Anchor = AnchorStyles.Top,
                        Location = new Point(editeReview.Right + 40, currentTopPosition)
                    };
                    deleteReview.Click += (s, e) =>
                    {
                        db.DeleteReviews(review.Id);
                        UpdatePanelLayout();
                    };
                    currentTopPosition = deleteReview.Bottom + 60;
                    panelContent.Controls.Add(deleteReview);
                }
                else
                {
                    currentTopPosition = cardReview.Bottom + 40;
                }

            }

        }

        private void Contacts()
        {
            labelTitle.Text = "Контакты";

            string[] testText = {
                "Фамилия Имя Отчество",
                "тел. +7 (000) 000-00-00",
                "e-mail: psiho@gmail.com"
            };

            for (int i = testText.Count() - 1; i >= 0 ; i--)
            {
                var content = new Label();
                if (i == 0)
                {
                    content.Text = testText[i];
                    content.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                }
                else
                {
                    content.Text = testText[i];
                    content.Font = new Font("Segoe UI", 14);
                }

                content.TextAlign = ContentAlignment.MiddleCenter;
                content.ForeColor = Color.FromArgb(64,64,64);
                content.Height = 80;
                content.Dock = DockStyle.Top;
                content.BackColor = Color.White;
                content.BorderStyle = BorderStyle.None;

                panelContent.Controls.Add(content);

            }
        }



        // Перерисовка формы при изменении размера
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (isResizing) return;
            isResizing = true;

            try
            {
                UpdatePanelLayout();
            }
            finally
            {
                isResizing = false;
            }
        }

        private void UpdatePanelLayout()
        {
            panelContent.Controls.Clear();
            showContent();
        }



        // Основной функционал
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(btnLogin.Text == "Вход")
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    DialogResult dialogResult;
                    do
                    {
                        dialogResult = loginForm.ShowDialog();
                        if(dialogResult == DialogResult.Yes)
                        {
                            loginForm.Dispose();
                            Registration();
                            break;
                        }

                        if (dialogResult == DialogResult.OK)
                        {
                            if (loginForm.txtLogin.Text == "" || loginForm.txtPassword.Text == "")
                            {
                                MessageBox.Show(
                                    "Все поля формы должны быть заполнены.",
                                    "Ошибка ввода!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                continue;
                            }

                            currentUser = db.GetUser(loginForm.txtLogin.Text);
                            if (currentUser is null)
                            {
                                loginForm.Dispose();
                                Registration();
                                break;
                            }
                            else
                            {
                                PasswordHasher<User> hasher = new PasswordHasher<User>();
                                PasswordVerificationResult result = hasher.VerifyHashedPassword(currentUser, currentUser.Password, loginForm.txtPassword.Text);

                                if (result == 0)
                                {
                                    MessageBox.Show(
                                        "Неправильный ЛОГИН или ПАРОЛЬ.",
                                        "Ошибка ввода!",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );
                                    continue;
                                }

                                labelUser.Text = currentUser.Login;
                                btnLogin.Text = "Выход";
                                break;
                            }

                        }
                    } while (dialogResult == DialogResult.OK);
                }
                UpdatePanelLayout();
            }
            else
            {
                labelUser.Text = "";
                btnLogin.Text = "Вход";
                UpdatePanelLayout();
            }
        }

        private void Registration()
        {
            using (RegistrationForm registrationForm = new RegistrationForm()) 
            {
                DialogResult dialogResult;

                do
                {
                    dialogResult = registrationForm.ShowDialog();

                    if(dialogResult == DialogResult.OK)
                    {
                        if (registrationForm.txtLogin.Text == "" || registrationForm.txtPassword.Text == "" || registrationForm.txtConfirmPassword.Text == "")
                        {
                            MessageBox.Show(
                                "Все поля формы должны быть заполнены.",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }

                        if(registrationForm.txtPassword.Text != registrationForm.txtConfirmPassword.Text)
                        {
                            MessageBox.Show(
                                "Проверьте правильность ввода паролей!",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }

                        if (db.GetUser(registrationForm.txtLogin.Text) is null)
                        {                            
                            User newUser = new User(
                                registrationForm.txtLogin.Text,
                                registrationForm.GetGender(),
                                registrationForm.txtPassword.Text
                            );
                            currentUser = newUser;
                            db.SetUser(currentUser);

                            labelUser.Text = currentUser.Login;
                            btnLogin.Text = "Выход";
                            break;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Такой пользователь уже есть. Придумайте другой логин.",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }
                    }

                } while (dialogResult == DialogResult.OK);
            }
        }

        private void WriteReview(int id = -1)
        {
            using (ReviewForm reviewForm = new ReviewForm())
            {
                if (id != -1)
                {
                    Review review = db.GetReview(id);
                    reviewForm.txtReview.Text = review.Text;
                }

                DialogResult dialogResult;
                do
                {
                    dialogResult = reviewForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        if(reviewForm.txtReview.Text == "")
                        {
                            MessageBox.Show(
                                "Вы ничего не написали. Добавьте отзыв.",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }

                        if(id != -1)
                        {
                            db.EditReviews(id, reviewForm.txtReview.Text);
                            break;
                        }
                        else
                        {
                            Review newReview = new Review();
                            newReview.DateTimeReview = DateTime.Now;
                            newReview.Text = reviewForm.txtReview.Text;
                            newReview.UsersId = currentUser.Id;
                            db.SetReview(newReview);
                            break;
                        }
                    }
                } while (dialogResult == DialogResult.OK);
            }

        }

        private void WriteTheme(int id = -1)
        {
            using (ThemeForm themeForm = new ThemeForm())
            {
                if (id != -1) 
                {
                    Theme theme = db.GetTheme(id);  
                    themeForm.txtName.Text = theme.themeName;
                    themeForm.txtDescription.Text = theme.text;
                }

                DialogResult dialogResult;
                do
                {
                    dialogResult = themeForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (themeForm.txtName.Text == "" || themeForm.txtDescription.Text == "")
                        {
                            MessageBox.Show(
                                "Все поля формы должны быть заполнены.",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }

                        if(id != -1)
                        {
                            db.EditThemes(id, themeForm.txtName.Text, themeForm.txtDescription.Text);
                            break;
                        }
                        else
                        {
                            Theme newTheme = new Theme();
                            newTheme.pathImage = "img/service.jpg";
                            newTheme.themeName = themeForm.txtName.Text;
                            newTheme.text = themeForm.txtDescription.Text;
                            db.SetTheme(newTheme);
                            break;
                        }
                    }

                } while (dialogResult == DialogResult.OK);
            }

        }

    }
}
