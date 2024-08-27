namespace Utconnect.Common.Configurations.Models
{
    /// <summary>
    /// Represents the configuration settings for a website.
    /// </summary>
    public interface ISiteConfig
    {
        /// <summary>
        /// Gets or sets the URL of the website.
        /// </summary>
        /// <value>
        /// The URL of the website as a string.
        /// </value>
        string Url { get; set; }
    }
}