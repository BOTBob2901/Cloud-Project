namespace Cloud_FinalProject.Modal
{
    public class PlayerGridBox
    {
        // Player email shown in the grid
        public string Email { get; set; }

        // Player username shown in the grid
        public string UserName { get; set; }

        // Player password value shown in the grid
        public string Password { get; set; }

        // Empty constructor required for grid binding and deserialization
        public PlayerGridBox() { }

        public PlayerGridBox(string Email, string UserName, string Password)
        {
            // Assign values for quick grid row creation
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
