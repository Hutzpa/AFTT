using AFTT.Common.Enums;
using System.Text.Json.Serialization;

namespace AFTT.Common.Models.Response;

public record BaseResponse
{
    public ResponseCode ResponseCode { get; set; }

    [JsonIgnore]
    public bool IsSuccess => ResponseCode == ResponseCode.Success;
    public string? Message { get; set; }
}