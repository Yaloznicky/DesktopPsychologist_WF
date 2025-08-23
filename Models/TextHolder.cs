
namespace DesktopPsychologist_WF.Models
{
    public class TextHolder
    {
        public readonly string title_AboutMe = "Lorem ipsum dolor sit amet";
        public readonly string text_AboutMe = "Lorem ipsum dolor sit amet, consectetur adipisicing elit.Ad adipisci cumque impedit nobis, debitis, quis culpa temporibus distinctio sit saepe et fugit facere corporis voluptate at quidem, ratione recusandae itaque blanditiis id! Ut, aut dignissimos porro quis, ad suscipit.Perferendis culpa cupiditate nam tenetur earum illo fugiat voluptates sint similique.";

        public readonly string[] contacts = {
            "Фамилия Имя Отчество",
            "тел. +7 (000) 000-00-00",
            "e-mail: psiho@gmail.com"
        };

        public readonly string[][] priceCardText = {
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

    }
}
