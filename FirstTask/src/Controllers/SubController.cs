using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Task")]
public class SubController : ControllerBase{
    public class UserEntity{
        public string Email{get; set;} = "oseprogramms@gmail.com";
        public string Current_datetime{get; set;} = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
        public string Github_url{get; set;} = "https://github.com/bahdman/HNG12/"; 
    }

    [HttpGet("RetrieveUserDetails")]
    public ActionResult RetrieveUserDetails()
    {
        return Ok(new UserEntity());
    }
}