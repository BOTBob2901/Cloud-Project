using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cloud_FinalProject.Modal
{
    public class Player
    {
        // Unique document id used in the database usually equals email
        public string id { get; set; }

        // Player email used as identifier and login key
        public string Email { get; set; }

        // Object type name used to differentiate between Player and Admin
        public string ObjType { get; set; }

        // Display name shown in the UI and logs
        public string UserName { get; set; }

        // Encrypted password stored for authentication
        public string Password { get; set; }

        // Player save data stored in the cloud and synced with the game
        public SaveData Save { get; set; }

        // Empty constructor required for deserialization
        public Player() { }

        public Player(string email, string userName, string password)
        {
            // Keep id and email in sync
            id = email;
            Email = email;

            // Assign basic identity fields
            UserName = userName;
            Password = password;

            // Store runtime type name for object classification
            ObjType = GetType().Name;

            // Create a default save structure
            Save = new SaveData();
        }
    }

    public class Admin : Player
    {
        // Role name used for admin permissions
        public string RoleName { get; set; }

        // Empty constructor required for deserialization
        public Admin() { }

        public Admin(string email, string userName, string password, string roleName)
            : base(email, userName, password)
        {
            // Store admin role
            RoleName = roleName;

            // Override object type to Admin
            ObjType = GetType().Name;
        }
    }

    public class SaveData
    {
        // Saved crop instances in the world
        [JsonRequired] public List<CropSaveItem> crops { get; set; }

        // Inventory items and counts keyed by item name
        [JsonRequired] public Dictionary<string, int> inventory { get; set; }

        // Player position and state data
        [JsonRequired] public PlayerState player { get; set; }

        // Saved tilled soil cells
        [JsonRequired] public TilledSoil tilled_soil { get; set; }

        // Current in game time values
        [JsonRequired] public GameTime time { get; set; }

        // Tool ownership states keyed by tool name
        [JsonRequired] public Dictionary<string, bool> tools { get; set; }

        // Save version used for migrations and compatibility
        [JsonRequired] public int version { get; set; } = 1;

        public SaveData()
        {
            // Initialize default inventory keys to avoid missing items
            inventory = new Dictionary<string, int>
            {
                { "corn", 0 },
                { "egg", 0 },
                { "log", 0 },
                { "milk", 0 },
                { "stone", 0 },
                { "tomato", 0 }
            };

            // Initialize default time values
            time = new GameTime();
        }
    }

    public class PlayerState
    {
        // Player position in the world
        public Position pos { get; set; }
    }

    public class Position
    {
        // X coordinate in the world
        public float x { get; set; }

        // Y coordinate in the world
        public float y { get; set; }

        // Empty constructor required for deserialization
        public Position() { }

        public Position(float x, float y)
        {
            // Assign coordinates
            this.x = x;
            this.y = y;
        }
    }

    public class GameTime
    {
        // Current in game day
        public int day { get; set; }

        // Minutes passed in the current day
        public int minute { get; set; }

        // Accumulator used by the game time system
        public float time_acc { get; set; }

        // Total minutes passed since game start
        public int total_minutes { get; set; }

        public GameTime()
        {
            // Default starting time for a new save
            day = 1;
            minute = 360;
        }

        public GameTime(int day, int minute, float time_acc, int total_minutes)
        {
            // Assign time fields from save data
            this.day = day;
            this.minute = minute;
            this.time_acc = time_acc;
            this.total_minutes = total_minutes;
        }
    }

    public class TilledSoil
    {
        // List of tilled soil cells in the world
        public List<Cell> cells { get; set; }
    }

    public class Cell
    {
        // Cell x position in the tile grid
        public int x { get; set; }

        // Cell y position in the tile grid
        public int y { get; set; }
    }

    public class CropSaveItem
    {
        // Crop growth state data
        public CropGrowth growth { get; set; }

        // Crop position in the world
        public Position pos { get; set; }

        // Crop scene path or identifier used by the game
        public string scene { get; set; } = "";
    }

    public class CropGrowth
    {
        // Days remaining until harvest is available
        public int days_until_harvest { get; set; }

        // Flag that indicates if crop was watered today
        public bool is_watered { get; set; }

        // Last day index when the crop was watered
        public int last_watered_day { get; set; }

        // Minutes required per growth stage
        public int minutes_per_growth_stage { get; set; }

        // Total minutes value at planting time
        public int starting_total_minutes { get; set; }

        // Growth state index used by the crop state machine
        public int state { get; set; }
    }
}
