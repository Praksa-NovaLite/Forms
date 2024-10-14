using System.ComponentModel.DataAnnotations.Schema;

namespace Forms.Models;

public abstract class Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; init; }
}
