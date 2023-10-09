using amusement_park.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    public static class AppSession
    {
        public static bool IsLoggedIn { get; set; } // Общая переменная для проверки входа
        public static string UserLogin { get; set; } // логин залогиненного юзера
        public static TableAttractionsForm AttractionsForm { get; set; }
        public static UserForm userForm { get; set; }
        public static TableUsersForm tableUsersForm { get; set; }
        public static MyTicketsForm myTicketsForm { get; set; }
        public static RegForm regForm { get; set; }
        public static LoginForm loginForm { get; set; }
        public static ChangePasswordForm changePasswordForm { get; set; }
        public static BuyTicketForm ticketForm { get; set; }
        public static AttractionsViewForm attractionsViewForm { get; set; }
        public static AdminForm adminForm { get; set; }
        public static FeedbackForm feedbackForm { get; set; }

    }

}
