using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Common.Util.Constants
{
    public static class ResponseMessage
    {
        public const string SUCCESS = "success.";
        public const string FAILURE = "Internal server error. Please try again later";
        public const string ERROR = "Something went wrong, Please contact your support.";
        public const string NO_DATA_FOUND = "No Data found for this request.";
        public const string DATA_ADD_SUCCESS = "Data has been added successfully.";
        public const string DATA_UPDATE_SUCCESS = "Data has been updated successfully.";
        public const string DATA_DELETE_SUCCESS = "Data has been deleted successfully.";
        public const string DATA_SAVED_SUCCESS = "Data has been saved successfully.";
        public const string MAIL_SUCCESS = "Mail has been sent successfully.";
        public const string FILE_UPLOADED_SUCCESS = "File uploaded successfully.";
        public const string ID_SHOULD_ZERO = "Id Should be zero for new entry.";
        public const string USER_ACCOUNT_INACTIVE = "Your account is deactivated. Please contact support.";
        public const string CHECK_EMAIL_PASSWORD = "Please check your email id or password.";
        public const string USER_INACTIVE = "User is not active.";
        public const string USER_IN_DRAFT = "This user is not activated yet. Please contact support.";
        public const string USER_MAX_ATTEMPT_LOCKED = "Your account has been locked because of login attempt limit exceeds, Please contact your support.";
        public const string LOGIN_SUCCESS = "User logged in successfully.";
        public const string LOGOUT_SUCCESS = "User logged out in successfully.";
        public const string INVALID_USERID = "UserId is invalid.";
        public const string FORGET_PASSWORD_LINK_GENERATED = "Forget password link has been sent to your registerd email.";
        public const string INVALID_TOKEN = "Invalid Token.";
        public const string TOKEN_EXPIRED = "Token Expired, Please generate request again!";
        public const string VALID_TOKEN = "Valid Token.";
        public const string PASSWORD_CHANGE_SUCCESS = "Password changed successfully";
        public const string EMAIL_EXIST_SUCCESS = "Email already exists.";
        public const string ROLE_EXIST_SUCCESS = "Role already exists.";
        public const string DATA_UNDO_SUCCESS = "Data has been undo successfully.";
        public const string PRODUCT_NOT_SUBSCRIPTION = "Product Not Subscription please subscription first.";
        public const string USER_ACTIVATED = "User Activated successfully.";
        public const string CODE_ALREADY_USE = "Code Already in use.";
        public const string NO_USER_FOUND = "Could not find user.";
        public const string LAST_5_PASSWORD_ERROR_MESSAGE = "New password cannot be same as your last 5 old passwords";
        public const string INVALID_EMAIL = "Please provide correct email address.";
        public const string OTP_SENT_SUCCESS = "OTP Sent successfully.";
        public const string OTP_SENT_FAIL = "DrPro App could not text you one-time code. Please contact support.";
        public const string PASSWORD_MAIL_SENT_FAIL = "DrPro App could not text you forgot password mail. Please contact support.";
        public const string OTP_INCORRECT = "Please enter correct OTP.";
        public const string EMAIL_NOT_LINK_WITH_PROFILE = "This email address is not linked with your profile.";
    }
}
