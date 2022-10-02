namespace CarFest.BL.DTO
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string UserFirstName { get; set; }
        public string Token { get; set; }
    }
}
