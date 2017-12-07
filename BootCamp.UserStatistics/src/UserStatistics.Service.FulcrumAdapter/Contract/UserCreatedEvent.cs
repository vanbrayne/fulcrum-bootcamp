namespace UserStatistics.Service.FulcrumAdapter.Contract
{
    /// <summary>
    /// This event is published whenever a new user as been created
    /// </summary>
    public class UserCreatedEvent
    {
        /// <summary>
        /// The unique identifier for the created user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The type of user that was created (internal/external)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The time when the user was created
        /// </summary>
        public string CreatedAt { get; set; }
    }
}