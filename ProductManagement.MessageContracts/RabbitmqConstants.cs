namespace ProductManagement.MessageContracts
{
    public static class RabbitmqConstants
    {
        public static string RabbitMqUri = "rabbitmq://localhost/ProductRegistration/";
        public static string UserName = "guest";
        public static string Password = "guest";
        public const string RegistrationServiceQueue = "registration.service";
        public const string NotificationServiceQueue = "notification.service";
        public const string FacebookServiceQueue = "facebook.service";
        public const string InstagramServiceQueue = "instagram.service";
    }
}