using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopPsychologist_WF.CustomElements;
using DesktopPsychologist_WF.Models;
using DesktopPsychologist_WF.Services;
using Microsoft.AspNetCore.Identity;
namespace DesktopPsychologist_WF
{
    public partial class Form1 : Form
    {
        private readonly IHttpClient apiClient;
        private bool isResizing = false;
        private string currentMenuSection = "btnAboutMe";
        private User currentUser = null;
        private TextHolder textHolder;


        public Form1(IHttpClient apiClient)
        {
            this.apiClient = apiClient;

            this.textHolder = new TextHolder();

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

        private async Task showContent()
        {
            switch (currentMenuSection)
            {
                case "btnAboutMe":
                    AboutMe();
                    break;
                case "btnThemes":
                    await Themes();
                    break;
                case "btnPrice":
                    Price();
                    break;
                case "btnRewiews":
                    await Reviews();
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

            var content = new TextBox();

            content = CreateCustomElements.CustomTextBox(textHolder.title_AboutMe, currentTopPosition, panelContent.Width, "заголовок");
            panelContent.Controls.Add(content);
            currentTopPosition = content.Bottom;
            for (int i = 0; i < 3; i++)
            {
                content = CreateCustomElements.CustomTextBox(textHolder.text_AboutMe, currentTopPosition, panelContent.Width, "абзац");
                panelContent.Controls.Add(content);
                currentTopPosition = content.Bottom;
            }

        }

        public async Task Themes()
        {
            labelTitle.Text = "Услуги";

            try
            {
                var themes = await apiClient.GetThemesAsync();
                themes.Reverse();

                int currentTopPosition = 20;
                var title = new TextBox();
                var content = new TextBox();

                if (checkAdmin())
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
                    addTheme.Click += async (s, e) =>
                    {
                        await WriteTheme();
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
                    if (checkAdmin()) currentTopPosition = content.Bottom + 20;
                    else currentTopPosition = content.Bottom + 80;


                    panelContent.Controls.Add(title);
                    panelContent.Controls.Add(content);

                    if (checkAdmin())
                    {
                        Button editeTheme = new Button()
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
                        editeTheme.Click += async (s, e) =>
                        {
                            await WriteTheme(theme.id);
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
                        deleteTheme.Click += async (s, e) =>
                        {
                            await apiClient.DeleteThemeAsync(theme.id);
                            UpdatePanelLayout();
                        };
                        currentTopPosition = deleteTheme.Bottom + 80;
                        panelContent.Controls.Add(deleteTheme);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка доступа к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            for (int i = 0; i < textHolder.priceCardText.Length; i++)
            {
                var cardPrice = CreateCustomElements.PriceCard(textHolder.priceCardText[i], currentTopPosition, panelContent.Width);
                panelContent.Controls.Add(cardPrice);

                currentTopPosition = cardPrice.Bottom + 20;
            }
        }

        public async Task Reviews()
        {
            labelTitle.Text = "Отзывы";

            try
            {
                var reviews = await apiClient.GetReviewsAsync();
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

                writeReview.Click += async (s, e) =>
                {
                    await WriteReview();
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
                        editeReview.Click += async (s, e) =>
                        {
                            await WriteReview(review.Id);
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
                        deleteReview.Click += async (s, e) =>
                        {
                            await apiClient.DeleteReviewAsync(review.Id);
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
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка доступа к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Contacts()
        {
            labelTitle.Text = "Контакты";

            for (int i = textHolder.contacts.Count() - 1; i >= 0; i--)
            {
                var content = new Label();
                if (i == 0)
                {
                    content.Text = textHolder.contacts[i];
                    content.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                }
                else
                {
                    content.Text = textHolder.contacts[i];
                    content.Font = new Font("Segoe UI", 14);
                }

                content.TextAlign = ContentAlignment.MiddleCenter;
                content.ForeColor = Color.FromArgb(64, 64, 64);
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
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Вход")
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    DialogResult dialogResult;
                    do
                    {
                        dialogResult = loginForm.ShowDialog();
                        if (dialogResult == DialogResult.Yes)
                        {
                            loginForm.Dispose();
                            await Registration();
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

                            try
                            {
                                currentUser = await apiClient.CheckUserByLoginAsync(loginForm.txtLogin.Text);

                                if (currentUser is null)
                                {
                                    MessageBox.Show(
                                        "Такой пользователь не зарегистрирован. Пройдите регистрацию.",
                                        "Ошибка ввода!",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error
                                    );
                                    loginForm.Dispose();
                                    await Registration();
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
                            catch (Exception ex)
                            {
                                MessageBox.Show($"{ex.Message}", "Ошибка доступа к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
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

        private async Task Registration()
        {
            using (RegistrationForm registrationForm = new RegistrationForm())
            {
                DialogResult dialogResult;

                do
                {
                    dialogResult = registrationForm.ShowDialog();

                    if (dialogResult == DialogResult.OK)
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

                        if (registrationForm.txtPassword.Text != registrationForm.txtConfirmPassword.Text)
                        {
                            MessageBox.Show(
                                "Проверьте правильность ввода паролей!",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }

                        try
                        {
                            User newUser = await apiClient.CheckUserByLoginAsync(registrationForm.txtLogin.Text);

                            if (newUser is null)
                            {
                                newUser = new User(
                                    registrationForm.txtLogin.Text,
                                    registrationForm.GetGender(),
                                    registrationForm.txtPassword.Text
                                );

                                await apiClient.CreateUserAsync(newUser);

                                currentUser = await apiClient.CheckUserByLoginAsync(newUser.Login);

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
                        catch (Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}", "Ошибка доступа к базе данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }

                } while (dialogResult == DialogResult.OK);
            }
        }

        private async Task WriteReview(int id = -1)
        {
            using (ReviewForm reviewForm = new ReviewForm())
            {
                if (id != -1)
                {
                    Review review = apiClient.GetReviewAsync(id).Result;
                    reviewForm.txtReview.Text = review.Text;
                }

                DialogResult dialogResult;
                do
                {
                    dialogResult = reviewForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (reviewForm.txtReview.Text == "")
                        {
                            MessageBox.Show(
                                "Вы ничего не написали. Добавьте отзыв.",
                                "Ошибка ввода!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                            continue;
                        }

                        if (id != -1)
                        {
                            Review updateReviewFields = new Review();
                            updateReviewFields.Text = reviewForm.txtReview.Text;
                            await apiClient.UpdateReviewAsync(id, updateReviewFields);
                            break;
                        }
                        else
                        {
                            Review newReview = new Review();
                            newReview.DateTimeReview = DateTime.Now;
                            newReview.Text = reviewForm.txtReview.Text;
                            newReview.UsersId = currentUser.Id;
                            await apiClient.CreateReviewAsync(newReview);
                            break;
                        }
                    }
                } while (dialogResult == DialogResult.OK);
            }
        }

        private async Task WriteTheme(int id = -1)
        {
            using (ThemeForm themeForm = new ThemeForm())
            {
                if (id != -1)
                {
                    Theme theme = await apiClient.GetThemeAsync(id);
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

                        if (id != -1)
                        {
                            Theme updateThemeFields = new Theme();
                            updateThemeFields.themeName = themeForm.txtName.Text;
                            updateThemeFields.text = themeForm.txtDescription.Text;
                            await apiClient.UpdateThemeAsync(id, updateThemeFields);
                            break;
                        }
                        else
                        {
                            Theme newTheme = new Theme();
                            newTheme.pathImage = "img/service.jpg";
                            newTheme.themeName = themeForm.txtName.Text;
                            newTheme.text = themeForm.txtDescription.Text;
                            await apiClient.CreateThemeAsync(newTheme);
                            break;
                        }
                    }

                } while (dialogResult == DialogResult.OK);
            }
        }
    }
}
