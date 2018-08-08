using Google.Apis.Calendar.v3;

namespace AtmoreChamberPinnacle.App_Start
{
    internal static class MyRequestedScopes
    {
        public static string[] Scopes
        {
            get
            {
                return new[] {
                    "openid",
                    "email",
                    CalendarService.Scope.CalendarReadonly,
                };
            }
        }
    }
}