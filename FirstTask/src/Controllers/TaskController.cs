using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class TaskController : ControllerBase{
    public class UserEntity{
        public string Email{get; set;} = "oseprogramms@gmail.com";
        public DateTime Current_date{get; set;} = DateTime.UtcNow;
        public string Github_url{get; set;} = ""; 
    }

    [HttpGet("RetrieveUserDetails")]
    public ActionResult RetrieveUserDetails()
    {
        return Ok(new UserEntity());
    }
}