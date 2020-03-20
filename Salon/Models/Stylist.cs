using System.Collections.Generic;

namespace Salon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      this.Clients = new HashSet<Client>();
    }

    public int StylistId { get; set; }
    public string Type { get; set; }
    public virtual ICollection<Client> Clients { get; set; }
  }
}