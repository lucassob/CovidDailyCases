using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CovidDailyCases.Domain.Models;

public class Entity
{
	public Entity()
	{
		Id = Guid.NewGuid();
	}
    public Guid Id { get; set; }
}