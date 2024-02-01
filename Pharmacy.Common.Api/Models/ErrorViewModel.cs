namespace Pharmacy.Common.Api.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the RequestId
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether ShowRequestId
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}