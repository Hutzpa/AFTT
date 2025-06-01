namespace AFTT.Common.Enums;

public enum ResponseCode
{
    Success = 0,
    Fail = -1,
    BadRequest = 400,
    InternalServerError = 500,

    MissionNotFound = 1001,
}