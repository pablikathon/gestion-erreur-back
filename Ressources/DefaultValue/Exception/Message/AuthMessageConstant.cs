namespace exception.Message;

public static class AuthMessage
{
    public const string UserAlreadyExist = "User Already Exist";
    public const string ErrorUpdateUserToken = "Error when update error un database";
    public const string WrongPassword = "Wrong password, try something else";
    public const string WrongToken = "Wrong Token, maybe expired ?";

    public const string NoVerifiedUserFound = "No verified user founded";
    public const string RefreshTokenNotFound = "Refresh Token not found";

}